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
    public partial class Release_Detained_License : Form
    {
        clsDetainedLicense _DetainedLicense;
        public decimal DetainFees { get; set; }
        public int LicenseIDP { get; set; }
        clsApplications _Application;
        clsLicense _IssuedLicense;
        clsApplications _ReleasedApp;

        clsLocalDrivingLicenseApplication _Local, _NewLocal;

        clsUser _User;
        public Release_Detained_License(clsUser User)
        {
            InitializeComponent();
            ctrFilterLicense1.DataBack += _DataBackFilter;
            _User = User;
        }
        private void _DataBackFilter(object obj, int LicenseID)
        {
            _IssuedLicense = clsLicense.FindLicenseByLicenseID(LicenseID);
            if (_IssuedLicense != null)
            {
                LicenseIDP = LicenseID;
                _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_IssuedLicense.ApplicationID);
                _Application = clsApplications.FindApplicationByApplicationID(_IssuedLicense.ApplicationID);
                ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
                llLicenseHistory.Enabled = true;
                ctrDetainInfo1.LicenseID = LicenseID;
                if (!clsDetainedLicense.IsActiveLicense(LicenseID))
                {
                    btnSave.Enabled = true;

                }
                else
                {
                    btnSave.Enabled = false;
                    MessageBox.Show($"The License With {LicenseID} is Active , You Can't Release it ..");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            clsApplicationTypes _ApplicationTypes;
            _DetainedLicense = clsDetainedLicense.FindDetainedLicenseByLicenseID(LicenseIDP);
            _ReleasedApp = new clsApplications();
            if (MessageBox.Show($"Are You Sure To Release The License Of ID {LicenseIDP}", "Release License", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ReleasedApp.ApplicationTypeID = 5;
                //_ReleasedApp.ApplicationTypeStatus = 3;
                _ReleasedApp.LastStatusDate = DateTime.Now;
                _ReleasedApp.ApplicationDate = DateTime.Now;
                _ApplicationTypes = clsApplicationTypes.FindApplicationTypeByID(_ReleasedApp.ApplicationTypeID);
                _ReleasedApp.ApplicationFees = _ApplicationTypes.ApplicationFees;
                _ReleasedApp.ApplicantPersonID = _Application.ApplicantPersonID;
                _ReleasedApp.ClassTypeID = _Local.ClassTypeID;
                _ReleasedApp.CreatedByUserID = _User.UserID;

                if (_ReleasedApp.Save())
                {
                    _DetainedLicense.ReleasedByApplicationID = _ReleasedApp.ApplicationID;
                    _DetainedLicense.ReleasedByUserID = _User.UserID;
                    _DetainedLicense.ReleaseDate = DateTime.Now;

                    if (_DetainedLicense.SaveReleaseDetails())
                    {
                        _IssuedLicense.Activate();
                        MessageBox.Show("The License Is Released Seccussfully .. ");
                        ctrDetainInfo1.ReleasedApplicationID = _ReleasedApp.ApplicationID;
                        llShowLicenseInfo.Enabled = true;
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The License Is not Released Seccussfully .. ");
                    }

                }
                else
                {
                    MessageBox.Show("Could't Make An Application !! ");
                }

            }
            else
            {
                MessageBox.Show("Releace is Canceled ..");
            }
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(_Local.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLocalApplicationDetail(_Local.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void Release_Detained_License_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            llLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
    } 
}
