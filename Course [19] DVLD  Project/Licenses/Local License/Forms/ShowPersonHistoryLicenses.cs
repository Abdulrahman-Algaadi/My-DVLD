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
        clsLocalDrivingLicenseApplication _Local;
        public int LocalID { get; set; }
        clsApplications _Application;
        clsLicenseClass _Lisences;
        clsLicense _IssuedLicense;
        clsInternationalLicense _InternationalLicense;
        public ShowPersonHistoryLicenses(int LocalID)
        {
            InitializeComponent();
            _LoadObjects(LocalID);
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        


    }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the second tab (index 1) is selected
            if (tabControl1.SelectedIndex == 0)
            {
                // Your custom logic here
              _LoadDataOfLocalLicense();
            }
            else
            {
                _LoadDataOFInternationalLicense();
            }
        }
        private void _LoadObjects(int LocalID)
        {
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            _Application =clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
            if (_Local != null)
            {
                ctrFilterPerson_ADD1.PersonID = _Application.ApplicantPersonID;
                ctrFilterPerson_ADD1.FilterTextBoxValue = _Application.ApplicantPersonID.ToString();
                ctrFilterPerson_ADD1.Enabled = false;
                ctrShowPersonDetail1.PersonID = _Application.ApplicantPersonID;
            }


        }

        private void ctrFilterPerson_ADD1_Load(object sender, EventArgs e)
        {

        }
        private void _LoadDataOfLocalLicense()
        {
            dgvLocalLicense.DataSource = clsLicense.GetAllLocalLicense(_Application.ApplicantPersonID);
            lblRecords.Text = $"# Records : {dgvLocalLicense.RowCount}";
        }
        private void _LoadDataOFInternationalLicense()
        {
            dgvLicenseHistory.DataSource = clsInternationalLicense.GetAllInternationalLicenses(_Application.ApplicantPersonID);
            lblInterRecords.Text = $"# Records {dgvLicenseHistory.RowCount}";

        } 
        private void ShowPersonHistoryLicenses_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Local";
            tabPage2.Text = "InterNational";

            if (tabControl1.SelectedIndex==0)
            {
                _LoadDataOfLocalLicense();
            }
            
         
            this.AutoSize = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            _LoadDataOFInternationalLicense();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            _LoadDataOfLocalLicense();
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
