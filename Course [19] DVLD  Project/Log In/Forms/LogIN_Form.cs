using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class LogIN_Form : Form
    {
        public LogIN_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public  void _logInToFile(string Message)
        {
            string FileName = "Log.txt";
            string LoggedUserData = $"User Name : {clsGlobal.User.UserName} , Logged In Date Time [{DateTime.Now}]  ";

            using (StreamWriter Writter =new StreamWriter(FileName,append : true))
            {
                Writter.WriteLine(LoggedUserData);
            }

        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            clsLogger LogUserToFile = new clsLogger(_logInToFile); 
            string UserName=txtUserName.Text.Trim();
            string PassWord = txtPassWord.Text.Trim();
            clsUser _User = clsUser.FindUserByUserNameAndPassWord(UserName, PassWord);

            if (_User != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(UserName, PassWord);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("","");
                }
                if (_User.IsActive==true)
                {
                    clsGlobal.User = _User;
                    this.Hide();

                    LogUserToFile.Log("Log To File .");
           
                    Form form = new frmMain(this);
                   
                    form.ShowDialog();
                  
                }
                else
                {
                    MessageBox.Show("Your Account Is InActive , Contact Your Admin !!");
                }


            }
            else
                MessageBox.Show("incorrect !! UserName/PassWord","False");
             
        }

        private void LogIN_Form_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassWord.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void LogIN_Form_Activated(object sender, EventArgs e)
        {
            if (txtUserName.Text=="")
            {

                txtUserName.Focus();
            }
        }
    }
}
