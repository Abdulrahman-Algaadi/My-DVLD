namespace Course__19__DVLD___Project
{
    partial class frmManageLocalDrivingLicenseApplication
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
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheualTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.AllowUserToOrderColumns = true;
            this.dgvApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvApplications.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplications.Location = new System.Drawing.Point(12, 248);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 62;
            this.dgvApplications.RowTemplate.Height = 29;
            this.dgvApplications.Size = new System.Drawing.Size(1524, 375);
            this.dgvApplications.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scheualTestToolStripMenuItem,
            this.issueLicenseToolStripMenuItem,
            this.showLicenseInfoToolStripMenuItem,
            this.showPersonHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(282, 293);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheualTestToolStripMenuItem
            // 
            this.scheualTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.drivingTestToolStripMenuItem});
            this.scheualTestToolStripMenuItem.Name = "scheualTestToolStripMenuItem";
            this.scheualTestToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.scheualTestToolStripMenuItem.Text = "Scheual Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.writtenTestToolStripMenuItem.Text = "Written Test";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // drivingTestToolStripMenuItem
            // 
            this.drivingTestToolStripMenuItem.Name = "drivingTestToolStripMenuItem";
            this.drivingTestToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.drivingTestToolStripMenuItem.Text = "Driving Test";
            this.drivingTestToolStripMenuItem.Click += new System.EventHandler(this.drivingTestToolStripMenuItem_Click);
            // 
            // issueLicenseToolStripMenuItem
            // 
            this.issueLicenseToolStripMenuItem.Name = "issueLicenseToolStripMenuItem";
            this.issueLicenseToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.issueLicenseToolStripMenuItem.Text = "Issue License";
            this.issueLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueLicenseToolStripMenuItem_Click);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // showPersonHistoryToolStripMenuItem
            // 
            this.showPersonHistoryToolStripMenuItem.Name = "showPersonHistoryToolStripMenuItem";
            this.showPersonHistoryToolStripMenuItem.Size = new System.Drawing.Size(281, 32);
            this.showPersonHistoryToolStripMenuItem.Text = "Show Person History";
            this.showPersonHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(552, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Application";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.Green;
            this.lblRecords.Location = new System.Drawing.Point(39, 638);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(0, 25);
            this.lblRecords.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Find By : ";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFilter.Location = new System.Drawing.Point(281, 196);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(223, 26);
            this.txtFilter.TabIndex = 26;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(129, 196);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(126, 27);
            this.cbFilter.TabIndex = 27;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1410, 629);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Image = global::Course__19__DVLD___Project.Properties.Resources.users_add__1_;
            this.btnAddNewUser.Location = new System.Drawing.Point(1440, 157);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(96, 85);
            this.btnAddNewUser.TabIndex = 22;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // label2
            // 
            this.label2.Image = global::Course__19__DVLD___Project.Properties.Resources.our_process1;
            this.label2.Location = new System.Drawing.Point(685, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 140);
            this.label2.TabIndex = 2;
            // 
            // frmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 691);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmManageLocalDrivingLicenseApplication";
            this.Text = "frmManageLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheualTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonHistoryToolStripMenuItem;
    }
}