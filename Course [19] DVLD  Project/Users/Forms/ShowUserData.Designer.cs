namespace Course__19__DVLD___Project
{
    partial class ShowUserData
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
            this.ctrShowUserDetails1 = new Course__19__DVLD___Project.ctrShowUserDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrShowUserDetails1
            // 
            this.ctrShowUserDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrShowUserDetails1.Name = "ctrShowUserDetails1";
         
            this.ctrShowUserDetails1.Size = new System.Drawing.Size(961, 495);
            this.ctrShowUserDetails1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(824, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 58);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ShowUserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 554);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrShowUserDetails1);
            this.Name = "ShowUserData";
            this.Text = "ShowUserData";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrShowUserDetails ctrShowUserDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}