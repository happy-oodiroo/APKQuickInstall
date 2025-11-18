namespace APKQuickInstall
{
    partial class AdbConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtAdbPath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnContinue;

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
            lblTitle = new Label();
            lblStatus = new Label();
            lblStatusValue = new Label();
            lblVersion = new Label();
            lblVersionValue = new Label();
            lblPath = new Label();
            txtAdbPath = new TextBox();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            btnDownload = new Button();
            btnBrowse = new Button();
            btnVerify = new Button();
            btnContinue = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(629, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Configuration d'Android Debug Bridge (ADB)";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(23, 93);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Statut :";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.ForeColor = Color.Gray;
            lblStatusValue.Location = new Point(137, 93);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(153, 20);
            lblStatusValue.TabIndex = 2;
            lblStatusValue.Text = "Vérification en cours...";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVersion.Location = new Point(23, 133);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(69, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "Version :";
            // 
            // lblVersionValue
            // 
            lblVersionValue.AutoSize = true;
            lblVersionValue.Location = new Point(137, 133);
            lblVersionValue.Name = "lblVersionValue";
            lblVersionValue.Size = new Size(15, 20);
            lblVersionValue.TabIndex = 4;
            lblVersionValue.Text = "-";
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPath.Location = new Point(23, 173);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(70, 20);
            lblPath.TabIndex = 5;
            lblPath.Text = "Chemin :";
            // 
            // txtAdbPath
            // 
            txtAdbPath.BackColor = Color.WhiteSmoke;
            txtAdbPath.Location = new Point(137, 169);
            txtAdbPath.Margin = new Padding(3, 4, 3, 4);
            txtAdbPath.Name = "txtAdbPath";
            txtAdbPath.ReadOnly = true;
            txtAdbPath.Size = new Size(514, 27);
            txtAdbPath.TabIndex = 6;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(23, 240);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(629, 33);
            progressBar.TabIndex = 7;
            progressBar.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.Location = new Point(23, 280);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(629, 27);
            lblProgress.TabIndex = 8;
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            lblProgress.Visible = false;
            // 
            // btnDownload
            // 
            btnDownload.Enabled = false;
            btnDownload.Location = new Point(23, 347);
            btnDownload.Margin = new Padding(3, 4, 3, 4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(286, 47);
            btnDownload.TabIndex = 9;
            btnDownload.Text = "Télécharger et installer ADB";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += BtnDownload_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(331, 347);
            btnBrowse.Margin = new Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(149, 47);
            btnBrowse.TabIndex = 10;
            btnBrowse.Text = "Parcourir...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // btnVerify
            // 
            btnVerify.Location = new Point(503, 347);
            btnVerify.Margin = new Padding(3, 4, 3, 4);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(149, 47);
            btnVerify.TabIndex = 11;
            btnVerify.Text = "Vérifier à nouveau";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += BtnVerify_Click;
            // 
            // btnContinue
            // 
            btnContinue.Enabled = false;
            btnContinue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnContinue.Location = new Point(503, 480);
            btnContinue.Margin = new Padding(3, 4, 3, 4);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(149, 53);
            btnContinue.TabIndex = 12;
            btnContinue.Text = "Continuer";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += BtnContinue_Click;
            // 
            // AdbConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 561);
            Controls.Add(btnContinue);
            Controls.Add(btnVerify);
            Controls.Add(btnBrowse);
            Controls.Add(btnDownload);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(txtAdbPath);
            Controls.Add(lblPath);
            Controls.Add(lblVersionValue);
            Controls.Add(lblVersion);
            Controls.Add(lblStatusValue);
            Controls.Add(lblStatus);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdbConfigurationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "⚙️Configuration ADB";
            Load += AdbConfigurationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
