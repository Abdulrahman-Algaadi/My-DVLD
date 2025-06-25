namespace Course__19__DVLD___Project
{
    partial class ShowLicenseData
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
            this.ctrShowLicenseInfo1 = new Course__19__DVLD___Project.ctrShowLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrShowLicenseInfo1
            // 
            this.ctrShowLicenseInfo1.LocalDrivingLicenseAppID = 0;
            this.ctrShowLicenseInfo1.Location = new System.Drawing.Point(12, 2);
            this.ctrShowLicenseInfo1.Name = "ctrShowLicenseInfo1";
            this.ctrShowLicenseInfo1.Size = new System.Drawing.Size(1016, 611);
            this.ctrShowLicenseInfo1.TabIndex = 0;
            // 
            // ShowLicenseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 625);
            this.Controls.Add(this.ctrShowLicenseInfo1);
            this.Name = "ShowLicenseData";
            this.Text = "ShowLicenseData";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrShowLicenseInfo ctrShowLicenseInfo1;
    }
}