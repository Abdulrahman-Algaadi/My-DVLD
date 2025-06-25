using clsLogic;
using Guna.UI2.WinForms;
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
    public partial class Add_User_Edit : Form
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
    
        private clsUser _User;

        public Add_User_Edit(int UserID)
        {
            InitializeComponent();
            _User = clsUser.FindUserByID(UserID);
            PersonID = _User.PersonID;
            Mode = (UserID == -1) ? enMode.AddNew : enMode.Update;
            _LoadData();
      

             
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode==enMode.AddNew)
            {

                if (clsUser.IsUserExists(PersonID))
                {
                    MessageBox.Show("This Person is Already a User </>", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tabControl1.SelectedIndex = 1;
                    groupBox1.Enabled = true;
                    btnSave.Enabled = true;
                    lblAdd.Text = "Add New User";

                }
            }
            else
            {
                tabControl1.SelectedIndex = 1;
            }
        }
        private void _LoadData()
        {
            if (Mode==enMode.AddNew)
            {
                lblAdd.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();
                return;
            }
   
            this.Text = "Update User";
          
            lblAdd.Text = "Update User";
            ctrFilterPerson_ADD1.Enabled = false;
            ctrShowPersonDetail1.PersonID =_User.PersonID;
            ctrFilterPerson_ADD1.FilterTextBoxValue =_User.PersonID.ToString();
            lblUserID.Text =_User.UserID.ToString();
            txtUserName.Text =_User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtPasswordConfirm.Text=_User.Password.ToString(); 
            chkIsActive.Checked = _User.IsActive;
           
           
        }
        

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!string .IsNullOrWhiteSpace(errorProvider1.GetError(txtUserName)))
            {
                e.Cancel =true;
            }
            string UserName = txtUserName.Text.Trim();

            if (Mode==enMode.AddNew)
            {
                if (clsUser.IsUserExists(UserName))
                {

                    errorProvider1.SetError(txtUserName, "This UserName Already With Another User !!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtUserName, "");
                }
            }
            else
            {
                if (_User.UserName!=txtUserName.Text)
                {
                    if (clsUser.IsUserExists(UserName))
                    {

                        errorProvider1.SetError(txtUserName, "This UserName Already With Another User !!");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, "");
                    }
                }
            }
           
        }

        private void txtPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            string Password =txtPassword.Text.Trim();
            if (txtPasswordConfirm.Text != Password)
            {
                errorProvider1.SetError(txtPasswordConfirm, "It must Be Similar To The First Password !!");
            }
            else
                errorProvider1.SetError(txtPasswordConfirm, null);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Put The Mouse over The read Icon And Fix The Error As Instructed !!","Validation Error",MessageBoxButtons
                    .OK,MessageBoxIcon.Error);
                return;
            }
           
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PersonID =PersonID;
            _User.IsActive = (chkIsActive.Checked) ? true :false;

            if (_User.Save())
            {
                MessageBox.Show("User Is Saved Seccussfully :)");
                lblAdd.Text = "Update User";
                lblUserID.Text = $"{_User.UserID}";
                Mode = enMode.Update;
                this.Text = "Update User";
            }
            else
            {
                MessageBox.Show("User Is Not Saved Seccussfully :)");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Add_User_Edit_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnSave.Enabled = false;
            if (Mode==enMode.Update)
            {
                groupBox1.Enabled = true;
                btnSave.Enabled = true;
            }
        }

      
    }
}
