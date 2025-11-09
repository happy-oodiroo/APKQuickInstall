using APKQuickInstall.Configuration;
using APKQuickInstall.Core;
using APKQuickInstall.Localization;
using static APKQuickInstall.Localization.LocalizationHelper;

namespace APKQuickInstall
{
    public partial class AdbConfigurationForm : Form, ILocalizable
    {
        private ControlPositionManager positionManager = new ControlPositionManager();
        private string currentAdbPath;

        public AdbConfigurationForm()
        {
            InitializeComponent();
            positionManager.SaveOriginalPositions(this);
            ReloadLocalization();
        }

        private async void AdbConfigurationForm_Load(object sender, EventArgs e)
        {
            var config = AdbConfiguration.Load();

            if (config != null && config.IsValid())
            {
                currentAdbPath = config.AdbPath;
                UpdateUI(true, config.AdbVersion, config.AdbPath);
            }
            else
            {
                await DetectAndValidateAdb();
            }
        }

        private async System.Threading.Tasks.Task DetectAndValidateAdb()
        {
            lblStatusValue.Text = T("AdbConfiguration.StatusChecking");
            lblStatusValue.ForeColor = Color.Gray;

            await System.Threading.Tasks.Task.Run(() =>
            {
                currentAdbPath = AdbManager.DetectAdb();
            });

            if (currentAdbPath != null)
            {
                var version = await System.Threading.Tasks.Task.Run(() =>
                    AdbManager.GetAdbVersion(currentAdbPath));

                if (version != null)
                {
                    UpdateUI(true, version, currentAdbPath);

                    var config = new AdbConfiguration
                    {
                        AdbPath = currentAdbPath,
                        AdbVersion = version,
                        LastVerified = DateTime.Now
                    };
                    config.Save();
                }
                else
                {
                    UpdateUI(false, null, currentAdbPath);
                }
            }
            else
            {
                UpdateUI(false, null, null);
            }
        }

        private void UpdateUI(bool adbFound, string version, string path)
        {
            if (adbFound)
            {
                lblStatusValue.Text = T("AdbConfiguration.StatusFound"); 
                lblStatusValue.ForeColor = Color.Green;
                lblVersionValue.Text = version ?? "-";
                txtAdbPath.Text = path ?? "";
                btnContinue.Enabled = true;
                btnDownload.Enabled = false;
            }
            else
            {
                lblStatusValue.Text = T("AdbConfiguration.StatusNotFound");
                lblStatusValue.ForeColor = Color.Red;
                lblVersionValue.Text = "-";
                txtAdbPath.Text = path ?? "";
                btnContinue.Enabled = false;
                btnDownload.Enabled = true;
            }
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;
            btnBrowse.Enabled = false;
            btnVerify.Enabled = false;
            progressBar.Visible = true;
            lblProgress.Visible = true;
            lblProgress.Text = T("AdbConfiguration.Downloading");

            try
            {
                var progress = new Progress<int>(value =>
                {
                    progressBar.Value = value;
                    lblProgress.Text = T("AdbConfiguration.Installing", value);
                });

                currentAdbPath = await AdbManager.DownloadAndInstallAdb(progress);

                lblProgress.Text = T("AdbConfiguration.InstallationComplete");
                await System.Threading.Tasks.Task.Delay(1000);

                var version = AdbManager.GetAdbVersion(currentAdbPath);
                UpdateUI(true, version, currentAdbPath);

                var config = new AdbConfiguration
                {
                    AdbPath = currentAdbPath,
                    AdbVersion = version ?? "",
                    LastVerified = DateTime.Now
                };
                config.Save();
                ShowMessage("AdbConfiguration.InstallationSuccess",
                    "Common.Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowLocalizedMessage(T("AdbConfiguration.InstallationError",ex.Message),
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                UpdateUI(false, null, null);
            }
            finally
            {
                progressBar.Visible = false;
                lblProgress.Visible = false;
                btnDownload.Enabled = true;
                btnBrowse.Enabled = true;
                btnVerify.Enabled = true;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "ADB Executable|adb.exe",
                Title = T("AdbConfiguration.Title")
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentAdbPath = openFileDialog.FileName;
                var version = AdbManager.GetAdbVersion(currentAdbPath);

                if (version != null)
                {
                    UpdateUI(true, version, currentAdbPath);

                    // Sauvegarder la configuration
                    var config = new AdbConfiguration
                    {
                        AdbPath = currentAdbPath,
                        AdbVersion = version,
                        LastVerified = DateTime.Now
                    };
                    config.Save();

                    ShowMessage("AdbConfiguration.ValidationSuccess",
                        "Common.Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ShowMessage("AdbConfiguration.ValidationError",
                        "Common.Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    UpdateUI(false, null, currentAdbPath);
                }
            }
        }

        private async void BtnVerify_Click(object sender, EventArgs e)
        {
            await DetectAndValidateAdb();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            // Passer à l'écran suivant
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void ReloadLocalization()
        {
            if (LocalizationManager.Instance.CurrentLanguage == "ar")
            {
                this.RightToLeft = RightToLeft.Yes;
                positionManager.MirrorPositions(this, true);
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
            }

            // Titre du formulaire
            this.Text = T("AdbConfiguration.Title");

            // Labels et textes
            lblTitle.Text = T("AdbConfiguration.FormTitle");
            lblStatus.Text = T("AdbConfiguration.Status") + " :";
            lblVersion.Text = T("AdbConfiguration.Version") + " :";
            lblPath.Text = T("AdbConfiguration.Path") + " :";

            // Boutons
            btnDownload.Text = T("AdbConfiguration.DownloadButton");
            btnBrowse.Text = T("Common.Browse");
            btnVerify.Text = T("AdbConfiguration.VerifyButton");
            btnContinue.Text = T("Common.Continue");

            // Mettre à jour le statut si déjà affiché
            if (lblStatusValue.Text.Contains("✓"))
            {
                lblStatusValue.Text = T("AdbConfiguration.StatusFound");
            }
            else if (lblStatusValue.Text.Contains("✗"))
            {
                lblStatusValue.Text = T("AdbConfiguration.StatusNotFound");
            }

            // Gérer le RTL pour l'arabe
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
    }
    
}
