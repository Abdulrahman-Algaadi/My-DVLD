namespace Course__19__DVLD___Project
{
    partial class Schdule_Edit
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrScheduleTest1 = new Course__19__DVLD___Project.ctrScheduleTest();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(239, 693);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrScheduleTest1
            // 
            this.ctrScheduleTest1.Location = new System.Drawing.Point(0, 0);
            this.ctrScheduleTest1.Name = "ctrScheduleTest1";
            this.ctrScheduleTest1.Size = new System.Drawing.Size(609, 687);
            this.ctrScheduleTest1.TabIndex = 0;
            this.ctrScheduleTest1.TestTypeID = clsLogic.clsTestTypes.enTestType.VisionTest;
            // 
            // Schdule_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 764);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrScheduleTest1);
            this.Name = "Schdule_Edit";
            this.Text = "Schdule_Edit";
            this.Load += new System.EventHandler(this.Schdule_Edit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrScheduleTest ctrScheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}