namespace Course__19__DVLD___Project
{
    partial class Add_Person_EditForm
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
            this.ctrAddNewPerson1 = new Course__19__DVLD___Project.ctrAddNewPerson();
            this.ctrAddNewPerson2 = new Course__19__DVLD___Project.ctrAddNewPerson();
            this.SuspendLayout();
            // 
            // ctrAddNewPerson1
            // 
            this.ctrAddNewPerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrAddNewPerson1.Name = "ctrAddNewPerson1";
            this.ctrAddNewPerson1.PersonID = 0;
            this.ctrAddNewPerson1.Size = new System.Drawing.Size(1020, 550);
            this.ctrAddNewPerson1.TabIndex = 0;
            // 
            // ctrAddNewPerson2
            // 
            this.ctrAddNewPerson2.Location = new System.Drawing.Point(0, -2);
            this.ctrAddNewPerson2.Name = "ctrAddNewPerson2";
            this.ctrAddNewPerson2.PersonID = 0;
            this.ctrAddNewPerson2.Size = new System.Drawing.Size(1021, 552);
            this.ctrAddNewPerson2.TabIndex = 0;
            this.ctrAddNewPerson2.Load += new System.EventHandler(this.ctrAddNewPerson2_Load);
            // 
            // Add_EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 552);
            this.Controls.Add(this.ctrAddNewPerson2);
            this.Name = "Add_EditForm";
            this.Text = "Add_EditForm";
            this.Load += new System.EventHandler(this.Add_EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrAddNewPerson ctrAddNewPerson1;
        private ctrAddNewPerson ctrAddNewPerson2;
    }
}