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
    public partial class ctrLALAndApplicationDaetails : UserControl
    {
        private int _LocalDLicenseID;
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Application;
        clsLisences _LicenceClass;
        clsApplicationTypes _ApplicationTypes;
        clsBusiness _Person;
        clsUser _User;

        public int LocalDLicenseID { get { return _LocalDLicenseID; } set { _LocalDLicenseID = value;
                _LoadData();
            } }
        public ctrLALAndApplicationDaetails()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDLicenseID);
            if (_Local!=null)
            {
                
                _Application = clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
                _ApplicationTypes =clsApplicationTypes.FindApplicationTypeByID(_Application.ApplicationTypeID);
                _LicenceClass = clsLisences.FindLicenceClassByID(_Local.ClassTypeID);
                _Person = clsBusiness.FindPerson(_Application.ApplicantPersonID);
                _User = clsUser.FindUserByID(_Application.CreatedByUserID);
                lblDLAppID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblLicenseType.Text = _LicenceClass.LicenceClassName.ToString();
                lblPassedTest.Text = "["+clsTestAppointments.TestsThatAlreadyPassed(LocalDLicenseID).ToString() +"] Out Of [3]";
         
              


                ///
                lblAppID.Text = _Application.ApplicationID.ToString();
                lblAppStatus.Text = (_Application.ApplicationTypeStatus==1)?"New":((_Application.ApplicationTypeStatus == 2)?"Cancel":"Completed");
                lblAppFees.Text =_Application.ApplicationFees.ToString();
                lblAppType.Text =_ApplicationTypes.ApplicationTitle.ToString();
                lblFullName.Text = _Person.FullName();
                lblDate.Text = _Application.ApplicationDate.ToString();
                lblStatusDate.Text =_Application.LastStatusDate.ToString();
                lblCreatedBy.Text = _User.UserName.ToString();

            
              


            }
        }

        private void ctrLALAndApplicationDaetails_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm =new ShowDetailForm(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }


    }
}
