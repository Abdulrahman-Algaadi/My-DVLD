namespace Course__19__DVLD___Project
{
    partial class ShowPersonHistoryLicenses
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRecords = new System.Windows.Forms.Label();
            this.dgvLocalLicense = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblInterRecords = new System.Windows.Forms.Label();
            this.dgvLicenseHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrShowPersonDetail1 = new Course__19__DVLD___Project.ctrShowPersonDetail();
            this.ctrFilterPerson_ADD1 = new Course__19__DVLD___Project.ctrFilterPerson_ADD();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicense)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1158, 359);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1126, 282);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRecords);
            this.tabPage1.Controls.Add(this.dgvLocalLicense);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1118, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(19, 220);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(0, 20);
            this.lblRecords.TabIndex = 2;
            // 
            // dgvLocalLicense
            // 
            this.dgvLocalLicense.AllowUserToAddRows = false;
            this.dgvLocalLicense.AllowUserToDeleteRows = false;
            this.dgvLocalLicense.AllowUserToOrderColumns = true;
            this.dgvLocalLicense.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLicense.Location = new System.Drawing.Point(6, 12);
            this.dgvLocalLicense.Name = "dgvLocalLicense";
            this.dgvLocalLicense.ReadOnly = true;
            this.dgvLocalLicense.RowHeadersWidth = 62;
            this.dgvLocalLicense.RowTemplate.Height = 29;
            this.dgvLocalLicense.Size = new System.Drawing.Size(1106, 205);
            this.dgvLocalLicense.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblInterRecords);
            this.tabPage2.Controls.Add(this.dgvLicenseHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1118, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // lblInterRecords
            // 
            this.lblInterRecords.AutoSize = true;
            this.lblInterRecords.Location = new System.Drawing.Point(21, 220);
            this.lblInterRecords.Name = "lblInterRecords";
            this.lblInterRecords.Size = new System.Drawing.Size(0, 20);
            this.lblInterRecords.TabIndex = 1;
            // 
            // dgvLicenseHistory
            // 
            this.dgvLicenseHistory.AllowUserToAddRows = false;
            this.dgvLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvLicenseHistory.AllowUserToOrderColumns = true;
            this.dgvLicenseHistory.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseHistory.Location = new System.Drawing.Point(3, 0);
            this.dgvLicenseHistory.Name = "dgvLicenseHistory";
            this.dgvLicenseHistory.ReadOnly = true;
            this.dgvLicenseHistory.RowHeadersWidth = 62;
            this.dgvLicenseHistory.RowTemplate.Height = 29;
            this.dgvLicenseHistory.Size = new System.Drawing.Size(1106, 211);
            this.dgvLicenseHistory.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1067, 881);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrShowPersonDetail1
            // 
            this.ctrShowPersonDetail1.Location = new System.Drawing.Point(219, 175);
            this.ctrShowPersonDetail1.Name = "ctrShowPersonDetail1";
            this.ctrShowPersonDetail1.PersonID = 0;
            this.ctrShowPersonDetail1.Size = new System.Drawing.Size(974, 335);
            this.ctrShowPersonDetail1.TabIndex = 1;
            // 
            // ctrFilterPerson_ADD1
            // 
            this.ctrFilterPerson_ADD1.FilterTextBoxValue = "";
            this.ctrFilterPerson_ADD1.Location = new System.Drawing.Point(219, 37);
            this.ctrFilterPerson_ADD1.Name = "ctrFilterPerson_ADD1";
            this.ctrFilterPerson_ADD1.PersonID = 0;
            this.ctrFilterPerson_ADD1.Size = new System.Drawing.Size(974, 111);
            this.ctrFilterPerson_ADD1.TabIndex = 0;
            this.ctrFilterPerson_ADD1.Load += new System.EventHandler(this.ctrFilterPerson_ADD1_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 36);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.showToolStripMenuItem.Text = "Show License Info";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // ShowPersonHistoryLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 939);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrShowPersonDetail1);
            this.Controls.Add(this.ctrFilterPerson_ADD1);
            this.Name = "ShowPersonHistoryLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowPersonHistoryLicenses";
            this.Load += new System.EventHandler(this.ShowPersonHistoryLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicense)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrFilterPerson_ADD ctrFilterPerson_ADD1;
        private ctrShowPersonDetail ctrShowPersonDetail1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvLicenseHistory;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblInterRecords;
        private System.Windows.Forms.DataGridView dgvLocalLicense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}