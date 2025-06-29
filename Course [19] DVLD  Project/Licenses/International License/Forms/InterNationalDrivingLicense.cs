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
        clsLicense _IssuedLicense;
        clsApplications _Application,_NewApplication;
        clsLocalDrivingLicenseApplication _LocalApplication;
        clsUser _User;
        clsInternationalLicense _InternationalLicense ;
        public int InternationalLicenseID {  get; set; }
        public int LocalLicenseDrivingID {  get; set; }



        public InterNationalDrivingLicense(clsUser User )
        {
            InitializeComponent();
           // ctrFilterLicense1.DataBack += _DataBackOfLicense;
           //_User = User;    
        }


        private void _DataBackOfLicense(object obj ,int LicenseID)
        {
            _IssuedLicense = clsLicense.FindLicenseByLicenseID(LicenseID);

            if (_IssuedLicense != null)
            {

                _LocalApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_IssuedLicense.ApplicationID);
                _Application = clsApplications.FindApplicationByApplicationID(_IssuedLicense.ApplicationID);
                ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
                ctrInternationalDrivingLicense1.LocalDrivingLicenseID = _LocalApplication.LocalDrivingLicenseAppID;
                ctrInternationalDrivingLicense1.User = _User;
                LocalLicenseDrivingID = LicenseID;
                llLicenseHistory.Enabled = true;
                return;
            }
            llLicenseHistory.Enabled = false;

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
        
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(_LocalApplication.LocalDrivingLicenseAppID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void ctrFilterLicense1_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (_IssuedLicense==null)
            {
                MessageBox.Show("You can't Issue Any thing ");
                btnIssue.Enabled= false;
                return;
            }else
                btnIssue.Enabled= true;
            DateTime Now =DateTime.Now;
            DateTime Futer = Now.AddYears(1);
            _NewApplication = new clsApplications();
            _InternationalLicense =new clsInternationalLicense();
          
            
                //_NewApplication.ApplicantPersonID =_Application.ApplicantPersonID;
                //_NewApplication.ApplicationDate =DateTime.Now;
                //_NewApplication.LastStatusDate = DateTime.Now;
                //_NewApplication.ApplicationTypeStatus = 3;
                //_NewApplication.ApplicationTypeID = 6;
                //_NewApplication.ApplicationFees = 51;
                //_NewApplication.CreatedByUserID = _User.UserID;


            clsLicense _License;
            if (!clsInternationalLicense.IsLicenseExists(LocalLicenseDrivingID))
            {
                _License = clsLicense.FindLicenseByLicenseID(LocalLicenseDrivingID, 3);

                if (_License != null)
                {

                    if (_NewApplication.AddNewApplication())
                    {
                        _InternationalLicense.ApplicationID = _NewApplication.ApplicationID;
                        _InternationalLicense.IssueDate = DateTime.Now;
                        _InternationalLicense.ExpirationDate = Futer;
                        _InternationalLicense.IssuedUsingLocalLicenseID = LocalLicenseDrivingID;
                        _InternationalLicense.DriverID = _IssuedLicense.DriverID;
                        _InternationalLicense.IsActive = true;
                        _InternationalLicense.CreatedByUserID = _User.UserID;
                        if (_InternationalLicense.Save())
                        {
                            MessageBox.Show($"The InterNational License is Issued Seccusssfully With ID Of {_InternationalLicense.InernationalLicenseID}");
                            ctrInternationalDrivingLicense1.ApplicationID = _NewApplication.ApplicationID;
                            ctrInternationalDrivingLicense1.InternationalLicenseID = _InternationalLicense.InernationalLicenseID;
                            llShowLicenseInfo.Enabled = true;
                            llLicenseHistory.Enabled = true;
                            InternationalLicenseID = _InternationalLicense.InernationalLicenseID;

                        }
                        else
                        {
                            MessageBox.Show("It is not Saved Due To Errors ..");

                        }



                    }
                    else
                    {
                        MessageBox.Show("Could'nt Add The Application ");
                    }
                }
                else
                {
                    MessageBox.Show("You have an active International License Already !!");
                }
            }
            else
            {
                MessageBox.Show("License Dose Exist but There Is No Ordinary License !!");
            }

          

     
        }
    }
}
