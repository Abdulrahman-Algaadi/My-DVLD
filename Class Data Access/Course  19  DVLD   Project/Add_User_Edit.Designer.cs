namespace Course__19__DVLD___Project
{
    partial class Add_User_Edit
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrShowPersonDetail1 = new Course__19__DVLD___Project.ctrShowPersonDetail();
            this.ctrFilterPerson_ADD1 = new Course__19__DVLD___Project.ctrFilterPerson_ADD();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkIsActive = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1079, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ctrShowPersonDetail1);
            this.tabPage1.Controls.Add(this.ctrFilterPerson_ADD1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1071, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(892, 444);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 47);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrShowPersonDetail1
            // 
            this.ctrShowPersonDetail1.Location = new System.Drawing.Point(48, 104);
            this.ctrShowPersonDetail1.Name = "ctrShowPersonDetail1";
            this.ctrShowPersonDetail1.PersonID = -1;
            this.ctrShowPersonDetail1.Size = new System.Drawing.Size(970, 334);
            this.ctrShowPersonDetail1.TabIndex = 1;
            // 
            // ctrFilterPerson_ADD1
            // 
            this.ctrFilterPerson_ADD1.Location = new System.Drawing.Point(22, -13);
            this.ctrFilterPerson_ADD1.Name = "ctrFilterPerson_ADD1";
            this.ctrFilterPerson_ADD1.PersonID = 0;
            this.ctrFilterPerson_ADD1.Size = new System.Drawing.Size(1043, 111);
            this.ctrFilterPerson_ADD1.TabIndex = 0;
            this.ctrFilterPerson_ADD1.Load += new System.EventHandler(this.ctrFilterPerson_ADD1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkIsActive);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lblUserID);
            this.tabPage2.Controls.Add(this.txtPasswordConfirm);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Controls.Add(this.txtUserName);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1071, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.chkIsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.chkIsActive.CheckedState.Parent = this.chkIsActive;
            this.chkIsActive.Location = new System.Drawing.Point(237, 299);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.ShadowDecoration.Parent = this.chkIsActive;
            this.chkIsActive.Size = new System.Drawing.Size(35, 20);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.chkIsActive.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.chkIsActive.UncheckedState.Parent = this.chkIsActive;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "IsActive : ";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblUserID.Location = new System.Drawing.Point(270, 80);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(33, 19);
            this.lblUserID.TabIndex = 12;
            this.lblUserID.Text = "???";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(274, 237);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(183, 27);
            this.txtPasswordConfirm.TabIndex = 11;
            this.txtPasswordConfirm.TextChanged += new System.EventHandler(this.txtPasswordConfirm_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(274, 186);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(183, 27);
            this.txtPassword.TabIndex = 10;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(274, 127);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(183, 27);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label8
            // 
            this.label8.Image = global::Course__19__DVLD___Project.Properties.Resources.password;
            this.label8.Location = new System.Drawing.Point(207, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 41);
            this.label8.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Image = global::Course__19__DVLD___Project.Properties.Resources.password;
            this.label7.Location = new System.Drawing.Point(207, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 41);
            this.label7.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Image = global::Course__19__DVLD___Project.Properties.Resources.user__1_1;
            this.label6.Location = new System.Drawing.Point(207, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 41);
            this.label6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Image = global::Course__19__DVLD___Project.Properties.Resources.id__1_;
            this.label5.Location = new System.Drawing.Point(207, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 41);
            this.label5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm PassWord : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "PassWord : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblAdd.Location = new System.Drawing.Point(398, 25);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(241, 41);
            this.lblAdd.TabIndex = 1;
            this.lblAdd.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(813, 642);
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
            this.btnSave.Location = new System.Drawing.Point(965, 642);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Add_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 701);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.tabControl1);
            this.Name = "Add_User";
            this.Text = "Add_User";
            this.Load += new System.EventHandler(this.Add_User_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ctrFilterPerson_ADD ctrFilterPerson_ADD1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAdd;
        private ctrShowPersonDetail ctrShowPersonDetail1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ToggleSwitch chkIsActive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}