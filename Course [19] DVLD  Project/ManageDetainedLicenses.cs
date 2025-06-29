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
    public partial class ManageDetainedLicenses : Form
    {
      
        int _PersonID = -1;
        private static DataTable _DetainedLicense;

        public ManageDetainedLicenses()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new DetainLicenseScreen();
            frm.ShowDialog();
        }
        private void _LoadData()
        {
            dgvDetainedLicenses.DataSource = clsDetainedLicense.GetAllDetainedLicense();
            lblRecord.Text = $"# Records : {dgvDetainedLicenses.RowCount}";
        }



        private void ManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            cbFilter.SelectedIndex = 0;
            _DetainedLicense = clsDetainedLicense.GetAllDetainedLicense();
            dgvDetainedLicenses.DataSource = _DetainedLicense;

            _PersonID = clsLicense.FindLicenseByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmShowPersonInfo(_PersonID);
            frm.ShowDialog();
            ManageDetainedLicenses_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            ManageDetainedLicenses_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Release_Detained_License();
            form.ShowDialog();
        }

        private void showPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(_PersonID);
            frm.ShowDialog();
            ManageDetainedLicenses_Load(null, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex==0)
            {
                txtFilter.Visible=false;
            }
            else
            {
                txtFilter.Visible=true;
                txtFilter.Focus();
            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            string ColumnName = "", FilterBy = "";
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    ColumnName = "DetainID";
                
                    break;

                case 2:
                    ColumnName = "LicenseID";
                   
                    break;

                case 3:

                    ColumnName = "IsReleased";
                  
                    break;

                case 4:
                    ColumnName = "NationalNo";
                  
                    break;

                case 5:
                    ColumnName = "FullName";
                  
                    break;

                case 6:
                    ColumnName = "ReleaseApplicationID";
           
                    break;
                  
            }
            FilterBy = txtFilter.Text;
            if (string.IsNullOrEmpty(FilterBy)||cbFilter.SelectedIndex==0)
            {
                _DetainedLicense.DefaultView.RowFilter = "";
                lblRecord.Text = "# Records : "+_DetainedLicense.Rows.Count.ToString();
                return;
            }
            if (cbFilter.SelectedIndex==1||cbFilter.SelectedIndex==2||cbFilter.SelectedIndex==6)
            {
                _DetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}",ColumnName,FilterBy);
            }
            else
            {
                _DetainedLicense.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterBy);
            }
            lblRecord.Text = "# Records : " + _DetainedLicense.Rows.Count.ToString();
        }

        private void releaceLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Release_Detained_License((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            ManageDetainedLicenses_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaceLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }
    }
}
