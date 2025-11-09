using AdvancedSharpAdbClient;
using AdvancedSharpAdbClient.DeviceCommands;
using AdvancedSharpAdbClient.Models;
using APKQuickInstall.Configuration;
using APKQuickInstall.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static APKQuickInstall.Localization.LocalizationHelper;

namespace APKQuickInstall
{
    /// <summary>
    /// Formulaire principal pour l'installation d'APK
    /// </summary>
    public partial class MainForm : Form
    {

        private AdbClient adbClient;
        private DeviceData? selectedDevice;
        private string selectedApkPath;
        private ControlPositionManager positionManager = new ControlPositionManager();
        public MainForm()
        {
            InitializeComponent();
            positionManager.SaveOriginalPositions(this);
            ReloadLocalization();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var config = AdbConfiguration.Load();
            while (config == null || !config.IsValid())
            {
                using var configForm = new AdbConfigurationForm();
                var result = configForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    config = AdbConfiguration.Load();
                }
                else
                {
                    ShowMessage("MainForm.AdbConfigNotFound",
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.Close();
                    return;
                }


                try
                {
                    var adbServer = new AdbServer();
                    var adbPath = config.AdbPath;

                    adbServer.StartServer(adbPath, restartServerIfNewer: false);
                    adbClient = new AdbClient();

                    LogMessage(T("MainForm.AdbInitialized", config.AdbVersion));
                    LogMessage(T("MainForm.AdbPath", config.AdbPath));
                    LogMessage("─────────────────────────────────────");

                    RefreshDevices();
                }
                catch (Exception ex)
                {
                    ShowMessage("MainForm.AdbInitError",
                        "Common.Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        ex.Message);
                    this.Close();
                }
            }
        }

        public void ReloadLocalization()
        {

            this.Text = T("MainForm.Title");

            // Menu
            menuLanguage.Text = T("Common.Language");
            menuConfigurationADB.Text = T("AdbConfiguration.Title");
            menuAbout.Text = T("About.Title");

            // Groupes
            grpDevice.Text = T("MainForm.DeviceGroup");
            grpApk.Text = T("MainForm.ApkGroup");
            grpOptions.Text = T("MainForm.OptionsGroup");
            grpLog.Text = T("MainForm.LogGroup");

            // Labels
            lblDevice.Text = T("MainForm.DeviceLabel");
            lblApkPath.Text = T("MainForm.ApkLabel");

            // Boutons
            btnRefreshDevices.Text = T("MainForm.RefreshButton");
            btnBrowseApk.Text = T("MainForm.BrowseButton");
            btnInstall.Text = T("MainForm.InstallButton");
            btnUninstall.Text = T("MainForm.UninstallButton");
            btnClearLog.Text = T("MainForm.ClearLogButton");
            btnNetworkDevice.Text = T("MainForm.NetworkButton");

            // Options
            chkReinstall.Text = T("MainForm.ReinstallOption");
            chkGrantPermissions.Text = T("MainForm.GrantPermissionsOption");

            if (string.IsNullOrEmpty(selectedApkPath))
            {
                lblApkName.Text = T("MainForm.NoFileSelected");
            }

            if (LocalizationManager.Instance.CurrentLanguage == "ar")
            {
                this.RightToLeft = RightToLeft.Yes;
                positionManager.MirrorPositions(this, true);
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
                positionManager.RestoreOriginalPositions(this);
            }
        }

        private void BtnRefreshDevices_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void RefreshDevices()
        {
            try
            {
                cmbDevices.Items.Clear();
                var devices = adbClient.GetDevices();

                if (devices.Count() == 0)
                {
                    LogMessage(T("MainForm.NoDeviceDetected"));
                    LogMessage(T("MainForm.ConnectDeviceMessage"));
                    cmbDevices.Items.Add(T("MainForm.NoDeviceConnected"));
                    cmbDevices.SelectedIndex = 0;
                    cmbDevices.Enabled = false;
                    btnInstall.Enabled = false;
                    return;
                }

                cmbDevices.Enabled = true;
                LogMessage(T("MainForm.DevicesDetected", devices.Count()));

                foreach (var device in devices)
                {
                    var displayText = $"{device.Name} - {device.Model} - {device.Serial} [{device.State}]";
                    cmbDevices.Items.Add(new DeviceItem { Device = device, DisplayText = displayText });
                    LogMessage($"  • {device.Name} - {device.Model} ({device.Serial}) - {device.State}");
                }

                cmbDevices.SelectedIndex = 0;
                LogMessage("─────────────────────────────────────");
            }
            catch (Exception ex)
            {
                LogMessage(T("MainForm.ErrorDetectingDevices", ex.Message));
            }
        }

        private void BtnNetworkDevice_Click(object sender, EventArgs e)
        {
            using var networkDialog = new NetworkDeviceDialogForm(adbClient);
            if (networkDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDevices();
            }
        }

        private void CmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is DeviceItem deviceItem)
            {
                selectedDevice = deviceItem.Device;
                UpdateInstallButtonState();
            }
        }

