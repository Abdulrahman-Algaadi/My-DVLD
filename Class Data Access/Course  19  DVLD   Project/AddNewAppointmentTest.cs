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
    public partial class AddNewAppointmentTest : Form
    {
        enum enMode { AddNew,Update,IsLocked}
        enMode Mode =enMode.AddNew;
  
        public int LocalDrivingLicenseIDP {  get; set; }
        public int TestAppID {  get; set; }
        public int count = 0;
      
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Applications;
        clsBusiness _Person;
        clsLisences _Lisences;
        clsTestTypes _TestTypes;
        clsTestAppointments _TestAppointments;

        public AddNewAppointmentTest(int LocalDrivingLicenseID,int TestAppointMentID,int TestTypeID)
        {
            InitializeComponent();
            Mode =(TestAppointMentID==-1)?enMode.AddNew:enMode.Update;
           
           
                _LoadObjects(LocalDrivingLicenseID, TestAppointMentID,TestTypeID);
                TestAppID = TestAppointMentID;
            
  
            
    
        }
        private void _LoadObjects(int LocalDrivingLicenseID,int TestAppID, int TestTypeID)
        {

            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDrivingLicenseID);
            _Applications = clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
            _Person = clsBusiness.FindPerson(_Applications.ApplicantPersonID);
            _Lisences = clsLisences.FindLicenceClassByID(_Local.ClassTypeID);
            _TestTypes = clsTestTypes.FindTestTypeByID(TestTypeID);
            count = clsTestAppointments.CountTrial(LocalDrivingLicenseID, TestTypeID);
            if (Mode==enMode.Update)
            {
                _TestAppointments = clsTestAppointments.FindAppointmentByID(TestAppID);
            }
           
     
            _LoadData();
        }
        private void _LoadDataOfAddNew()
        {
            if (count == 0)
            {
                lblDLocalDriivingID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblTrial.Text = count.ToString();
                lblTotalFees.Text = _TestTypes.TestTypeFees.ToString();
                grpReTakeTest.Enabled = true;

            }
            else
            {
                decimal ReeAppFees = 5;
                lblDLocalDriivingID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblTrial.Text = count.ToString();
                grpReTakeTest.Enabled = false;
                lblTotalFees.Text = (_TestTypes.TestTypeFees + ReeAppFees).ToString();
                lblRAppFees.Text = ReeAppFees.ToString();
                lblTitle.Text = "Schedule Re_Test ";

            }


            _TestAppointments = new clsTestAppointments();
        }
        private void _LoadDataOfUpdate()
        {
         
            if (count==1)
            {
                lblDLocalDriivingID.Text = _TestAppointments.LocalDrivingLicenseID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblTrial.Text = count.ToString();
                dtpAppointmentDate.Value = _TestAppointments.AppointmentDate;
                lblRTestAppID.Text = _TestAppointments.TestAppointmentID.ToString();
                lblTotalFees.Text = _TestTypes.TestTypeFees.ToString();
                grpReTakeTest.Enabled = true;
            }
            else
            {
                decimal ReeAppFees = 5;
                lblDLocalDriivingID.Text =_TestAppointments.LocalDrivingLicenseID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblTrial.Text = count.ToString();
                grpReTakeTest.Enabled = false;
                dtpAppointmentDate.Value = _TestAppointments.AppointmentDate;
                lblRTestAppID.Text = _TestAppointments.TestAppointmentID.ToString();
                lblTotalFees.Text = (_TestTypes.TestTypeFees + ReeAppFees).ToString();
                lblRAppFees.Text = ReeAppFees.ToString();
                lblTitle.Text = "Schedule Re_Test ";
            }
      
        }

        private void _LoadData()
        {
          
            if (Mode==enMode.AddNew)
            { 
                _LoadDataOfAddNew();
            }
            
            if(Mode==enMode.Update)
            {
              _LoadDataOfUpdate();
            }
            
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointments.LocalDrivingLicenseID = _Local.LocalDrivingLicenseAppID;
            _TestAppointments.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointments.PaidFees = _TestTypes.TestTypeFees;
            _TestAppointments.CreatedByUserID = _Applications.CreatedByUserID;
            _TestAppointments.TestTypeID = _TestTypes.TestTypeID;
            _TestAppointments.IsLocked = false;
            
            if (_TestAppointments.Save())
            {
                MessageBox.Show("Appointment Has Been Sat Seccussfully ..");
                lblRTestAppID.Text =_TestAppointments.TestAppointmentID.ToString();
                this.Close();
            }
            else {
                MessageBox.Show("Appointment Has't Been Sat Seccussfully Due To Errors ..");
            }
        }

        private void AddNewAppointmentTest_Load(object sender, EventArgs e)
        {

        }
    }
}
