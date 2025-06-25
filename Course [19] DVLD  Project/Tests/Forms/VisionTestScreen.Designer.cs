namespace Course__19__DVLD___Project
{
    partial class TestScreens
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
            this.lblTestName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeATestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBumberOfAppointments = new System.Windows.Forms.Label();
            this.ctrLALAndApplicationDaetails1 = new Course__19__DVLD___Project.ctrLALAndApplicationDaetails();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.ForeColor = System.Drawing.Color.Red;
            this.lblTestName.Location = new System.Drawing.Point(315, 118);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(352, 36);
            this.lblTestName.TabIndex = 2;
            this.lblTestName.Text = "Vision Test Appointment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Appointments : ";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointments.Location = new System.Drawing.Point(55, 626);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 62;
            this.dgvAppointments.RowTemplate.Height = 29;
            this.dgvAppointments.Size = new System.Drawing.Size(931, 166);
            this.dgvAppointments.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppointmentToolStripMenuItem,
            this.takeATestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(278, 64);
            // 
            // editAppointmentToolStripMenuItem
            // 
            this.editAppointmentToolStripMenuItem.Font = new System.Drawing.Font("Algerian", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAppointmentToolStripMenuItem.Name = "editAppointmentToolStripMenuItem";
            this.editAppointmentToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.editAppointmentToolStripMenuItem.Text = "Edit Appointment";
            this.editAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editAppointmentToolStripMenuItem_Click);
            // 
            // takeATestToolStripMenuItem
            // 
            this.takeATestToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeATestToolStripMenuItem.Name = "takeATestToolStripMenuItem";
            this.takeATestToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.takeATestToolStripMenuItem.Text = "Take a Test";
            this.takeATestToolStripMenuItem.Click += new System.EventHandler(this.takeATestToolStripMenuItem_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Image = global::Course__19__DVLD___Project.Properties.Resources.eye__2_;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(917, 571);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(59, 49);
            this.btnAddNewAppointment.TabIndex = 5;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // label1
            // 
            this.label1.Image = global::Course__19__DVLD___Project.Properties.Resources.eye;
            this.label1.Location = new System.Drawing.Point(423, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 95);
            this.label1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(863, 813);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBumberOfAppointments
            // 
            this.lblBumberOfAppointments.AutoSize = true;
            this.lblBumberOfAppointments.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBumberOfAppointments.ForeColor = System.Drawing.Color.Red;
            this.lblBumberOfAppointments.Location = new System.Drawing.Point(50, 834);
            this.lblBumberOfAppointments.Name = "lblBumberOfAppointments";
            this.lblBumberOfAppointments.Size = new System.Drawing.Size(0, 26);
            this.lblBumberOfAppointments.TabIndex = 8;
            // 
            // ctrLALAndApplicationDaetails1
            // 
            this.ctrLALAndApplicationDaetails1.Location = new System.Drawing.Point(12, 166);
            this.ctrLALAndApplicationDaetails1.Name = "ctrLALAndApplicationDaetails1";
            this.ctrLALAndApplicationDaetails1.Size = new System.Drawing.Size(977, 394);
            this.ctrLALAndApplicationDaetails1.TabIndex = 0;
            // 
            // TestScreens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 882);
            this.Controls.Add(this.lblBumberOfAppointments);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrLALAndApplicationDaetails1);
            this.Name = "TestScreens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestScreens";
            this.Load += new System.EventHandler(this.TestScreens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrLALAndApplicationDaetails ctrLALAndApplicationDaetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeATestToolStripMenuItem;
        private System.Windows.Forms.Label lblBumberOfAppointments;
    }
}