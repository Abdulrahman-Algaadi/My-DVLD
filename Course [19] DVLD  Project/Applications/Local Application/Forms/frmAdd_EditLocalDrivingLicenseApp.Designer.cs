namespace Course__19__DVLD___Project
{
    partial class ClsAdd_UpdateLocalApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrShowPersonDetail1 = new Course__19__DVLD___Project.ctrShowPersonDetail();
            this.ctrFilterPerson_ADD1 = new Course__19__DVLD___Project.ctrFilterPerson_ADD();
            this.tbAppInfo = new System.Windows.Forms.TabPage();
            this.CreatedByUser = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDLAppID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.tbAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPersonInfo);
            this.tabControl1.Controls.Add(this.tbAppInfo);
            this.tabControl1.Location = new System.Drawing.Point(0, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.Controls.Add(this.btnNext);
            this.tbPersonInfo.Controls.Add(this.ctrShowPersonDetail1);
            this.tbPersonInfo.Controls.Add(this.ctrFilterPerson_ADD1);
            this.tbPersonInfo.Location = new System.Drawing.Point(4, 28);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(1039, 491);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Person Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(897, 441);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 47);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrShowPersonDetail1
            // 
            this.ctrShowPersonDetail1.Location = new System.Drawing.Point(27, 117);
            this.ctrShowPersonDetail1.Name = "ctrShowPersonDetail1";
            this.ctrShowPersonDetail1.PersonID = 0;
            this.ctrShowPersonDetail1.Size = new System.Drawing.Size(996, 314);
            this.ctrShowPersonDetail1.TabIndex = 1;
            // 
            // ctrFilterPerson_ADD1
            // 
            this.ctrFilterPerson_ADD1.FilterEnabled = true;
            this.ctrFilterPerson_ADD1.FilterTextBoxValue = "";
            this.ctrFilterPerson_ADD1.Location = new System.Drawing.Point(0, 0);
            this.ctrFilterPerson_ADD1.Name = "ctrFilterPerson_ADD1";
            this.ctrFilterPerson_ADD1.PersonID = 0;
            this.ctrFilterPerson_ADD1.ShowAddPerson = true;
            this.ctrFilterPerson_ADD1.Size = new System.Drawing.Size(1043, 111);
            this.ctrFilterPerson_ADD1.TabIndex = 0;
            // 
            // tbAppInfo
            // 
            this.tbAppInfo.Controls.Add(this.CreatedByUser);
            this.tbAppInfo.Controls.Add(this.cbLicenseClass);
            this.tbAppInfo.Controls.Add(this.lblAppFees);
            this.tbAppInfo.Controls.Add(this.lblAppDate);
            this.tbAppInfo.Controls.Add(this.label10);
            this.tbAppInfo.Controls.Add(this.label8);
            this.tbAppInfo.Controls.Add(this.label5);
            this.tbAppInfo.Controls.Add(this.label6);
            this.tbAppInfo.Controls.Add(this.label4);
            this.tbAppInfo.Controls.Add(this.lblDLAppID);
            this.tbAppInfo.Controls.Add(this.label2);
            this.tbAppInfo.Location = new System.Drawing.Point(4, 28);
            this.tbAppInfo.Name = "tbAppInfo";
            this.tbAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbAppInfo.Size = new System.Drawing.Size(1039, 491);
            this.tbAppInfo.TabIndex = 1;
            this.tbAppInfo.Text = "Application Info";
            this.tbAppInfo.UseVisualStyleBackColor = true;
            // 
            // CreatedByUser
            // 
            this.CreatedByUser.AutoSize = true;
            this.CreatedByUser.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatedByUser.Location = new System.Drawing.Point(256, 326);
            this.CreatedByUser.Name = "CreatedByUser";
            this.CreatedByUser.Size = new System.Drawing.Size(0, 20);
            this.CreatedByUser.TabIndex = 14;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(260, 204);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(274, 27);
            this.cbLicenseClass.TabIndex = 13;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(254, 264);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(0, 20);
            this.lblAppFees.TabIndex = 11;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(254, 143);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(0, 20);
            this.lblAppDate.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(60, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Created By : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Application Fees : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "License Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Application Date : ";
            // 
            // lblDLAppID
            // 
            this.lblDLAppID.AutoSize = true;
            this.lblDLAppID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLAppID.Location = new System.Drawing.Point(254, 84);
            this.lblDLAppID.Name = "lblDLAppID";
            this.lblDLAppID.Size = new System.Drawing.Size(36, 20);
            this.lblDLAppID.TabIndex = 1;
            this.lblDLAppID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L.Application ID : ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(763, 632);
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
            this.btnSave.Location = new System.Drawing.Point(917, 632);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(256, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(488, 32);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "New Local Driving License Application ";
            // 
            // ClsAdd_UpdateLocalApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 691);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "ClsAdd_UpdateLocalApplication";
            this.Text = "ClsAdd_UpdateLocalApplication";
            this.Activated += new System.EventHandler(this.ClsAdd_UpdateLocalApplication_Activated);
            this.Load += new System.EventHandler(this.ClsAdd_UpdateLocalApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbPersonInfo.ResumeLayout(false);
            this.tbAppInfo.ResumeLayout(false);
            this.tbAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private ctrShowPersonDetail ctrShowPersonDetail1;
        private ctrFilterPerson_ADD ctrFilterPerson_ADD1;
        private System.Windows.Forms.TabPage tbAppInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDLAppID;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CreatedByUser;
    }
}