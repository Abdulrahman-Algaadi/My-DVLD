namespace Course__19__DVLD___Project
{
    partial class Release_Detained_License
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
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrDetainInfo1 = new Course__19__DVLD___Project.ctrDetainInfo();
            this.ctrShowLicenseInfo1 = new Course__19__DVLD___Project.ctrShowLicenseInfo();
            this.ctrFilterLicense1 = new Course__19__DVLD___Project.ctrFilterLicense();
            this.SuspendLayout();
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(338, 810);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(138, 19);
            this.llShowLicenseInfo.TabIndex = 21;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llLicenseHistory
            // 
            this.llLicenseHistory.AutoSize = true;
            this.llLicenseHistory.Location = new System.Drawing.Point(150, 810);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.llLicenseHistory.TabIndex = 20;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(511, 786);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 19;
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
            this.btnSave.Location = new System.Drawing.Point(673, 786);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 47);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Release License";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 41);
            this.label1.TabIndex = 22;
            this.label1.Text = "Release Driving License";
            // 
            // ctrDetainInfo1
            // 
            this.ctrDetainInfo1.LicenseID = -1;
            this.ctrDetainInfo1.Location = new System.Drawing.Point(56, 554);
            this.ctrDetainInfo1.Name = "ctrDetainInfo1";
            this.ctrDetainInfo1.ReleasedApplicationID = -1;
            this.ctrDetainInfo1.Size = new System.Drawing.Size(827, 217);
            this.ctrDetainInfo1.TabIndex = 23;
            // 
            // ctrShowLicenseInfo1
            //
            this.ctrShowLicenseInfo1.Location = new System.Drawing.Point(27, 186);
            this.ctrShowLicenseInfo1.Name = "ctrShowLicenseInfo1";
            this.ctrShowLicenseInfo1.Size = new System.Drawing.Size(842, 371);
            this.ctrShowLicenseInfo1.TabIndex = 16;
            // 
            // ctrFilterLicense1
            // 
            this.ctrFilterLicense1.Location = new System.Drawing.Point(12, 54);
            this.ctrFilterLicense1.Name = "ctrFilterLicense1";
            this.ctrFilterLicense1.Size = new System.Drawing.Size(911, 150);
            this.ctrFilterLicense1.TabIndex = 15;
            // 
            // Release_Detained_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 868);
            this.Controls.Add(this.ctrDetainInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrShowLicenseInfo1);
            this.Controls.Add(this.ctrFilterLicense1);
            this.Name = "Release_Detained_License";
            this.Text = "Release_Detained_License";
            this.Load += new System.EventHandler(this.Release_Detained_License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private ctrShowLicenseInfo ctrShowLicenseInfo1;
        private ctrFilterLicense ctrFilterLicense1;
        private System.Windows.Forms.Label label1;
        private ctrDetainInfo ctrDetainInfo1;
    }
}