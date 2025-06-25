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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string UserName=txtUserName.Text.Trim();
            string PassWord = txtPassWord.Text.Trim();
            clsUser _User = clsUser.FindUser(UserName, PassWord);
            
            if (_User!=null)
            {
                Form form = new Form1(_User);
                form.ShowDialog();
            }
            else
                MessageBox.Show("incorrect !! UserName/PassWord","False");
             
        }

        private void LogIN_Form_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

  
    }
}
