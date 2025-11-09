namespace APKQuickInstall
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersionLabel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAuthorLabel;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpTechnologies;
        private System.Windows.Forms.Label lblTechnologies;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnClose;

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
            pictureBoxLogo = new PictureBox();
            lblTitle = new Label();
            lblVersionLabel = new Label();
            lblVersion = new Label();
            lblAuthorLabel = new Label();
            lblAuthor = new Label();
            lblDescriptionLabel = new Label();
            lblDescription = new Label();
            grpTechnologies = new GroupBox();
            lblTechnologies = new Label();
            linkGitHub = new LinkLabel();
            lblCopyright = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            grpTechnologies.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Resources.apk_quick_install;
            pictureBoxLogo.Location = new Point(14, 16);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(91, 107);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.Location = new Point(120, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "ADB APK Installer";
            // 
            // lblVersionLabel
            // 
            lblVersionLabel.AutoSize = true;
            lblVersionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVersionLabel.Location = new Point(120, 80);
            lblVersionLabel.Name = "lblVersionLabel";
            lblVersionLabel.Size = new Size(65, 20);
            lblVersionLabel.TabIndex = 2;
            lblVersionLabel.Text = "Version:";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(189, 80);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(39, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "1.0.0";
            // 
            // lblAuthorLabel
            // 
            lblAuthorLabel.AutoSize = true;
            lblAuthorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAuthorLabel.Location = new Point(14, 147);
            lblAuthorLabel.Name = "lblAuthorLabel";
            lblAuthorLabel.Size = new Size(64, 20);
            lblAuthorLabel.TabIndex = 4;
            lblAuthorLabel.Text = "Author:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(80, 147);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(82, 20);
            lblAuthor.TabIndex = 5;
            lblAuthor.Text = "Your Name";
            // 
            // lblDescriptionLabel
            // 
            lblDescriptionLabel.AutoSize = true;
            lblDescriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescriptionLabel.Location = new Point(14, 193);
            lblDescriptionLabel.Name = "lblDescriptionLabel";
            lblDescriptionLabel.Size = new Size(93, 20);
            lblDescriptionLabel.TabIndex = 6;
            lblDescriptionLabel.Text = "Description:";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(14, 220);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(526, 80);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "A powerful tool to install and manage Android APK files via ADB (Android Debug Bridge). Supports USB and network connections with multi-language support.";
            // 
            // grpTechnologies
            // 
            grpTechnologies.Controls.Add(lblTechnologies);
            grpTechnologies.Location = new Point(14, 313);
            grpTechnologies.Margin = new Padding(3, 4, 3, 4);
            grpTechnologies.Name = "grpTechnologies";
            grpTechnologies.Padding = new Padding(3, 4, 3, 4);
            grpTechnologies.Size = new Size(526, 160);
            grpTechnologies.TabIndex = 8;
            grpTechnologies.TabStop = false;
            grpTechnologies.Text = "Technologies";
            // 
            // lblTechnologies
            // 
            lblTechnologies.Location = new Point(17, 33);
            lblTechnologies.Name = "lblTechnologies";
            lblTechnologies.Size = new Size(491, 113);
            lblTechnologies.TabIndex = 0;
            lblTechnologies.Text = "• .NET 10.0\r\n• Windows Forms\r\n• AdvancedSharpAdbClient\r\n• Android Debug Bridge (ADB)\r\n• JSON Localization System";
            // 
            // linkGitHub
            // 
            linkGitHub.AutoSize = true;
            linkGitHub.Location = new Point(14, 493);
            linkGitHub.Name = "linkGitHub";
            linkGitHub.Size = new Size(156, 20);
            linkGitHub.TabIndex = 9;
            linkGitHub.TabStop = true;
            linkGitHub.Text = "🔗 GitHub Repository";
            linkGitHub.LinkClicked += LinkGitHub_LinkClicked;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.ForeColor = Color.Gray;
            lblCopyright.Location = new Point(14, 527);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(184, 20);
            lblCopyright.TabIndex = 10;
            lblCopyright.Text = "© 2025 All rights reserved.";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(437, 513);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(103, 40);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // AboutForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 575);
            Controls.Add(btnClose);
            Controls.Add(lblCopyright);
            Controls.Add(linkGitHub);
            Controls.Add(grpTechnologies);
            Controls.Add(lblDescription);
            Controls.Add(lblDescriptionLabel);
            Controls.Add(lblAuthor);
            Controls.Add(lblAuthorLabel);
            Controls.Add(lblVersion);
            Controls.Add(lblVersionLabel);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxLogo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            grpTechnologies.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}