using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsLogic;

namespace Course__19__DVLD___Project
{
    public partial class frmMain : Form
    {
    public  static  clsUser _User =clsGlobal.User;
        private LogIN_Form _Form;
        
        public frmMain(LogIN_Form LogIn)
        {
            InitializeComponent();
            
            _Form = LogIn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Current User : {_User.UserName}";
            this.TransparencyKey = Color.Black;

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.User = null;
            _Form.Show();
            this.Close();
          
        }

       

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form frm =new ShowUserData(_User.UserID);
          frm .ShowDialog();
        }

        private void changePassWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ChangePassWord(_User.PersonID);
            form .ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageApplicationTypes();
            frm .ShowDialog();  
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageTestTypes();
            frm .ShowDialog();
        }

        private void drivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ClsAdd_UpdateLocalApplication();
            frm .ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageUserScreen();
            frm.ShowDialog();
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManagePeople();
            frm.ShowDialog();
        }

        private void localDrivingLisenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageLocalDrivingLicenseApplication();
            frm .ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DriversScreen();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new InterNationalDrivingLicense(_User);
            frm.ShowDialog();   
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageInternationalLicense(_User);
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ReNewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ReplacementForLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void detainDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DetainLicenseScreen();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new DetainLicenseScreen();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Release_Detained_License(_User);
            frm.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageDetainedLicenses(_User);
            frm.ShowDialog();
        }

        private void reTakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm  =new  frmManageLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
    }
}
