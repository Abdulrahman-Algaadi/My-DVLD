namespace Course__19__DVLD___Project
{
    partial class ShowDetailForm
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
            this.ctrShowPersonDetail1 = new Course__19__DVLD___Project.ctrShowPersonDetail();
            this.SuspendLayout();
            // 
            // ctrShowPersonDetail1
            // 
            this.ctrShowPersonDetail1.Location = new System.Drawing.Point(12, 12);
            this.ctrShowPersonDetail1.Name = "ctrShowPersonDetail1";
            this.ctrShowPersonDetail1.PersonID = 0;
            this.ctrShowPersonDetail1.Size = new System.Drawing.Size(980, 399);
            this.ctrShowPersonDetail1.TabIndex = 0;
            // 
            // ShowDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 423);
            this.Controls.Add(this.ctrShowPersonDetail1);
            this.Name = "ShowDetailForm";
            this.Text = "Show Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrShowPersonDetail ctrShowPersonDetail1;
    }
}