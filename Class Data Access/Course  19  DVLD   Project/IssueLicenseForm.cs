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
    public partial class IssueLicenseForm : Form
    {
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Application;
        clsLisences _Lisences;
        clsUser _User;
        clsBusiness _Person;
       clsApplicationTypes _ApplicationTypes;
        clsIssuedLicense _IssuedLicense;
        public IssueLicenseForm(int LocalDLID)
        {
            InitializeComponent();
            ctrLALAndApplicationDaetails1.LocalDLicenseID = LocalDLID;
            _LoadObject(LocalDLID);


        }
        private void _LoadObject(int LocalDLID)
        {
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDLID);
            _Application = clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
            _Lisences = clsLisences.FindLicenceClassByID(_Application.ApplicationTypeID);
            
           _ApplicationTypes =clsApplicationTypes.FindApplicationTypeByID(_Application.ApplicationTypeID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IssueLicenseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            _IssuedLicense =new clsIssuedLicense();
            DateTime CurrentTime = DateTime.Now;
            DateTime ExpirationTime = CurrentTime.AddYears(_Lisences.ValidtyLengthPfLicense);
            
            _IssuedLicense.ApplicationID = _Application.ApplicationID;
            _IssuedLicense.IssueDate =DateTime.Now;
            _IssuedLicense.PaidFees = _Lisences.LicenseFees;
            _IssuedLicense.CreatedByUserID = _Application.CreatedByUserID;
            _IssuedLicense.LicenseClassID =_Lisences.LicenceClassID;
            _IssuedLicense.Notes = textBox1.Text;
            _IssuedLicense.IsActive = true;
            _IssuedLicense.IssueReason = 1;
            _IssuedLicense.ExpirationDate = ExpirationTime;
            _IssuedLicense.PersonID = _Application.ApplicantPersonID;
            if (_IssuedLicense.Save())
            {
                _Application.ApplicationTypeStatus = 3;
                _Application.Save();
                MessageBox.Show($"The License Is Made With The ID Of {_IssuedLicense.LicenseID}");   
            }
            else
            {
                MessageBox.Show("Go Work On Your Logic Looser Loser Loserrrrrrrrrrrrrrrrrr .");
            }
            
            
            
        }
    }
}
