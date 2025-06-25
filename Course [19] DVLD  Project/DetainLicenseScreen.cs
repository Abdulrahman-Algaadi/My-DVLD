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
    public partial class DetainLicenseScreen : Form
    {


        clsDetainedLicense _DetainedLicense ;
        public decimal DetainFees {  get; set; }
        public int LicenseIDP {  get; set; }
        clsApplications _Application;
        clsLicense _IssuedLicense;

        clsLocalDrivingLicenseApplication _Local,_NewLocal;

        clsUser _User;
        public DetainLicenseScreen(clsUser User)
        {
            InitializeComponent();
            ctrFilterLicense1.DataBack += _DataBackFromctrFilter;
            ctrDetain_Release1.DataBack += _DataBackFees;
            _User = User;
        }

        private void _DataBackFromctrFilter(object obj,int LicenseID)
        {
           _IssuedLicense =clsLicense.FindLicenseByLicenseID(LicenseID);
            if (_IssuedLicense!=null)
            {
                LicenseIDP = LicenseID;
                _Local =clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_IssuedLicense.ApplicationID);
                ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
                llLicenseHistory.Enabled = true;

         
               

                if (clsDetainedLicense.IsActiveLicense(LicenseID))
                {
                    ctrDetain_Release1.LicenseID = LicenseID;
                    ctrDetain_Release1.User = _User;
                    btnSave.Enabled = true;
                    
                }
                else
                {btnSave.Enabled = false;
                    MessageBox.Show($"The License With {LicenseID} is InActive , You Can't Detain it ..");
                }

            }
        }
        private void _DataBackFees(object obj ,decimal Fees)
        {

            DetainFees = -1;
               DetainFees= Fees;  
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           _DetainedLicense = new clsDetainedLicense();
            if (MessageBox.Show($"Are You sure To Detain The License With ID Of {LicenseIDP} ? ","Detainment",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {


                if (DetainFees != -1)
                {
                    _DetainedLicense.LicenseID = LicenseIDP;
                    _DetainedLicense.DetainDate = DateTime.Now;
                    _DetainedLicense.FineFees = DetainFees;
                    _DetainedLicense.CreatedByUserID = _User.UserID;
                    if (_DetainedLicense.DetainLicense())
                    {
                        _IssuedLicense.DeActivate();
                        MessageBox.Show($"This License Has been Detained With Detain ID Of {_DetainedLicense.DetainedID}");
                        btnSave.Enabled = false;
                        ctrShowLicenseInfo1.LoadLicenseData(LicenseIDP);
                        llShowLicenseInfo.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show($"This License Has't been Detained Due To Errors In The System ... ");
                    }
                }
                else
                {
                    MessageBox.Show("You need To put The Fee Amount First . ");
                }
            }
            else
            {
                MessageBox.Show("The Operation Has Been Canceled Secussfully ..");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Detain_Release_License_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            llLicenseHistory.Enabled=false;
            llShowLicenseInfo.Enabled=false;
        }
    }
}
