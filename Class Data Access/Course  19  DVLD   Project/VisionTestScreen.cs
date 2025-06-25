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
    public partial class VisionTestScreen : Form
    { public int LocalDrivingLicenseID {  get; set; }
        public int _TestTypeID {  get; set; }

        clsTestAppointments _TestAppointments;
        public int  PassedTestCount {  get; set; }
        public VisionTestScreen(int LocalDLID,int TestTypeID)
        {
            InitializeComponent();
            ctrLALAndApplicationDaetails1.LocalDLicenseID = LocalDLID;
            LocalDrivingLicenseID = LocalDLID;
            _TestTypeID = TestTypeID;
            this.AutoSize = true;
        }

        private void  btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int IsLocked = clsTestAppointments.IsLockedReturnNumber(LocalDrivingLicenseID);
             PassedTestCount= clsTestAppointments.PassedTestCount(LocalDrivingLicenseID,_TestTypeID);
            if (PassedTestCount!=1)
            { 
                if (IsLocked ==0 )
                {
                    Form form = new AddNewAppointmentTest(LocalDrivingLicenseID, -1,_TestTypeID);
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
            dgvAppointments.DataSource = clsTestAppointments.GetAppointmentForALocalID(LocalDrivingLicenseID,_TestTypeID);
            lblBumberOfAppointments.Text =$"# Records : {dgvAppointments.RowCount}";
        }
        private void VisionTestScreen_Load(object sender, EventArgs e)
        {
            _LoadData();
            switch (_TestTypeID)
            {
                case 1:
                    lblTestName.Text = "Vision Test Appointment";
                   
                        break;
                case 2:
                    lblTestName.Text = "Written Test Appointment";
                    break;
                    case 3:
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
            int PassedTestCount = clsTestAppointments.PassedTestCount(LocalDrivingLicenseID, _TestTypeID);
            _TestAppointments = clsTestAppointments.FindAppointmentByLocalLicenseID(LocalDrivingLicenseID,false);
            if (_TestAppointments!=null)
            {
                Form frm = new AddNewAppointmentTest(LocalDrivingLicenseID, (int)dgvAppointments.CurrentRow.Cells[0].Value,_TestTypeID);
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
            PassedTestCount =clsTestAppointments.PassedTestCount(LocalDrivingLicenseID,_TestTypeID);
            if (PassedTestCount!=1)
            {
                Form frm = new TakeTestScreen(LocalDrivingLicenseID, (int)dgvAppointments.CurrentRow.Cells[0].Value, _TestTypeID);
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
