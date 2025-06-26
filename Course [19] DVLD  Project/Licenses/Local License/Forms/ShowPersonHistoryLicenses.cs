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
    public partial class ShowPersonHistoryLicenses : Form
    {
        int _PersonID = -1;
        public ShowPersonHistoryLicenses(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

        }

        private void _LoadLicensesData()
        {
            if (_PersonID!=-1)
            {

                dgvLocalLicense.DataSource = clsLicense.GetAllLocalLicense(_PersonID);
                lblRecords.Text = $"# Records : {dgvLocalLicense.RowCount}";

                dgvLicenseHistory.DataSource = clsInternationalLicense.GetAllInternationalLicenses(_PersonID);
                lblInterRecords.Text = $"# Records {dgvLicenseHistory.RowCount}";
                ctrFilterPerson_ADD1.Enabled = false;
                ctrFilterPerson_ADD1.PersonID = _PersonID;
                ctrShowPersonDetail1.PersonID = _PersonID;
           
            }
            else
            {
                ctrShowPersonDetail1.Enabled = true;
                ctrShowPersonDetail1.Focus();
            }


        }   
     
        private void ShowPersonHistoryLicenses_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Local";
            tabPage2.Text = "InterNational";
            _LoadLicensesData();
            this.AutoSize = true;
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID((int)dgvLocalLicense.CurrentRow.Cells[1].Value);
            Form frm =new frmShowLocalApplicationDetail(_Local.LocalDrivingLicenseAppID);
          frm.ShowDialog();


        }
    }
}
