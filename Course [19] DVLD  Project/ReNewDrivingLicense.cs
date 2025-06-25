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
    public partial class ReNewDrivingLicense : Form
    {
        clsApplications _Application;

        clsLocalDrivingLicenseApplication _NewLocal;
        clsLocalDrivingLicenseApplication _ApplicationLocal;
        clsLicense _IssuedLicense;
        clsUser _User;
        clsApplications _ReNewApplication;
        clsLicense _ReNewLicense;
        public int LicenseID { get; set; }
        public int RenewedLicenseID { get; set; }
        public ReNewDrivingLicense(clsUser User)
        {
            InitializeComponent();
            ctrFilterLicense1.DataBack += _DataBackOfLicense;
            ctrNewApplicationLicenseInfo1.DataBack += _DataBackNotes;
            _User = User;
        }
        public string Notess {  get; set; }
        private void _DataBackNotes(object obj,string Notes)
        {
            Notess = Notes;
        }
        private void _DataBackOfLicense(object obj ,int LicenseID)
        {
            _IssuedLicense =clsLicense.FindLicenseByLicenseID(LicenseID);
            if (_IssuedLicense!=null)
            {
                if (_IssuedLicense.ExpirationDate>DateTime.Now)
                {
                    MessageBox.Show($"This License Has't Expired Yet ,It Will Expire in {_IssuedLicense.ExpirationDate}");

                    btnSave.Enabled = false;

                }
                else
                { 
                    btnSave.Enabled=true;
                }
                _ApplicationLocal = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_IssuedLicense.ApplicationID);
                ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
     
                ctrNewApplicationLicenseInfo1.User = _User;
                _Application =clsApplications.FindApplicationByApplicationID(_IssuedLicense.ApplicationID);
                llLicenseHistory.Enabled = true;


            }


        }
        private void ReNewDrivingLicense_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            llShowLicenseInfo.Enabled=false;
            llLicenseHistory.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplicationTypes _ApplicationTypes;
            
            clsLicenseClass _Lisences;
            if (MessageBox.Show("Are You Sure You want To Renew This License ? ","ReNew",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {


                
                _Lisences=clsLicenseClass.FindLicenceClassByID(_ApplicationLocal.ClassTypeID);
                DateTime Current = DateTime.Now;
                DateTime Future = Current.AddYears(_Lisences.ValidtyLengthPfLicense);
                _ReNewApplication = new clsApplications();

                _ReNewApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                _ReNewApplication.ApplicationTypeID = (int)clsApplications.enApplicationType.RenewDrivingLicense;
                _ApplicationTypes =clsApplicationTypes.FindApplicationTypeByID(_ReNewApplication.ApplicationTypeID);
                _ReNewApplication.ApplicationDate = DateTime.Now;
                _ReNewApplication.LastStatusDate = DateTime.Now;
                _ReNewApplication.ClassTypeID = _ApplicationLocal.ClassTypeID;
                //_ReNewApplication.ApplicationTypeStatus = _Application.ApplicationTypeStatus;
                _ReNewApplication.ApplicationFees = _ApplicationTypes.ApplicationFees;
                _ReNewApplication.CreatedByUserID = _User.UserID;
                if (_ReNewApplication.Save())
                {
                    _ReNewLicense = new clsLicense();
                    _ReNewLicense.ApplicationID = _ReNewApplication.ApplicationID;
                    _ReNewLicense.DriverID = _IssuedLicense.DriverID;
                    _ReNewLicense.LicenseClassID = _IssuedLicense.LicenseClassID;
                    _ReNewLicense.IssueDate = DateTime.Now;
                    _ReNewLicense.ExpirationDate = Future;
                    _ReNewLicense.Notes = Notess;
                    _ReNewLicense.PaidFees = 20;
                    _ReNewLicense.IsActive = true;
                    _ReNewLicense.IssueReason = clsLicense.enIssueReason.Renew;
                    _ReNewLicense.CreatedByUserID = _User.UserID;
                    if (_ReNewLicense.IssueLicense())
                    {
                        MessageBox.Show($"Your License has been ReNewed Secussfully With The ID Of {_ReNewLicense.LicenseID} .. ");
                        _IssuedLicense.IsActive = false;
                        _IssuedLicense.DeActivate();
                        ctrNewApplicationLicenseInfo1.ReNewApplicationID = _ReNewApplication.ApplicationID;
                        ctrNewApplicationLicenseInfo1.RenewedLicenseID =_ReNewLicense.LicenseID;
                        ctrFilterLicense1.Enabled = false; 
                        btnSave.Enabled = false;
                        llShowLicenseInfo.Enabled = true;
                        _NewLocal = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_ReNewLicense.ApplicationID);

                    }
                    else
                    {
                        MessageBox.Show("Your License has been ReNewed Secussfully .. ");
                    }
                }
                else
                {
                    MessageBox.Show("It Can't Add Application!!");
                }
            }
            else
            {
                MessageBox.Show("The operation of ReNewing is canceled  .. ");
            }

                    

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm= new frmShowLocalApplicationDetail(_NewLocal.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(_ApplicationLocal.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }
    }
}
