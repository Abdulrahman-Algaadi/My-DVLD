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
    public partial class InterNationalDrivingLicense : Form
    {

        private int _SelectedLicenseID = -1;
        public InterNationalDrivingLicense()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InterNationalDrivingLicense_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            llShowLicenseInfo.Enabled = false;
            llLicenseHistory.Enabled=false;
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUserID.Text = clsGlobal.User.UserName;
            lblFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);

        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(ctrFilterLicenseByIDAndShow1.License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowInternationalLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void ctrFilterLicenseByIDAndShow1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
   
            lblLocalLicenseID.Text = ctrFilterLicenseByIDAndShow1.License.LicenseID.ToString();

           llLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            if (ctrFilterLicenseByIDAndShow1.License.LicenseClassID!=3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrFilterLicenseByIDAndShow1.License.DriverID);
            if (ActiveInternationalLicenseID!=-1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                _SelectedLicenseID = ActiveInternationalLicenseID;
                btnIssue.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsApplications _InternationalApplication = new clsApplications();
            _FillInterNationalApplication(ref _InternationalApplication);
            

            clsInternationalLicense _InternationalLicense = new clsInternationalLicense();  
            _InternationalLicense.ApplicationID = _InternationalApplication.ApplicationID;
            _InternationalLicense.CreatedByUserID = clsGlobal.User.UserID;
            _InternationalLicense.DriverID = ctrFilterLicenseByIDAndShow1.License.DriverID;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.IsActive = true;
            _InternationalLicense.IssuedUsingLocalLicenseID = ctrFilterLicenseByIDAndShow1.License.LicenseID;

            if (!_InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblILAppID.Text = _InternationalLicense.ApplicationID.ToString();           
            lblLicenseID.Text = _InternationalLicense.InernationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + _InternationalLicense.InernationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrFilterLicenseByIDAndShow1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

        }
        private void _FillInterNationalApplication(ref clsApplications Application)
        {
            Application.ApplicantPersonID = ctrFilterLicenseByIDAndShow1.License.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.ApplicationFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUserID = clsGlobal.User.UserID;
            Application.ApplicationTypeID =(int) clsApplications.enApplicationType.NewInternationalLicense;
            if (!Application.Save())
            {
                MessageBox.Show("Data is not Saved Seccussfully!!","Application Not Saved",MessageBoxButtons.OK);
                return;
            }
        }

        private void InterNationalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrFilterLicenseByIDAndShow1.FilterFocus();
        }
    }
}
