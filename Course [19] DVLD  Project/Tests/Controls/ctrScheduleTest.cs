using clsLogic;
using Guna.UI2.WinForms.Suite;
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
    public partial class ctrScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;


        private clsTestTypes.enTestType _TestTypeID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;
        public ctrScheduleTest()
        {
            InitializeComponent();
        }
     
        public clsTestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set { 
                _TestTypeID = value;

                switch (_TestTypeID) { 
                
                case clsTestTypes.enTestType.VisionTest:
                        lblTitle.Text = "Vision Test";
                        break;
                case clsTestTypes.enTestType.WrittenTest:
                        lblTitle.Text = "Written Test";
                        break;
                case clsTestTypes.enTestType.StreetTest:
                        lblTitle.Text = "Street Test";
                        break;
                }            
            }
        
        
        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID,int TestAppointmentID =-1)
        {
            if (TestAppointmentID==-1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

             _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplication =clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees.ToString();
                grpReTakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
          
            }
            else
            {
                grpReTakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblDLocalDriivingID.Text =_LocalDrivingLicenseApplication.LocalDrivingLicenseAppID.ToString();
            lblName.Text = _LocalDrivingLicenseApplication.ApplicationInfo.PersonInfo.FullName();
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest((int)TestTypeID).ToString();
            lblDLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.LicenceClassName.ToString();

     

            if (_Mode==enMode.AddNew)
            {
                
                dtpAppointmentDate.MinDate = DateTime.Now;
                lblFees.Text = clsTestTypes.FindTestTypeByID((clsTestTypes.enTestType)TestTypeID).TestTypeFees.ToString();
                _TestAppointment = new clsTestAppointments();

            }
            else
            {
                if (!LoadAppointmentData())
                {
                    return;
                }
            }


            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();

            

        }

        public bool LoadAppointmentData()
        {
            _TestAppointment = clsTestAppointments.FindAppointmentByID(_TestAppointmentID);


            if (_TestAppointment==null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;

                return false;
            }
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
            dtpAppointmentDate.MinDate = DateTime.Now;
            if (_TestAppointment.ReTakeTestID==-1)
            {
                lblTitle.Text = "Edit Schudled Test";
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
                grpReTakeTest.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Edit Re Schudled Test";
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = clsTestTypes.FindTestTypeByID(TestTypeID).TestTypeFees.ToString();
                grpReTakeTest.Enabled = true;


            }

            return true;    

        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplications Application = new clsApplications();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.ApplicationFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.User.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.ReTakeTestID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.ReTakeTestID = Application.ApplicationID;

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
            {
                return;
            }
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.TestTypeID = (int)TestTypeID;
            _TestAppointment.PaidFees =Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatedByUserID =clsGlobal.User.UserID;
            _TestAppointment.LocalDrivingLicenseID =_LocalDrivingLicenseApplicationID;
            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form Parent = this.FindForm();
                if (Parent != null)
                {
                    Parent.Close();
                }

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
    
}
