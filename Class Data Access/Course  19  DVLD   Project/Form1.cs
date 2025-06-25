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
    public partial class Form1 : Form
    {
    public  static  clsUser _User;
        public Form1(clsUser user)
        {
            InitializeComponent();
            _User = user;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Current User : {_User.UserName}";
            this.TransparencyKey = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new LogIN_Form();
            this.Close();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
       

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

          Form frm =new ShowUserData(_User.PersonID);
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
            Form frm = new NewLicenseForm(_User,-1);
            frm .ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new UserScreen();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManagePeople();
            frm.ShowDialog();
        }

        private void localDrivingLisenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageLocalDrivingLicenseApplication(_User);
            frm .ShowDialog();
        }

  
    }
}
