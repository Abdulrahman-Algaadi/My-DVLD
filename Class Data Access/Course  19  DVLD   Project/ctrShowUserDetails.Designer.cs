namespace Course__19__DVLD___Project
{
    partial class ctrShowUserDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpUserLogIn = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrShowPersonDetail2 = new Course__19__DVLD___Project.ctrShowPersonDetail();
            this.grpUserLogIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUserLogIn
            // 
            this.grpUserLogIn.Controls.Add(this.lblIsActive);
            this.grpUserLogIn.Controls.Add(this.label5);
            this.grpUserLogIn.Controls.Add(this.lblUserName);
            this.grpUserLogIn.Controls.Add(this.label3);
            this.grpUserLogIn.Controls.Add(this.lblUserID);
            this.grpUserLogIn.Controls.Add(this.label1);
            this.grpUserLogIn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserLogIn.Location = new System.Drawing.Point(20, 373);
            this.grpUserLogIn.Name = "grpUserLogIn";
            this.grpUserLogIn.Size = new System.Drawing.Size(916, 100);
            this.grpUserLogIn.TabIndex = 1;
            this.grpUserLogIn.TabStop = false;
            this.grpUserLogIn.Text = "Log In Info";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.ForeColor = System.Drawing.Color.Red;
            this.lblIsActive.Location = new System.Drawing.Point(693, 47);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(36, 20);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(583, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Is Active :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.Red;
            this.lblUserName.Location = new System.Drawing.Point(410, 47);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(36, 20);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "UserName : ";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.ForeColor = System.Drawing.Color.Red;
            this.lblUserID.Location = new System.Drawing.Point(117, 47);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(36, 20);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID : ";
            // 
            // ctrShowPersonDetail2
            // 
            this.ctrShowPersonDetail2.Location = new System.Drawing.Point(-14, 18);
            this.ctrShowPersonDetail2.Name = "ctrShowPersonDetail2";
            this.ctrShowPersonDetail2.PersonID = -1;
            this.ctrShowPersonDetail2.Size = new System.Drawing.Size(950, 315);
            this.ctrShowPersonDetail2.TabIndex = 2;
            // 
            // ctrShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrShowPersonDetail2);
            this.Controls.Add(this.grpUserLogIn);
            this.Name = "ctrShowUserDetails";
            this.Size = new System.Drawing.Size(961, 495);
            this.Load += new System.EventHandler(this.ctrShowUserDetails_Load);
            this.grpUserLogIn.ResumeLayout(false);
            this.grpUserLogIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrShowPersonDetail ctrShowPersonDetail1;
        private System.Windows.Forms.GroupBox grpUserLogIn;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private ctrShowPersonDetail ctrShowPersonDetail2;
    }
}
