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
    public partial class ManageInternationalLicense : Form
    {
        clsUser _User;
        public ManageInternationalLicense(clsUser User)
        {
            InitializeComponent();
            _User = User;
        }

        private void ManageInternationalLicense_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            _GetAllInternationalLicense();
        }

       private void  _GetAllInternationalLicense()
        {
            dgvInternational.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            lblRecord.Text = $"# Records : {dgvInternational.RowCount}";
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex==0)
            {
                txtFilter.Enabled = false;
            }
            else
            {
                txtFilter.Enabled = true;
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm =new InterNationalDrivingLicense(_User);
            frm.ShowDialog();
            _GetAllInternationalLicense();
        }

        private void showPersonDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications _Application = clsApplications.FindApplicationByApplicationID((int)dgvInternational.CurrentRow.Cells[1].Value);

            Form frm = new ShowDetailForm(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowInternationalLicenseInfo((int)dgvInternational.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense _Issued = clsLicense.FindLicenseByLicenseID((int)dgvInternational.CurrentRow.Cells[3].Value);

            clsLocalDrivingLicenseApplication _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_Issued.ApplicationID);
            
            Form frm = new ShowPersonHistoryLicenses(_Local.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColName = "",DataToSearchFor="";
            
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                ColName = "ApplicationID";
                DataToSearchFor = txtFilter.Text;
            break;
                    case 2:
                    ColName = "InternationalLicenseID";
                    DataToSearchFor = txtFilter.Text; break;
                    case 3:
                    ColName = "DriverID";
                    DataToSearchFor = txtFilter.Text;break;

            }

            dgvInternational.DataSource = clsInternationalLicense.FilterDataBy(ColName,DataToSearchFor);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
