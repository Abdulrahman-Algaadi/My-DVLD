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
        clsUser _User = clsGlobal.User;
        public static DataTable dtLocalApplicationLicense;
        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();

        }




        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            dtLocalApplicationLicense = clsLocalDrivingLicenseApplication.GetAllLocalApplications();
            dgvApplications.DataSource = dtLocalApplicationLicense;
            lblRecords.Text = "# Records  :" + dgvApplications.RowCount.ToString();
            cbFilter.SelectedIndex = 0;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new ClsAdd_UpdateLocalApplication();
            frm.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            int IndexCombo = cbFilter.SelectedIndex;

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
            string KeyWord = txtFilter.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                dtLocalApplicationLicense.DefaultView.RowFilter = "";
                lblRecords.Text = "# Records  :" + dgvApplications.RowCount.ToString();
                return;
            }
            if (IndexCombo == 1)
            {
                dtLocalApplicationLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColName, KeyWord);
            }
            else
            {
                dtLocalApplicationLicense.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColName, KeyWord);
            }

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0) { txtFilter.Visible = false; } else { txtFilter.Visible = true; }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dgvApplications.CurrentRow.Cells[0].Value;
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            _LocalDrivingLicense.ApplicationStatus = (clsApplications.enApplicationStatus)2;
            if (MessageBox.Show($"Are You sure To Cancel The Application With ID {LocalID} ? ", "Cancel", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (_LocalDrivingLicense.SetCancel())
                {
                    MessageBox.Show("The Status Is Canceled Seccussfully .. :)");
                }
                else
                {
                    MessageBox.Show("Mistake , Try To Work On Your Logic And ComeBack Loser !!!:)");
                }
            }
            else
            {
                MessageBox.Show("Cancel Operation is canceled ..");
            }

            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form frm = new TestScreens((int)dgvApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplication_Load(null, null);


        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form frm = new TestScreens((int)dgvApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplication_Load(null, null);

        }

        private void drivingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new TestScreens((int)dgvApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplication_Load(null, null);

        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            //showLicenseInfoToolStripMenuItem.Enabled = false;
            //switch (PassedTests)
            //{
            //    case 0:
            //        scheualTestToolStripMenuItem.Enabled = true;
            //        visionTestToolStripMenuItem.Enabled = true;
            //        writtenTestToolStripMenuItem.Enabled = false;
            //        drivingTestToolStripMenuItem.Enabled = false;
            //        issueLicenseToolStripMenuItem.Enabled = false;
            //        break;
            //    case 1:

            //        scheualTestToolStripMenuItem.Enabled = true;
            //        visionTestToolStripMenuItem.Enabled = false;
            //        writtenTestToolStripMenuItem.Enabled = true;
            //        drivingTestToolStripMenuItem.Enabled = false;
            //        issueLicenseToolStripMenuItem.Enabled = false;
            //        break;
            //    case 2:

            //        scheualTestToolStripMenuItem.Enabled = true;
            //        visionTestToolStripMenuItem.Enabled = false;
            //        writtenTestToolStripMenuItem.Enabled = false;
            //        drivingTestToolStripMenuItem.Enabled = true;
            //        issueLicenseToolStripMenuItem.Enabled=false;
            //        break;
            //    case 3:
            //        scheualTestToolStripMenuItem.Enabled = false;
            //        issueLicenseToolStripMenuItem.Enabled = true;

            //        break;
            //}
            //if (_LocalDrivingLicense.ApplicationStatus ==(clsApplications.enApplicationStatus) 3)
            //{

            //    cancelApplicationToolStripMenuItem.Enabled = false;
            //    editApplicationToolStripMenuItem.Enabled = false;
            //    issueLicenseToolStripMenuItem.Enabled = false;
            //    deleteApplicationToolStripMenuItem.Enabled = false;
            //    showLicenseInfoToolStripMenuItem.Enabled = true;

            //}
            //if (_LocalDrivingLicense.ApplicationStatus == (clsApplications.enApplicationStatus)2)
            //{
            //    scheualTestToolStripMenuItem.Enabled = false;
            //    deleteApplicationToolStripMenuItem.Enabled = true;
            //}

            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID((int)dgvApplications.CurrentRow.Cells[0].Value);

            int PassedTests = clsTestAppointments.TestsThatAlreadyPassed((int)dgvApplications.CurrentRow.Cells[0].Value);

            bool IsLicenseExists = _LocalDrivingLicense.IsLicenseIssued();

            issueLicenseToolStripMenuItem.Enabled = (PassedTests == 3) && !IsLicenseExists;
            showLicenseInfoToolStripMenuItem.Enabled = IsLicenseExists;
            editApplicationToolStripMenuItem.Enabled = !IsLicenseExists && _LocalDrivingLicense.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New;
            cancelApplicationToolStripMenuItem.Enabled = _LocalDrivingLicense.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New;
            scheualTestToolStripMenuItem.Enabled = !IsLicenseExists && PassedTests < 3;
            deleteApplicationToolStripMenuItem.Enabled = _LocalDrivingLicense.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New;

            bool VisionTest = _LocalDrivingLicense.DosePassedTest(clsTestTypes.enTestType.VisionTest);
            bool WritingTest = _LocalDrivingLicense.DosePassedTest(clsTestTypes.enTestType.WrittenTest);
            bool PracticalTest = _LocalDrivingLicense.DosePassedTest(clsTestTypes.enTestType.StreetTest);


            scheualTestToolStripMenuItem.Enabled = (!VisionTest || !WritingTest || !PracticalTest) && (_LocalDrivingLicense.ApplicationStatus == clsApplications.enApplicationStatus.New);

            if (scheualTestToolStripMenuItem.Enabled)
            {
                visionTestToolStripMenuItem.Enabled =!VisionTest;

                writtenTestToolStripMenuItem.Enabled =VisionTest &&!WritingTest;

                drivingTestToolStripMenuItem.Enabled =VisionTest &&WritingTest&&!PracticalTest;
            }

        }

        private void issueLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PassedTest = 0;
            int LocalID = (int)dgvApplications.CurrentRow.Cells[0].Value;
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
            PassedTest = clsTestAppointments.TestsThatAlreadyPassed(LocalID);
            if (_LocalDrivingLicense.ApplicationInfo.ApplicationStatus == (clsApplications.enApplicationStatus.Completed) &&PassedTest==3) {

                Form frm = new IssueLicenseForm(LocalID);
                frm.ShowDialog();

            }
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID((int)dgvApplications.CurrentRow.Cells[0].Value);
            int LicenseID = clsLicense.FindLicenseByApplicationID(_LocalDrivingLicense.ApplicationID).LicenseID;
            
            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dgvApplications.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are You Sure To Delete This Application ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplication.DeleteApplication(LocalID))
                {
                    MessageBox.Show($"The Application Is Deleted Seccussfully With ID {LocalID}");
                }
                else
                {
                    MessageBox.Show($"The Application Is not Deleted Seccussfully With ID {LocalID}");
                }
                    
            }
            else
                MessageBox.Show("Operation is canceled ..");


            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsAdd_UpdateLocalApplication frm =new ClsAdd_UpdateLocalApplication((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLocalApplicationDetail((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
    }

