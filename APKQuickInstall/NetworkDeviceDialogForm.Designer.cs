namespace APKQuickInstall
{
    partial class NetworkDeviceDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.ComboBox cmbHistory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpInstructions;
        private System.Windows.Forms.TextBox lblInstructions;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDeviceDialogForm));
            lblTitle = new Label();
            lblIpAddress = new Label();
            txtIpAddress = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            lblHistory = new Label();
            cmbHistory = new ComboBox();
            lblStatus = new Label();
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnCancel = new Button();
            grpInstructions = new GroupBox();
            lblInstructions = new TextBox();
            grpInstructions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(14, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(526, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Connexion d'un appareil Android via réseau";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Location = new Point(23, 80);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(84, 20);
            lblIpAddress.TabIndex = 1;
            lblIpAddress.Text = "Adresse IP :";
            // 
            // txtIpAddress
            // 
            txtIpAddress.Font = new Font("Consolas", 10F);
            txtIpAddress.Location = new Point(137, 76);
            txtIpAddress.Margin = new Padding(3, 4, 3, 4);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(274, 27);
            txtIpAddress.TabIndex = 2;
            txtIpAddress.Text = "192.168.1.";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(423, 80);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(42, 20);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port :";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Consolas", 10F);
            txtPort.Location = new Point(469, 76);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(68, 27);
            txtPort.TabIndex = 4;
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Location = new Point(23, 127);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(85, 20);
            lblHistory.TabIndex = 5;
            lblHistory.Text = "Historique :";
            // 
            // cmbHistory
            // 
            cmbHistory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHistory.Font = new Font("Consolas", 9F);
            cmbHistory.FormattingEnabled = true;
            cmbHistory.Location = new Point(137, 123);
            cmbHistory.Margin = new Padding(3, 4, 3, 4);
            cmbHistory.Name = "cmbHistory";
            cmbHistory.Size = new Size(399, 26);
            cmbHistory.TabIndex = 6;
            cmbHistory.SelectedIndexChanged += CmbHistory_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(23, 173);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(514, 27);
            lblStatus.TabIndex = 7;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(0, 120, 215);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(23, 562);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(160, 47);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "🔗 Connecter";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDisconnect.Location = new Point(200, 562);
            btnDisconnect.Margin = new Padding(3, 4, 3, 4);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(160, 47);
            btnDisconnect.TabIndex = 9;
            btnDisconnect.Text = "🔌 Déconnecter";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(377, 562);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 47);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Fermer";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // grpInstructions
            // 
            grpInstructions.Controls.Add(lblInstructions);
            grpInstructions.Location = new Point(23, 213);
            grpInstructions.Margin = new Padding(3, 4, 3, 4);
            grpInstructions.Name = "grpInstructions";
            grpInstructions.Padding = new Padding(3, 4, 3, 4);
            grpInstructions.Size = new Size(514, 341);
            grpInstructions.TabIndex = 11;
            grpInstructions.TabStop = false;
            grpInstructions.Text = "Instructions";
            // 
            // lblInstructions
            // 
            lblInstructions.Location = new Point(17, 33);
            lblInstructions.Multiline = true;
            lblInstructions.Name = "lblInstructions";
            lblInstructions.ReadOnly = true;
            lblInstructions.ScrollBars = ScrollBars.Vertical;
            lblInstructions.Size = new Size(480, 291);
            lblInstructions.TabIndex = 0;
            lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // NetworkDeviceDialogForm
            // 
            AcceptButton = btnConnect;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(553, 625);
            Controls.Add(grpInstructions);
            Controls.Add(btnCancel);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(lblStatus);
            Controls.Add(cmbHistory);
            Controls.Add(lblHistory);
            Controls.Add(txtPort);
            Controls.Add(lblPort);
            Controls.Add(txtIpAddress);
            Controls.Add(lblIpAddress);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NetworkDeviceDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Connexion réseau ADB";
            Load += NetworkDeviceDialog_Load;
            grpInstructions.ResumeLayout(false);
            grpInstructions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}