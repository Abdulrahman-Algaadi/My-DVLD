using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ManageTestTypes : Form
    {
        public ManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshTestTypes()
        {
            dgvTestTypes.DataSource = clsApplicationTest.GetAllTests();
            lblRecord.Text = $"# Records : {dgvTestTypes.RowCount}";
        }
        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypes();
        }

     
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Update_TestTypes((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypes();
        }
    }
}
