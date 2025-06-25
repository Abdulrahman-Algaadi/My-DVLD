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
        public ChangePassWord(int UserID)
        {
            InitializeComponent();
            _User =clsUser.FindUserByID(UserID);
            ctrShowUserDetails1.LoadData(_User);
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Reqauired ,Go And Follow  The Red Icon To Fix Them !!","Validations",MessageBoxButtons.OK);
                return;
            }

              _User.Password = txtNewPassword.Text;
              if(_User.Save())
              {
                    MessageBox.Show("Password Is Changed Seccussfully :)");
              }
              
        }


        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            string CurrentPassword = _User.Password;
            if (string.IsNullOrEmpty( txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The Current Password can't Be Empty !! ");
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

            if (CurrentPassword != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The PassWord Of This User is incorrect !! ");
            }
            else
                errorProvider1.SetError(txtCurrentPassword, "");

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if ( string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "The New PassWord Can't be Empty !! ");
            }
            else
                errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password Can't Be Empty !!");
              
            }
            else errorProvider1.SetError(txtNewPassword, "");

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "it Must Be The Same As You Wrote Your New PassWord !!");
            }
            else errorProvider1.SetError(txtConfirmPassword, "");

        }
    }
}
