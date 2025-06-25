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
    public partial class TestScreens : Form
    { public int LocalDrivingLicenseID {  get; set; }
        public clsTestTypes.enTestType _TestTypeID {  get; set; }

        clsLocalDrivingLicenseApplication _Local;
        clsTestAppointments _TestAppointments;
        public int  PassedTestCount {  get; set; }
        public TestScreens(int LocalDLID,clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            LocalDrivingLicenseID = LocalDLID;
            _TestTypeID = TestTypeID;
            this.AutoSize = true;
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDLID);
       
            ctrLALAndApplicationDaetails1._LoadData( LocalDLID);

        }

        private void  btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int IsLocked = clsTestAppointments.IsLockedReturnNumber(LocalDrivingLicenseID);
             PassedTestCount= clsTestAppointments.PassedTestCount(LocalDrivingLicenseID,(int)_TestTypeID);
            if (PassedTestCount!=1)
            { 
                if (IsLocked ==0 )
                {
                    //Form form = new Add_Edit_AppointmentTest(LocalDrivingLicenseID, -1,(clsTestTypes.enTestType) _TestTypeID);
                    //form.ShowDialog();
                    Form form = new Schdule_Edit(LocalDrivingLicenseID,_TestTypeID);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You Can't have another Test While Having An active One ..");
                }
            }
            else
            {
                MessageBox.Show("You Passed The test , Ai't  gonna Add any");
            }
            
            
            _LoadData();
        }
        private void _LoadData()
        {
            dgvAppointments.DataSource = clsTestAppointments.GetAppointmentForALocalID(LocalDrivingLicenseID,(int)_TestTypeID);
            lblBumberOfAppointments.Text =$"# Records : {dgvAppointments.RowCount}";
        }
        private void TestScreens_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            _LoadData();
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblTestName.Text = "Vision Test Appointment";
                   
                        break;
                case clsTestTypes.enTestType.WrittenTest:
                    lblTestName.Text = "Written Test Appointment";
                    break;
                    case clsTestTypes.enTestType.StreetTest:
                    lblTestName.Text = "Driving Test Appointment";
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PassedTestCount = clsTestAppointments.PassedTestCount(LocalDrivingLicenseID,(int) _TestTypeID);
            _TestAppointments = clsTestAppointments.FindAppointmentByLocalLicenseID(LocalDrivingLicenseID,false);
            if (_TestAppointments!=null)
            {
                Form frm = new Schdule_Edit(LocalDrivingLicenseID,(clsTestTypes.enTestType)_TestTypeID, (int)dgvAppointments.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            }
            else
            {
                if (PassedTestCount==1)
                {
                    MessageBox.Show("You Passed The Test , You Can't Edit it "); _LoadData();return;
                }
                

                     MessageBox.Show("Sorry This test Can't be edited , it is Locked Now");
            }
            _LoadData();


        }

        private void takeATestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassedTestCount =clsTestAppointments.PassedTestCount(LocalDrivingLicenseID,(int)_TestTypeID);
            if (PassedTestCount!=1)
            {
                Form frm = new TakeTestScreen(LocalDrivingLicenseID, (int)dgvAppointments.CurrentRow.Cells[0].Value, (int)_TestTypeID);
                frm.ShowDialog();
                _LoadData();
            }
            else
            {
                MessageBox.Show("You Can't Take Another Test From This One < You Passed");
            }
         
        }
    }
}
