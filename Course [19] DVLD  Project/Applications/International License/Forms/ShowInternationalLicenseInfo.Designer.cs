namespace Course__19__DVLD___Project
{
    partial class ShowInternationalLicenseInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrShowInternationalLicense1 = new Course__19__DVLD___Project.ctrShowInternationalLicense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver International License Info";
            // 
            // label2
            // 
            this.label2.Image = global::Course__19__DVLD___Project.Properties.Resources.driver;
            this.label2.Location = new System.Drawing.Point(386, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 100);
            this.label2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(767, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrShowInternationalLicense1
            // 
            this.ctrShowInternationalLicense1.InternationalLicenseID = 0;
            this.ctrShowInternationalLicense1.Location = new System.Drawing.Point(45, 185);
            this.ctrShowInternationalLicense1.Name = "ctrShowInternationalLicense1";
            this.ctrShowInternationalLicense1.Size = new System.Drawing.Size(870, 351);
            this.ctrShowInternationalLicense1.TabIndex = 2;
            // 
            // ShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 604);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrShowInternationalLicense1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShowInternationalLicenseInfo";
            this.Text = "ShowInternationalLicenseInfo";
            this.Load += new System.EventHandler(this.ShowInternationalLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ctrShowInternationalLicense ctrShowInternationalLicense1;
        private System.Windows.Forms.Button btnClose;
    }
}