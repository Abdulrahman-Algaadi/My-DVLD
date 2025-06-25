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
    public partial class TakeTestScreen : Form
    {
        public int count {  get; set; }
        public int TestAppIDP {  get; set; }
        public int TestTypeID {  get; set; }    
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Applications;
        clsPerson _Person;
        clsLicenseClass _Lisences;
        clsTestTypes _TestTypes;
        clsTestAppointments _TestAppointments;
        clsTests _Tests =new clsTests();
        public TakeTestScreen(int LocalDrivingLicenseID,int TestAppointmentID, int testTypeID)
        {
            InitializeComponent();
            _LoadObjects(LocalDrivingLicenseID, TestAppointmentID,testTypeID);
           
        }
        private void _LoadObjects(int LocalDrivingLicenseID, int TestAppID,int TestTypeID)
        {

            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDrivingLicenseID);
            _Applications = clsApplications.FindApplicationByApplicationID(_Local.ApplicationID);
            _Person = clsPerson.FindPerson(_Applications.ApplicantPersonID);
            _Lisences =clsLicenseClass.FindLicenceClassByID(_Local.ClassTypeID);
            _TestTypes = clsTestTypes.FindTestTypeByID((clsTestTypes.enTestType)TestTypeID);
            count = clsTestAppointments.CountTrial(LocalDrivingLicenseID,(clsTestTypes.enTestType)TestTypeID);
            _TestAppointments = clsTestAppointments.FindAppointmentByID(TestAppID);
            _LoadDataOfAddNew();
            TestAppIDP = TestAppID;
        }
        private void _LoadDataOfAddNew()
        {
            if (count == 1)
            {
                lblDLocalDriivingID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblDate.Text =_TestAppointments.AppointmentDate.ToString();
                lblTrial.Text = count.ToString();
        

            }
            else
            {
              
                lblDLocalDriivingID.Text = _Local.LocalDrivingLicenseAppID.ToString();
                lblDLicense.Text = _Lisences.LicenceClassName.ToString();
                lblName.Text = _Person.FullName();
                lblFees.Text = _TestTypes.TestTypeFees.ToString();
                lblDate.Text = _TestAppointments.AppointmentDate.ToString();
                lblTrial.Text = count.ToString();
                lblTitle.Text = "Scheduled Re_Test ";

            }
         


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Tests.TestResult =(rbPass.Checked)?true:false;
            _Tests.Notes = txtNotes.Text;
            _Tests.CreatedByUserID =_Applications.CreatedByUserID;
            _Tests.TestAppointmentID = TestAppIDP;
            if (_Tests.Save())
            {
                if (_Tests.TestResult==false)
                {
                    _TestAppointments.IsLocked = true;
                    _TestAppointments.Save();
                    lblTestID.Text = _Tests.TestID.ToString();
                    MessageBox.Show("You Did't Passe The Test Secussfully :)");
                    this.Close();
                    return;
                }
                _TestAppointments.IsLocked = true;
                _TestAppointments.Save();
                lblTestID.Text = _Tests.TestID.ToString();
                MessageBox.Show("You Passed The Test Secussfully :)");
                this.Close();
         
            }

            {
              
            }


        }

        private void TakeTestScreen_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.rbPass.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
