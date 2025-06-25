namespace Course__19__DVLD___Project
{
    partial class ManagePeople
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchByFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.lblCountRecord = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagePeople.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.Location = new System.Drawing.Point(590, 118);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(199, 34);
            this.lblManagePeople.TabIndex = 0;
            this.lblManagePeople.Text = "Manage People";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowDrop = true;
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPeople.Location = new System.Drawing.Point(37, 216);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPeople.RowHeadersWidth = 62;
            this.dgvPeople.RowTemplate.Height = 29;
            this.dgvPeople.Size = new System.Drawing.Size(1431, 243);
            this.dgvPeople.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.editPersonToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 132);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDetailsToolStripMenuItem.Image = global::Course__19__DVLD___Project.Properties.Resources.view_detail;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewPersonToolStripMenuItem.Image = global::Course__19__DVLD___Project.Properties.Resources.user__1_1;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editPersonToolStripMenuItem
            // 
            this.editPersonToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPersonToolStripMenuItem.Image = global::Course__19__DVLD___Project.Properties.Resources.person_man__5_;
            this.editPersonToolStripMenuItem.Name = "editPersonToolStripMenuItem";
            this.editPersonToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.editPersonToolStripMenuItem.Text = "Edit";
            this.editPersonToolStripMenuItem.Click += new System.EventHandler(this.editPersonToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.Image = global::Course__19__DVLD___Project.Properties.Resources.person_man__6_;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter By ";
            // 
            // txtSearchByFilter
            // 
            this.txtSearchByFilter.Location = new System.Drawing.Point(262, 177);
            this.txtSearchByFilter.Name = "txtSearchByFilter";
            this.txtSearchByFilter.Size = new System.Drawing.Size(253, 27);
            this.txtSearchByFilter.TabIndex = 5;
            this.txtSearchByFilter.TextChanged += new System.EventHandler(this.txtSearchByFilter_TextChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Person_ID",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "National_No",
            "Nationality",
            "Email",
            "Phone",
            "Gendor"});
            this.cbFilter.Location = new System.Drawing.Point(123, 177);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 27);
            this.cbFilter.TabIndex = 6;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lblCountRecord
            // 
            this.lblCountRecord.AutoSize = true;
            this.lblCountRecord.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecord.Location = new System.Drawing.Point(53, 475);
            this.lblCountRecord.Name = "lblCountRecord";
            this.lblCountRecord.Size = new System.Drawing.Size(0, 23);
            this.lblCountRecord.TabIndex = 9;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::Course__19__DVLD___Project.Properties.Resources.person_man__1_2;
            this.btnAddNew.Location = new System.Drawing.Point(1352, 134);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(92, 70);
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1249, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "  Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course__19__DVLD___Project.Properties.Resources.systems_engineer;
            this.pictureBox1.Location = new System.Drawing.Point(645, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 515);
            this.Controls.Add(this.lblCountRecord);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearchByFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblManagePeople);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManagePeople";
            this.Load += new System.EventHandler(this.ManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchByFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblCountRecord;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}