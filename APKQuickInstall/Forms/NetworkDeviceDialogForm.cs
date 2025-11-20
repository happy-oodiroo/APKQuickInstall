using AdvancedSharpAdbClient;
using APKQuickInstall.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static APKQuickInstall.Localization.LocalizationHelper;

namespace APKQuickInstall
{
    public partial class NetworkDeviceDialogForm : Form
    {
        private ControlPositionManager positionManager = new ControlPositionManager();
        private AdbClient adbClient;
        public bool ConnectionSuccessful { get; private set; }

        private static readonly string HistoryFilePath = Path.Combine(Program.AppDataPath,
           "network_history.json"
       );

        public NetworkDeviceDialogForm(AdbClient client)
        {
            this.adbClient = client;
            InitializeComponent();
            ReloadLocalization();
        }

        public void ReloadLocalization()
        {
            this.Text = T("NetworkDialog.Title");

            // Labels
            lblTitle.Text = T("NetworkDialog.FormTitle");
            lblIpAddress.Text = T("NetworkDialog.IpAddressLabel");
            lblPort.Text = T("NetworkDialog.PortLabel");
            lblHistory.Text = T("NetworkDialog.HistoryLabel");

            // Boutons
            btnConnect.Text = T("NetworkDialog.ConnectButton");
            btnDisconnect.Text = T("NetworkDialog.DisconnectButton");
            btnCancel.Text = T("Common.Close");

            // Instructions
            grpInstructions.Text = T("NetworkDialog.Instructions");
            lblInstructions.Text = T("NetworkDialog.InstructionsText");

            // RTL 
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


        private void NetworkDeviceDialog_Load(object sender, EventArgs e)
        {
            // Définir le port par défaut
            txtPort.Text = "5555";
            // Charger l'historique
            // Charger l'historique
            LoadHistory();
        }

        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            var ipAddress = txtIpAddress.Text.Trim();
            var portText = txtPort.Text.Trim();

            // Validation de l'adresse IP
            if (string.IsNullOrEmpty(ipAddress))
            {
                ShowMessage("NetworkDialog.EnterIpAddress", "Common.Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIpAddress.Focus();
                return;
            }

            if (!IPAddress.TryParse(ipAddress, out _))
            {
                ShowMessage("NetworkDialog.InvalidIpAddress", "Common.Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIpAddress.Focus();
                return;
            }

            // Validation du port
            if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            {
                ShowMessage("NetworkDialog.InvalidPort", "Common.Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return;
            }

            // Désactiver les contrôles pendant la connexion
            SetControlsEnabled(false);
            lblStatus.Text = T("NetworkDialog.Connecting");
            lblStatus.ForeColor = Color.Orange;

            try
            {
                var endpoint = $"{ipAddress}:{port}";
                string connectionResult = "failed";

                await System.Threading.Tasks.Task.Run(() =>
                {
                    connectionResult= adbClient.Connect(endpoint);
                });
                if(!(connectionResult.StartsWith("connected") || connectionResult.StartsWith("already")))
                    throw new Exception(connectionResult);
                lblStatus.Text = "✓ Connexion réussie !";
                lblStatus.ForeColor = Color.Green;

                ConnectionSuccessful = true;

                ShowMessage(T("NetworkDialog.ConnectionSuccessMessage",args: [$"{ipAddress}:{port}"]),
                    "Common.Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sauvegarder dans l'historique
                SaveToHistory(ipAddress, port);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = T("NetworkDialog.ConnectionFailed");
                lblStatus.ForeColor = Color.Red;
                ShowLocalizedMessage(T("NetworkDialog.ConnectionFailedMessage",
                    new { ex.Message }), "Common.Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                SetControlsEnabled(true);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            var ipAddress = txtIpAddress.Text.Trim();
            var portText = txtPort.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress) || !int.TryParse(portText, out int port))
            {
                ShowMessage("NetworkDialog.EnterValidIpAndPort", "Common.Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var endpoint = $"{ipAddress}:{port}";
                adbClient.Disconnect(new DnsEndPoint(ipAddress, port));

                lblStatus.Text = T("NetworkDialog.Disconnected");
                lblStatus.ForeColor = Color.Green;

                ShowMessage("NetworkDialog.DisconnectionSuccessMessage",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowMessage("NetworkDialog.DisconnectError",
                    "Common.Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CmbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHistory.SelectedItem is HistoryItem item)
            {
                txtIpAddress.Text = item.IpAddress;
                txtPort.Text = item.Port.ToString();
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtIpAddress.Enabled = enabled;
            txtPort.Enabled = enabled;
            btnConnect.Enabled = enabled;
            btnDisconnect.Enabled = enabled;
            btnCancel.Enabled = enabled;
            cmbHistory.Enabled = enabled;
        }

        private void SaveToHistory(string ipAddress, int port)
        {
            var item = new HistoryItem { IpAddress = ipAddress, Port = port };

            // Vérifier si l'élément existe déjà
            foreach (var existingItem in cmbHistory.Items)
            {
                if (existingItem is HistoryItem hi && hi.IpAddress == ipAddress && hi.Port == port)
                {
                    return; // Déjà dans l'historique
                }
            }

            cmbHistory.Items.Insert(0, item);

            // Limiter l'historique à 10 éléments
            while (cmbHistory.Items.Count > 10)
            {
                cmbHistory.Items.RemoveAt(cmbHistory.Items.Count - 1);
            }
            // Sauvegarder l'historique sur disque
            SaveHistoryToFile();
        }

        private void LoadHistory()
        {
            try
            {
                if (!File.Exists(HistoryFilePath))
                {
                    return;
                }

                string json = File.ReadAllText(HistoryFilePath);
                var historyList = JsonSerializer.Deserialize<List<HistoryItem>>(json);

                if (historyList != null)
                {
                    cmbHistory.Items.Clear();
                    foreach (var item in historyList)
                    {
                        cmbHistory.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Erreur silencieuse, l'historique n'est pas critique
                System.Diagnostics.Debug.WriteLine($"Error loading history: {ex.Message}");
            }
        }

        private void SaveHistoryToFile()
        {
            try
            {
                var historyList = new List<HistoryItem>();

                foreach (var item in cmbHistory.Items)
                {
                    if (item is HistoryItem hi)
                    {
                        historyList.Add(hi);
                    }
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(historyList, options);
                File.WriteAllText(HistoryFilePath, json);
            }
            catch (Exception ex)
            {
                // Erreur silencieuse, l'historique n'est pas critique
                System.Diagnostics.Debug.WriteLine($"Error saving history: {ex.Message}");
            }
        }

        private class HistoryItem
        {
            public string IpAddress { get; set; }
            public int Port { get; set; }

            public override string ToString()
            {
                return $"{IpAddress}:{Port}";
            }
        }
    }
}
