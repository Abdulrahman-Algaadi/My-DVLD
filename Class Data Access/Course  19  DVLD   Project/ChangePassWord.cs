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
    public partial class ChangePassWord : Form
    {
        clsUser _User;
        public ChangePassWord(int PersonID)
        {
            InitializeComponent();
            ctrShowUserDetails1.DataBack += _GetUserData;
            ctrShowUserDetails1.PersonID =PersonID;
        }

        private void _GetUserData(object obj,clsUser User)
        {
            _User = User;
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            string CurrentPassword = _User.Password;
            if (CurrentPassword != txtCurrentPassword.Text.Trim())
            {
                errorProvider1.SetError(txtCurrentPassword, "The PassWord Of This User is incorrect !! ");
            }
            else
                errorProvider1.SetError(txtCurrentPassword, "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text!=txtConfirmPassword.Text&&_User.Password!=txtCurrentPassword.Text)
            {
                MessageBox.Show("Wrong , Fill The Fields As Reqiuered !!","Check");
                return;
            }
            else
            {
                _User.Password = txtNewPassword.Text;
              if(_User.Save())
                {
                    MessageBox.Show("Password Is Changed Seccussfully :)");
                }
              
            }
            
        }

        private void ChangePassWord_Load(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Password Can't Be Empty !!");
                return;
            }
            else errorProvider1.SetError(txtNewPassword, "");

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "it Must Be The Same As You Wrote Your New PassWord !!");
            }
            else errorProvider1.SetError(txtConfirmPassword, "");
            

        }
    }
}
