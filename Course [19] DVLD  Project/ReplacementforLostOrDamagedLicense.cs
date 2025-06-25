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
    public partial class ReplacementForLostOrDamagedLicense : Form
    {
        clsLicense _Issued,_NewLicense;
        clsLocalDrivingLicenseApplication _LocalApplication;
        clsUser _User;
        clsApplications _Application,_NewApplication;
        clsApplicationTypes _ApplicationTypes;
        public decimal ApplicationFees {  get; set; }   
        public ReplacementForLostOrDamagedLicense(clsUser user)
        {
            InitializeComponent();
            ctrFilterLicense1.DataBack += _DataBackFromFilter;
            _User = user;
        }

        private void _DataBackFromFilter(object obj,int LicenseID)
        {
            _Issued =clsLicense.FindLicenseByLicenseID(LicenseID);
            if (_Issued!=null)
            {
                _LocalApplication =clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_Issued.ApplicationID);
                ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
                _Application =clsApplications.FindApplicationByApplicationID(_Issued.ApplicationID);
                if (_Issued.IsActive!=false)
                {
               
                    ctrApplicationInfoForReplacement1.OldLicenseID = LicenseID;
                    ctrApplicationInfoForReplacement1.User = _User;
                    btnIssueReplacement.Enabled = true; ;
                    llLicenseHistory.Enabled = true;
                }
                else
                {
                    MessageBox.Show("You can't have A replacement For an InActive License , You need To Renew it First ...");
                    btnIssueReplacement.Enabled = false;
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled=false;
            llLicenseHistory.Enabled=false;
            llShowLicenseInfo.Enabled=false;
            rdbDamaged.Checked = true;
        }

        private void rdbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationTypes = clsApplicationTypes.FindApplicationTypeByID(4);
            if (rdbDamaged.Checked == true)
            {
                lblTitle.Text = "Replacement For Damaged License";
                ApplicationFees = _ApplicationTypes.ApplicationFees;

                ctrApplicationInfoForReplacement1.ApplicationFees = ApplicationFees;
            }
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form frm = new ShowPersonHistoryLicenses(_LocalApplication.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLocalDrivingLicenseApplication _NewLocal = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_NewApplication.ApplicationID);
            Form frm = new frmShowLocalApplicationDetail(_NewLocal.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void ctrApplicationInfoForReplacement1_Load(object sender, EventArgs e)
        {

        }

        private void rdbLost_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationTypes = clsApplicationTypes.FindApplicationTypeByID(3);
            if (rdbLost.Checked == true) {
                lblTitle.Text = "Replacement For Lost License";
                ApplicationFees = _ApplicationTypes.ApplicationFees;

                ctrApplicationInfoForReplacement1.ApplicationFees = ApplicationFees;
            }
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            _NewApplication = new clsApplications();
            if (MessageBox.Show("Are You Sure You want To Make A Replacement For This License ? ", "Replacement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _NewApplication.ApplicantPersonID =_Application.ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationFees = (rdbDamaged.Checked ? ApplicationFees : ApplicationFees);
                _NewApplication.LastStatusDate = DateTime.Now;
                //_NewApplication.ApplicationTypeStatus = _Application.ApplicationTypeStatus;
                _NewApplication.ApplicationTypeID = (rdbDamaged.Checked)?4:3;
                _NewApplication.ClassTypeID = _LocalApplication.ClassTypeID;
                _NewApplication.CreatedByUserID =_User.UserID;
                if (_NewApplication.Save())
                {
                    _NewLicense = new clsLicense();

                    _NewLicense.ApplicationID =_NewApplication.ApplicationID;
                    _NewLicense.DriverID =_Issued.DriverID;
                    _NewLicense.LicenseClassID = _Issued.LicenseClassID;
                    _NewLicense.IssueDate = _Issued.IssueDate;
                    _NewLicense.ExpirationDate = _Issued.ExpirationDate;
                    _NewLicense.Notes = _Issued.Notes;
                    _NewLicense.PaidFees = _Issued.PaidFees;
                    _NewLicense.IsActive = _Issued.IsActive;
                    _NewLicense.IssueReason = rdbDamaged.Checked ? (clsLicense.enIssueReason.LostReplacement) :(clsLicense.enIssueReason.DamagedReplacement);
                    _NewLicense.CreatedByUserID =_User.UserID;
                    if (_NewLicense._AddNewLicense())
                    {
                        MessageBox.Show($"The Replacement License is Issued Seccusssfully With ID Of {_NewLicense.LicenseID}");

                        _Issued.DeActivate();
                        ctrApplicationInfoForReplacement1.ReplacedLicenseID =_NewLicense.LicenseID;
                        ctrApplicationInfoForReplacement1.L_R_ApplicationID = _NewApplication.ApplicationID;
                        llShowLicenseInfo.Enabled = true;
                        btnIssueReplacement.Enabled = false;
                        groupBox1.Enabled = false;
                        ctrFilterLicense1.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("License Could'n be saved !! (:(");
                    }



                }
                else
                {
                    MessageBox.Show("The New Application Could't Be Saved Due To Errors !! :( ");

                }




            }
        }
    }
}
