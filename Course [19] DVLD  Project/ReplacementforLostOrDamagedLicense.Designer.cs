namespace Course__19__DVLD___Project
{
    partial class ReplacementForLostOrDamagedLicense
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLost = new System.Windows.Forms.RadioButton();
            this.rdbDamaged = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.ctrShowLicenseInfo1 = new Course__19__DVLD___Project.ctrShowLicenseInfo();
            this.ctrFilterLicense1 = new Course__19__DVLD___Project.ctrFilterLicense();
            this.ctrApplicationInfoForReplacement1 = new Course__19__DVLD___Project.ctrApplicationInfoForReplacement();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLost);
            this.groupBox1.Controls.Add(this.rdbDamaged);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(753, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For";
            // 
            // rdbLost
            // 
            this.rdbLost.AutoSize = true;
            this.rdbLost.Location = new System.Drawing.Point(3, 54);
            this.rdbLost.Name = "rdbLost";
            this.rdbLost.Size = new System.Drawing.Size(132, 24);
            this.rdbLost.TabIndex = 1;
            this.rdbLost.TabStop = true;
            this.rdbLost.Text = "Lost License";
            this.rdbLost.UseVisualStyleBackColor = true;
            this.rdbLost.CheckedChanged += new System.EventHandler(this.rdbLost_CheckedChanged);
            // 
            // rdbDamaged
            // 
            this.rdbDamaged.AutoSize = true;
            this.rdbDamaged.Location = new System.Drawing.Point(3, 24);
            this.rdbDamaged.Name = "rdbDamaged";
            this.rdbDamaged.Size = new System.Drawing.Size(170, 24);
            this.rdbDamaged.TabIndex = 0;
            this.rdbDamaged.TabStop = true;
            this.rdbDamaged.Text = "Damaged License";
            this.rdbDamaged.UseVisualStyleBackColor = true;
            this.rdbDamaged.CheckedChanged += new System.EventHandler(this.rdbDamaged_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Location = new System.Drawing.Point(211, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(557, 41);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Replacement For Damaged License";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(562, 810);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(173, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::Course__19__DVLD___Project.Properties.Resources.diskette;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(777, 810);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(222, 47);
            this.btnIssueReplacement.TabIndex = 7;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // ctrShowLicenseInfo1
            // 
     
            this.ctrShowLicenseInfo1.Location = new System.Drawing.Point(37, 198);
            this.ctrShowLicenseInfo1.Name = "ctrShowLicenseInfo1";
            this.ctrShowLicenseInfo1.Size = new System.Drawing.Size(992, 372);
            this.ctrShowLicenseInfo1.TabIndex = 3;
            // 
            // ctrFilterLicense1
            // 
            this.ctrFilterLicense1.Location = new System.Drawing.Point(24, 54);
            this.ctrFilterLicense1.Name = "ctrFilterLicense1";
            this.ctrFilterLicense1.Size = new System.Drawing.Size(723, 150);
            this.ctrFilterLicense1.TabIndex = 0;
            // 
            // ctrApplicationInfoForReplacement1
            // 
            this.ctrApplicationInfoForReplacement1.ApplicationFees = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.ctrApplicationInfoForReplacement1.L_R_ApplicationID = -1;
            this.ctrApplicationInfoForReplacement1.Location = new System.Drawing.Point(51, 574);
            this.ctrApplicationInfoForReplacement1.Name = "ctrApplicationInfoForReplacement1";
            this.ctrApplicationInfoForReplacement1.OldLicenseID = -1;
            this.ctrApplicationInfoForReplacement1.ReplacedLicenseID = -1;
            this.ctrApplicationInfoForReplacement1.Size = new System.Drawing.Size(962, 202);
            this.ctrApplicationInfoForReplacement1.TabIndex = 2;
            this.ctrApplicationInfoForReplacement1.User = null;
            this.ctrApplicationInfoForReplacement1.Load += new System.EventHandler(this.ctrApplicationInfoForReplacement1_Load);
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(308, 823);
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
            this.llLicenseHistory.Location = new System.Drawing.Point(67, 823);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.llLicenseHistory.TabIndex = 13;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // ReplacementForLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 886);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.ctrApplicationInfoForReplacement1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.ctrShowLicenseInfo1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrFilterLicense1);
            this.Name = "ReplacementForLostOrDamagedLicense";
            this.Text = "ReplacementForLostOrDamagedLicense";
            this.Load += new System.EventHandler(this.ReplacementForLostOrDamagedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrFilterLicense ctrFilterLicense1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLost;
        private System.Windows.Forms.RadioButton rdbDamaged;
        private System.Windows.Forms.Label lblTitle;
        private ctrShowLicenseInfo ctrShowLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacement;
        private ctrApplicationInfoForReplacement ctrApplicationInfoForReplacement1;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
    }
}