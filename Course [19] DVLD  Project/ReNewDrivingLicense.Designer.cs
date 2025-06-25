namespace Course__19__DVLD___Project
{
    partial class ReNewDrivingLicense
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
            this.ctrNewApplicationLicenseInfo1 = new Course__19__DVLD___Project.ctrNewApplicationLicenseInfo();
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
            this.label1.Location = new System.Drawing.Point(315, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "ReNew License Application";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(696, 932);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Course__19__DVLD___Project.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(850, 932);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Renew";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrNewApplicationLicenseInfo1
            // 
            this.ctrNewApplicationLicenseInfo1.LicenseID = -1;
            this.ctrNewApplicationLicenseInfo1.Location = new System.Drawing.Point(40, 554);
            this.ctrNewApplicationLicenseInfo1.Name = "ctrNewApplicationLicenseInfo1";
            this.ctrNewApplicationLicenseInfo1.ReNewApplicationID = 0;
            this.ctrNewApplicationLicenseInfo1.RenewedLicenseID = 0;
            this.ctrNewApplicationLicenseInfo1.Size = new System.Drawing.Size(965, 348);
            this.ctrNewApplicationLicenseInfo1.TabIndex = 3;
            this.ctrNewApplicationLicenseInfo1.User = null;
            // 
            // ctrShowLicenseInfo1

            this.ctrShowLicenseInfo1.Location = new System.Drawing.Point(40, 184);
            this.ctrShowLicenseInfo1.Name = "ctrShowLicenseInfo1";
            this.ctrShowLicenseInfo1.Size = new System.Drawing.Size(976, 364);
            this.ctrShowLicenseInfo1.TabIndex = 2;
            // 
            // ctrFilterLicense1
            // 
            this.ctrFilterLicense1.Location = new System.Drawing.Point(40, 44);
            this.ctrFilterLicense1.Name = "ctrFilterLicense1";
            this.ctrFilterLicense1.Size = new System.Drawing.Size(911, 134);
            this.ctrFilterLicense1.TabIndex = 1;
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(359, 945);
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
            this.llLicenseHistory.Location = new System.Drawing.Point(118, 945);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.llLicenseHistory.TabIndex = 13;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // ReNewDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 985);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrNewApplicationLicenseInfo1);
            this.Controls.Add(this.ctrShowLicenseInfo1);
            this.Controls.Add(this.ctrFilterLicense1);
            this.Controls.Add(this.label1);
            this.Name = "ReNewDrivingLicense";
            this.Text = "ReNewDrivingLicense";
            this.Load += new System.EventHandler(this.ReNewDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrFilterLicense ctrFilterLicense1;
        private ctrShowLicenseInfo ctrShowLicenseInfo1;
        private ctrNewApplicationLicenseInfo ctrNewApplicationLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
    }
}