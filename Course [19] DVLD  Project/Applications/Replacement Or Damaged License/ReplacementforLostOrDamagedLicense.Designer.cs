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
            this.grpReplacement = new System.Windows.Forms.GroupBox();
            this.rdbLost = new System.Windows.Forms.RadioButton();
            this.rdbDamaged = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ctrFilterLicenseByIDAndShow1 = new Course__19__DVLD___Project.ctrFilterLicenseByIDAndShow();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblRePlacedLicenseID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReplaceAppID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpReplacement.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReplacement
            // 
            this.grpReplacement.Controls.Add(this.rdbLost);
            this.grpReplacement.Controls.Add(this.rdbDamaged);
            this.grpReplacement.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReplacement.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpReplacement.Location = new System.Drawing.Point(737, 111);
            this.grpReplacement.Name = "grpReplacement";
            this.grpReplacement.Size = new System.Drawing.Size(225, 94);
            this.grpReplacement.TabIndex = 1;
            this.grpReplacement.TabStop = false;
            this.grpReplacement.Text = "Replacement For";
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
            this.btnClose.Location = new System.Drawing.Point(560, 810);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 47);
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
            this.btnIssueReplacement.Location = new System.Drawing.Point(713, 810);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(197, 47);
            this.btnIssueReplacement.TabIndex = 7;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
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
            // ctrFilterLicenseByIDAndShow1
            // 
            this.ctrFilterLicenseByIDAndShow1.FilterEnabled = true;
            this.ctrFilterLicenseByIDAndShow1.Location = new System.Drawing.Point(37, 88);
            this.ctrFilterLicenseByIDAndShow1.Name = "ctrFilterLicenseByIDAndShow1";
            this.ctrFilterLicenseByIDAndShow1.Size = new System.Drawing.Size(821, 485);
            this.ctrFilterLicenseByIDAndShow1.TabIndex = 15;
            this.ctrFilterLicenseByIDAndShow1.OnLicenseSelected += new System.Action<int>(this.ctrFilterLicenseByIDAndShow1_OnLicenseSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblRePlacedLicenseID);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblAppFees);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblAppDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblReplaceAppID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 579);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 207);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For Replacement";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Maroon;
            this.lblCreatedBy.Location = new System.Drawing.Point(715, 139);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(30, 23);
            this.lblCreatedBy.TabIndex = 69;
            this.lblCreatedBy.Text = "??";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Maroon;
            this.lblOldLicenseID.Location = new System.Drawing.Point(715, 93);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(30, 23);
            this.lblOldLicenseID.TabIndex = 67;
            this.lblOldLicenseID.Text = "??";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(532, 141);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(124, 23);
            this.label20.TabIndex = 65;
            this.label20.Text = "Created By : ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(532, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 23);
            this.label22.TabIndex = 64;
            this.label22.Text = "Old License ID :";
            // 
            // lblRePlacedLicenseID
            // 
            this.lblRePlacedLicenseID.AutoSize = true;
            this.lblRePlacedLicenseID.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRePlacedLicenseID.ForeColor = System.Drawing.Color.Maroon;
            this.lblRePlacedLicenseID.Location = new System.Drawing.Point(715, 55);
            this.lblRePlacedLicenseID.Name = "lblRePlacedLicenseID";
            this.lblRePlacedLicenseID.Size = new System.Drawing.Size(30, 23);
            this.lblRePlacedLicenseID.TabIndex = 61;
            this.lblRePlacedLicenseID.Text = "??";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(488, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 23);
            this.label11.TabIndex = 60;
            this.label11.Text = "Replaced LicenseID : ";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.ForeColor = System.Drawing.Color.Maroon;
            this.lblAppFees.Location = new System.Drawing.Point(283, 139);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(30, 23);
            this.lblAppFees.TabIndex = 59;
            this.lblAppFees.Text = "??";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 23);
            this.label7.TabIndex = 58;
            this.label7.Text = "Application Fees :";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblAppDate.Location = new System.Drawing.Point(284, 95);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(30, 23);
            this.lblAppDate.TabIndex = 57;
            this.lblAppDate.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 23);
            this.label5.TabIndex = 56;
            this.label5.Text = "Application Date :";
            // 
            // lblReplaceAppID
            // 
            this.lblReplaceAppID.AutoSize = true;
            this.lblReplaceAppID.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceAppID.ForeColor = System.Drawing.Color.Maroon;
            this.lblReplaceAppID.Location = new System.Drawing.Point(284, 55);
            this.lblReplaceAppID.Name = "lblReplaceAppID";
            this.lblReplaceAppID.Size = new System.Drawing.Size(30, 23);
            this.lblReplaceAppID.TabIndex = 55;
            this.lblReplaceAppID.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 23);
            this.label3.TabIndex = 54;
            this.label3.Text = "L.R.ApplicationID : ";
            // 
            // ReplacementForLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 886);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctrFilterLicenseByIDAndShow1);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpReplacement);
            this.Name = "ReplacementForLostOrDamagedLicense";
            this.Text = "ReplacementForLostOrDamagedLicense";
            this.Activated += new System.EventHandler(this.ReplacementForLostOrDamagedLicense_Activated);
            this.Load += new System.EventHandler(this.ReplacementForLostOrDamagedLicense_Load);
            this.grpReplacement.ResumeLayout(false);
            this.grpReplacement.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpReplacement;
        private System.Windows.Forms.RadioButton rdbLost;
        private System.Windows.Forms.RadioButton rdbDamaged;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
        private ctrFilterLicenseByIDAndShow ctrFilterLicenseByIDAndShow1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblRePlacedLicenseID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReplaceAppID;
        private System.Windows.Forms.Label label3;
    }
}