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
    public partial class DriversScreen : Form
    {
        public DriversScreen()
        {
            InitializeComponent();
        }
        public static DataTable _dtDriver;
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex==0)
            {
                txtFilter.Visible=false;
            }else
                txtFilter.Visible=true;
        }
        
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            int SelectedIndex = cbFilter.SelectedIndex;
            string ColName = "";
            string FilterWith="";
            switch (SelectedIndex)
            {
                case 1:
                    ColName = "DriverID";

            break;

                case 2:
                    ColName = "PersonID";

                    break;



                case 3:
                    ColName = "NationalNo";
   
                    break;


                case 4:
                    ColName = "FullName";
                 
                    break;
            }
            FilterWith = txtFilter.Text;

            if (FilterWith==""|| cbFilter.SelectedIndex == 0)
            {
                _dtDriver.DefaultView.RowFilter = "";
                lblRecords.Text = $"# Records{_dtDriver.Rows.Count}";
                return;
            }

            if ((cbFilter.SelectedIndex==1||cbFilter.SelectedIndex==2))
                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] = {1}",ColName,FilterWith);
            else
                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColName, FilterWith);

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1||cbFilter.SelectedIndex==2)
            {


                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the key press
                }
            }
        }

        private void DriversScreen_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            this.AutoSize = true;
            _dtDriver = clsDriver.GetAllDrivers();
         
            dgvDrivers.DataSource = _dtDriver;
            lblRecords.Text = $"# Records{dgvDrivers.RowCount}";
        }

        private void showPerosnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            DriversScreen_Load(null,null);
        }

        private void showLicensePersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonHistoryLicenses f = new ShowPersonHistoryLicenses((int)dgvDrivers.CurrentRow.Cells[1].Value);
            f.ShowDialog();
            DriversScreen_Load(null,null);
        }
    }
}
