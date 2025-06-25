using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesData();
        }
        private void _RefreshApplicationTypesData()
        {
            dgvApplicationTypes.DataSource =clsApplicationTypes.GetAllApplicationTypes();
            lblRecords.Text = $"# Records : {dgvApplicationTypes.RowCount}";
        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm =new UpdateApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesData();
        }

    
    }
}
