namespace Course__19__DVLD___Project
{
    partial class ManageTestTypes
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(191, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage Application Types";
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.AllowUserToAddRows = false;
            this.dgvTestTypes.AllowUserToDeleteRows = false;
            this.dgvTestTypes.AllowUserToOrderColumns = true;
            this.dgvTestTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTestTypes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTestTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTestTypes.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTestTypes.Location = new System.Drawing.Point(37, 194);
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.ReadOnly = true;
            this.dgvTestTypes.RowHeadersWidth = 62;
            this.dgvTestTypes.RowTemplate.Height = 29;
            this.dgvTestTypes.Size = new System.Drawing.Size(704, 146);
            this.dgvTestTypes.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 36);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upToolStripMenuItem.Image = global::Course__19__DVLD___Project.Properties.Resources.white_list1;
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(198, 32);
            this.upToolStripMenuItem.Text = "Update Test";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Course__19__DVLD___Project.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(603, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Image = global::Course__19__DVLD___Project.Properties.Resources.white_list__1_;
            this.label2.Location = new System.Drawing.Point(286, -6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 145);
            this.label2.TabIndex = 3;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Red;
            this.lblRecord.Location = new System.Drawing.Point(33, 386);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(0, 23);
            this.lblRecord.TabIndex = 10;
            // 
            // ManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 424);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageTestTypes";
            this.Text = "ManageTestTypes";
            this.Load += new System.EventHandler(this.ManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTestTypes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.Label lblRecord;
    }
}