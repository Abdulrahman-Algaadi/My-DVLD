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
    public partial class ctrShowLicenseInfo : UserControl
    {
        enum enIssueReason
        {
            FirstTime=1
        }
        enIssueReason IssueReason;

        private int _LocalDrivingLicenseAppID;
        public int LocalDrivingLicenseAppID { get { return _LocalDrivingLicenseAppID; } 
            set {
                _LocalDrivingLicenseAppID = value;
                _LoadObjects(_LocalDrivingLicenseAppID); }
        }
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Applications;
        clsBusiness _Person;
        clsIssuedLicense _IssuedLicense;
        clsLisences _Lisences;
        public ctrShowLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadObjects(int LocalID)
        {
            _Local =clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            if (_Local!=null)
            {
                _Lisences = clsLisences.FindLicenceClassByID(_Local.ClassTypeID);
                _IssuedLicense=clsIssuedLicense.FindLicenseByApplicationID(_Local.ApplicationID);
                _Applications =clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
                _Person = clsBusiness.FindPerson(_Applications.ApplicantPersonID);
                _LoadLicenseData();
            }
        }
        private void _LoadLicenseData()
        {
            IssueReason = (enIssueReason)_IssuedLicense.IssueReason;
            lblclsName.Text =_Lisences.LicenceClassName.ToString();
            lblName.Text = _Person.FullName();
            lblLicenseID.Text =_IssuedLicense.LicenseID.ToString();
            lblNationalNo.Text =_Person.NationalNo.ToString();
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblIssueDate.Text = _IssuedLicense.IssueDate.ToString();
           lblIssueReason.Text =IssueReason.ToString();
            lblNotes.Text = _IssuedLicense.Notes.ToString();
            lblIsActive.Text = (_IssuedLicense.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text =_Person.BirthDate.ToString();
            lblDriverID.Text =_IssuedLicense.DriverID.ToString();
            lblExpirationDate.Text =_IssuedLicense.ExpirationDate.ToString();
            lblIsDetained.Text = "No";

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrShowLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form ParentForm = this.FindForm();
            if (ParentForm != null)
            {
                ParentForm.Close();
            }
        }
    }
}