        private void BtnBrowseApk_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Android Package|*.apk",
                Title = T("MainForm.ApkGroup")
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedApkPath = openFileDialog.FileName;
                txtApkPath.Text = selectedApkPath;
                lblApkName.Text = Path.GetFileName(selectedApkPath);

                // Afficher la taille du fichier
                var fileInfo = new FileInfo(selectedApkPath);
                var sizeMB = fileInfo.Length / (1024.0 * 1024.0);
                lblApkSize.Text = T("MainForm.FileSize", sizeMB.ToString("F2"));

                LogMessage(T("MainForm.ApkSelected", Path.GetFileName(selectedApkPath), sizeMB.ToString("F2")));

                UpdateInstallButtonState();
            }
        }

        private void UpdateInstallButtonState()
        {
            btnInstall.Enabled = selectedDevice != null &&
                                 !string.IsNullOrEmpty(selectedApkPath) &&
                                 File.Exists(selectedApkPath);
        }

        private async void BtnInstall_Click(object sender, EventArgs e)
        {
            if (selectedDevice == null || string.IsNullOrEmpty(selectedApkPath))
            {
                return;
            }

            // Désactiver les contrôles pendant l'installation
            SetControlsEnabled(false);
            progressBar.Visible = true;
            progressBar.Value = 0;

            try
            {
                LogMessage("─────────────────────────────────────");
                LogMessage(T("MainForm.InstallationStarted", selectedDevice.Value.Model));

                var packageManager = new PackageManager(adbClient, selectedDevice.Value);

                // Progression de l'installation
                var progress = new Progress<InstallProgressEventArgs>(p =>
                {
                    progressBar.Value = (int)p.UploadProgress;
                    lblProgress.Text = T("MainForm.InstallationInProgress", p.UploadProgress);
                });

                // Options d'installation
                var args = string.Empty;
                if (chkReinstall.Checked)
                {
                    args += "-r "; // Reinstall
                }
                if (chkGrantPermissions.Checked)
                {
                    args += "-g "; // Grant permissions
                }

                // Installer l'APK
                await System.Threading.Tasks.Task.Run(() =>
                {
                    if (string.IsNullOrEmpty(args))
                    {
                        packageManager.InstallPackage(selectedApkPath, progress);
                    }
                    else
                    {
                        packageManager.InstallPackage(selectedApkPath, progress, args);
                    }
                });

                LogMessage(T("MainForm.InstallationSuccessful"));
                ShowMessage("MainForm.InstallationSuccessMessage",
                    "Common.Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogMessage(T("MainForm.InstallationError", ex.Message));
                ShowMessage("MainForm.InstallationErrorMessage",
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    ex.Message);
            }
            finally
            {
                progressBar.Visible = false;
                lblProgress.Text = "";
                SetControlsEnabled(true);
                LogMessage("─────────────────────────────────────");
            }
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            if (selectedDevice == null)
            {
                ShowMessage("MainForm.SelectDeviceWarning",
                    "Common.Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var inputDialog = new Form
            {
                Text = T("MainForm.PackageNameLabel"),
                Size = new Size(400, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var label = new Label
            {
                Text = T("MainForm.UninstallButton"),
                Location = new Point(10, 20),
                Size = new Size(370, 20)
            };

            var textBox = new System.Windows.Forms.TextBox
            {
                Location = new Point(10, 45),
                Size = new Size(370, 23)
            };

            var btnOk = new System.Windows.Forms.Button
            {
                Text = T("MainForm.UninstallButton"),
                DialogResult = DialogResult.OK,
                Location = new Point(200, 75),
                Size = new Size(90, 30)
            };

            var btnCancel = new Button
            {
                Text = T("Common.Cancel"),
                DialogResult = DialogResult.Cancel,
                Location = new Point(295, 75),
                Size = new Size(85, 30)
            };

            inputDialog.Controls.Add(label);
            inputDialog.Controls.Add(textBox);
            inputDialog.Controls.Add(btnOk);
            inputDialog.Controls.Add(btnCancel);
            inputDialog.AcceptButton = btnOk;
            inputDialog.CancelButton = btnCancel;

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                var packageName = textBox.Text.Trim();
                if (string.IsNullOrEmpty(packageName))
                {
                    ShowMessage("MainForm.EnterPackageName",
                        "Common.Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                UninstallPackage(packageName);
            }
        }

        private async void UninstallPackage(string packageName)
        {
            if (selectedDevice == null) return;

            SetControlsEnabled(false);

            try
            {
                LogMessage("─────────────────────────────────────");
                LogMessage(T("MainForm.UninstallStarted", packageName));

                var packageManager = new PackageManager(adbClient, selectedDevice.Value);

                await System.Threading.Tasks.Task.Run(() =>
                {
                    packageManager.UninstallPackage(packageName);
                });

                LogMessage(T("MainForm.UninstallSuccessful", packageName));
                ShowMessage("MainForm.UninstallSuccessMessage",
                    "Common.Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    packageName);
            }
            catch (Exception ex)
            {
                LogMessage(T("MainForm.UninstallError", ex.Message));
                ShowMessage("MainForm.UninstallErrorMessage",
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    ex.Message);
            }
            finally
            {
                SetControlsEnabled(true);
                LogMessage("─────────────────────────────────────");
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void MenuLangEnglish_Click(object sender, EventArgs e)
        {
            ChangeLanguageAndReload("en");
        }

        private void MenuLangFrench_Click(object sender, EventArgs e)
        {
            ChangeLanguageAndReload("fr");
        }

        private void MenuLangArabic_Click(object sender, EventArgs e)
        {
            ChangeLanguageAndReload("ar");
        }

        private void ChangeLanguageAndReload(string languageCode)
        {
            try
            {
                LocalizationManager.Instance.ChangeLanguage(languageCode);
                ReloadLocalization();

                // Mettre à jour les coches dans le menu
                UpdateLanguageMenuChecks(languageCode);

                LogMessage(T("MainForm.LanguageChanged", LocalizationManager.GetLanguageDisplayName(languageCode)));
            }
            catch (Exception ex)
            {
                ShowMessage("Common.Error",
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateLanguageMenuChecks(string currentLang)
        {
            menuLangEnglish.Checked = currentLang == "en";
            menuLangFrench.Checked = currentLang == "fr";
            menuLangArabic.Checked = currentLang == "ar";
        }

        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => LogMessage(message)));
                return;
            }

            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }



        private void SetControlsEnabled(bool enabled)
        {
            cmbDevices.Enabled = enabled;
            btnRefreshDevices.Enabled = enabled;
            btnBrowseApk.Enabled = enabled;
            btnInstall.Enabled = enabled && selectedDevice != null && !string.IsNullOrEmpty(selectedApkPath);
            btnUninstall.Enabled = enabled;
            chkReinstall.Enabled = enabled;
            chkGrantPermissions.Enabled = enabled;
        }

        // Classe helper pour le ComboBox
        private class DeviceItem
        {
            public DeviceData Device { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void menuConfigurationADB_Click(object sender, EventArgs e)
        {
            using var configForm = new AdbConfigurationForm();
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            using var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
