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
    public partial class Add_User_Edit : Form
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public int UserID { get; set; }
    
        private clsUser _User;

        public Add_User_Edit(int Person_ID)
        {
            InitializeComponent();
            PersonID = Person_ID;
            
            Mode = (PersonID == -1) ? enMode.AddNew : enMode.Update;
            _LoadData();
            ctrFilterPerson_ADD1.DataBack += FilterPerson;

             
        }
        
        public void FilterPerson(object obj,int Person)
        {
            PersonID = Person;
            ctrShowPersonDetail1.PersonID = PersonID;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Add_User_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = "Person Info";
            tabControl1.TabPages[1].Text = "LogIn Info";
             
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserExists(PersonID))
            {
                MessageBox.Show("This Person is Already a User </>","Duplication",  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                lblAdd.Text = "Add New User";

            }
        }
        private void _LoadData()
        {
            if (Mode==enMode.AddNew)
            {
                lblAdd.Text = "Add New User";
                _User = new clsUser();
                return;
            }
         
            _User = clsUser.FindUserByPersonID(PersonID);
            lblAdd.Text = "Update User";
            ctrFilterPerson_ADD1.Enabled = false;
            ctrShowPersonDetail1.PersonID =PersonID;
            ctrFilterPerson_ADD1.FilterTextBoxValue =PersonID.ToString();
            ctrShowPersonDetail1.PersonID = PersonID;
            UserID =_User.UserID;
            lblUserID.Text =_User.UserID.ToString();
            txtUserName.Text =_User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtPasswordConfirm.Text=_User.Password.ToString();   

        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string UserName =txtUserName.Text.Trim();
            if (Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExists(UserName))
                {
                    errorProvider1.SetError(txtUserName, "This UserName Already With Another User");

                }
                else
                {
                    errorProvider1.SetError(txtUserName, "");
                }

            }
           

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!string .IsNullOrWhiteSpace(errorProvider1.GetError(txtUserName)))
            {
                e.Cancel =true;
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
                errorProvider1.SetError(txtPasswordConfirm, "");
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text==""&&txtPassword.Text!=txtPasswordConfirm.Text&&txtPassword.Text!="")
            {
                MessageBox.Show("You Need To Fill The Fields Correctly !!");
             
                return;
            }
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PersonID =PersonID;
            _User.IsActive = (chkIsActive.Checked) ? 1 : 0;

            if (_User.Save())
            {
                MessageBox.Show("User Is Saved Seccussfully :)");
                lblAdd.Text = "Update User";
                lblUserID.Text = $"{_User.UserID}";
                Mode = enMode.Update;
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

        private void ctrFilterPerson_ADD1_Load(object sender, EventArgs e)
        {

        }
    }
}
