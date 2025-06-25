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
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicense;    
        clsApplications _Application;
        clsUser _User;
        public frmManageLocalDrivingLicenseApplication(clsUser user)
        {
            InitializeComponent();
            _User = user;
        }

        private void _RefreshApplications()
        {
            dgvApplications.DataSource = clsApplications.GetAllLocalApplications();
            label3.Text = $"# Records : {dgvApplications.RowCount}";

        }
        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
   
            _RefreshApplications();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new NewLicenseForm(_User, (int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplications() ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            int IndexCombo= cbFilter.SelectedIndex;
        
            string ColName = "";
            switch (IndexCombo)
            {
                case 1:
                    ColName = "LocalDrivingLicenseApplicationID";
                    break;
                case 2:
                    ColName = "NationalNo";
                        break;
                case 3:
                    ColName = "FullName";
                    break;
                case 4:
                    ColName = "Status";
                    break;

            }
            string  KeyWord = txtFilter.Text.Trim();

            dgvApplications.DataSource = clsApplications.FilterLocalLicenseApplications(ColName,KeyWord);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0) { txtFilter.Visible = false; } else { txtFilter.Visible = true; }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID =(int)dgvApplications.CurrentRow.Cells[0].Value;
            _LocalDrivingLicense =clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            _Application = clsApplications.FindApplicationByApplicationID(_LocalDrivingLicense.ApplicationID);
            _Application.ApplicationTypeStatus = 2;
            if (_Application.Save())
            {
                MessageBox.Show("The Status IS Canceled Seccussfully .. :)");
            }
            else
            {
                MessageBox.Show("Mistake , Try To Work On Your Logic And ComeBack Loser !!!:)");
            }
            _RefreshApplications();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        
                Form frm = new VisionTestScreen((int)dgvApplications.CurrentRow.Cells[0].Value,1);
                frm.ShowDialog();
        

        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            
                Form frm = new VisionTestScreen((int)dgvApplications.CurrentRow.Cells[0].Value,2);
                frm.ShowDialog();
            
        }

        private void drivingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Form frm = new VisionTestScreen((int)dgvApplications.CurrentRow.Cells[0].Value, 3);
                frm.ShowDialog();
            
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID((int)dgvApplications.CurrentRow.Cells[0].Value);
            _Application = clsApplications.FindApplicationByApplicationID(_LocalDrivingLicense.ApplicationID);

          
            int PassedTests = clsTestAppointments.TestsThatAlreadyPassed((int)dgvApplications.CurrentRow.Cells[0].Value);


            switch (PassedTests)
            {
                case 0:
                    scheualTestToolStripMenuItem.Enabled = true;
                    visionTestToolStripMenuItem.Enabled = true;
                    writtenTestToolStripMenuItem.Enabled = false;
                    drivingTestToolStripMenuItem.Enabled = false;
                    issueLicenseToolStripMenuItem.Enabled = false;
                    break;
                case 1:

                    scheualTestToolStripMenuItem.Enabled = true;
                    visionTestToolStripMenuItem.Enabled = false;
                    writtenTestToolStripMenuItem.Enabled = true;
                    drivingTestToolStripMenuItem.Enabled = false;
                    issueLicenseToolStripMenuItem.Enabled = false;
                    break;
                case 2:

                    scheualTestToolStripMenuItem.Enabled = true;
                    visionTestToolStripMenuItem.Enabled = false;
                    writtenTestToolStripMenuItem.Enabled = false;
                    drivingTestToolStripMenuItem.Enabled = true;
                    issueLicenseToolStripMenuItem.Enabled=false;
                    break;
                case 3:
                    scheualTestToolStripMenuItem.Enabled = false;
                    issueLicenseToolStripMenuItem.Enabled = true;
            
                    break;
            }
            if (_Application.ApplicationTypeStatus == 3)
            {

                cancelApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                issueLicenseToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;

            }

        }

        private void issueLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PassedTest = 0;
            int LocalID = (int)dgvApplications.CurrentRow.Cells[0].Value;
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            _Application = clsApplications.FindApplicationByApplicationID(_LocalDrivingLicense.ApplicationID);
            PassedTest = clsTestAppointments.TestsThatAlreadyPassed(LocalID);
            if (_Application.ApplicationTypeStatus==1&&PassedTest==3) {

               
                Form frm = new IssueLicenseForm(LocalID);
                frm.ShowDialog();

            }
          
            _RefreshApplications();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowLicenseData((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplications();
        }
    }
    }

