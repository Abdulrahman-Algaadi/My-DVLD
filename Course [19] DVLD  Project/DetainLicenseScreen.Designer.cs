namespace Course__19__DVLD___Project
{
    partial class DetainLicenseScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrDetain_Release1 = new Course__19__DVLD___Project.ctrDetain_Release();
            this.ctrShowLicenseInfo1 = new Course__19__DVLD___Project.ctrShowLicenseInfo();
            this.ctrFilterLicense1 = new Course__19__DVLD___Project.ctrFilterLicense();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detain Driving License";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(540, 812);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Course__19__DVLD___Project.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(694, 812);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrDetain_Release1
            // 
            this.ctrDetain_Release1.LicenseID = -1;
            this.ctrDetain_Release1.Location = new System.Drawing.Point(33, 598);
            this.ctrDetain_Release1.Name = "ctrDetain_Release1";
            this.ctrDetain_Release1.Size = new System.Drawing.Size(821, 197);
            this.ctrDetain_Release1.TabIndex = 3;
            this.ctrDetain_Release1.User = null;
            // 
            // ctrShowLicenseInfo1
            // 
  
            this.ctrShowLicenseInfo1.Location = new System.Drawing.Point(12, 221);
            this.ctrShowLicenseInfo1.Name = "ctrShowLicenseInfo1";
            this.ctrShowLicenseInfo1.Size = new System.Drawing.Size(842, 371);
            this.ctrShowLicenseInfo1.TabIndex = 1;
            // 
            // ctrFilterLicense1
            // 
            this.ctrFilterLicense1.Location = new System.Drawing.Point(-3, 89);
            this.ctrFilterLicense1.Name = "ctrFilterLicense1";
            this.ctrFilterLicense1.Size = new System.Drawing.Size(911, 150);
            this.ctrFilterLicense1.TabIndex = 0;
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(265, 825);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(138, 19);
            this.llShowLicenseInfo.TabIndex = 14;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llLicenseHistory
            // 
            this.llLicenseHistory.AutoSize = true;
            this.llLicenseHistory.Location = new System.Drawing.Point(64, 825);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.llLicenseHistory.TabIndex = 13;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // Detain_Release_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 865);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrDetain_Release1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrShowLicenseInfo1);
            this.Controls.Add(this.ctrFilterLicense1);
            this.Name = "Detain_Release_License";
            this.Text = "Detain_Release_License";
            this.Load += new System.EventHandler(this.Detain_Release_License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrFilterLicense ctrFilterLicense1;
        private ctrShowLicenseInfo ctrShowLicenseInfo1;
        private System.Windows.Forms.Label label1;
        private ctrDetain_Release ctrDetain_Release1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
    }
}