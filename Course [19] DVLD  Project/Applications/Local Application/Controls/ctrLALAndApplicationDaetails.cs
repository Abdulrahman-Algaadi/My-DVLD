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
       
        clsLocalDrivingLicenseApplication _Local;
       
        public ctrLALAndApplicationDaetails()
        {
            InitializeComponent();
        }
        public void _LoadData(int LocalDLicenseID)
        {
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDLicenseID);
            if (_Local!=null)
            {
                
                ///
                lblAppID.Text = _Local.ApplicationID.ToString();
                lblAppStatus.Text = (_Local.ApplicationStatus==(clsApplications.enApplicationStatus)1)?"New":((_Local.ApplicationStatus ==(clsApplications.enApplicationStatus) 2)?"Cancel":"Completed");
                lblAppFees.Text = _Local.ApplicationFees.ToString();
                lblAppType.Text = _Local.ApplicationInfo.ApplicationTypesInfo.ApplicationTitle.ToString();
                lblFullName.Text = _Local.ApplicationInfo.PersonInfo.FullName();
                lblDate.Text = _Local.ApplicationDate.ToString();
                lblStatusDate.Text = _Local.LastStatusDate.ToString();
                lblCreatedBy.Text = clsGlobal.User.UserName.ToString();
                lblDLAppID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblLicenseType.Text = _Local.LicenseClassInfo.LicenceClassName.ToString();
                lblPassedTest.Text = "[" + clsTestAppointments.TestsThatAlreadyPassed(LocalDLicenseID).ToString() + "] Out Of [3]";


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm =new ShowDetailForm(_Local.ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

     
    }
}
