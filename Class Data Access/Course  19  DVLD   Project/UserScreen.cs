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
    public partial class UserScreen : Form
    {
        public UserScreen()
        {
            InitializeComponent();
        }

        private void UserScreen_Load(object sender, EventArgs e)
        {
            _RefreshAllUsers();
           
        
        }
        void ConditionsOfTextBox()
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
            }
            else {
            txtFilter.Visible=true;
            }

            if (cbFilter.SelectedIndex==5)
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
            }
            else
            {
                cbIsActive.Visible = false;
            }
        }
        private void _RefreshAllUsers()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            lblUserCount.Text = $"# Records [{dgvUsers.RowCount}]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.
                Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            string Filter = "";
            int SelectedIndex = cbFilter.SelectedIndex;
            switch (SelectedIndex)
            {
                case 1:
                    ColumnName = "UserID";
                    Filter = txtFilter.Text.Trim();
                    break;
                case 2:
                    ColumnName = "UserName";
                    Filter = txtFilter.Text.Trim();
                    break;
                    case 3:
                    ColumnName = "PersonID";
                    Filter = txtFilter.Text.Trim();
                    break; 
                    case 4:
                    ColumnName = "FullName";
                    Filter = txtFilter.Text.Trim();
                    break;
                    case 5:
                    ColumnName = "IsActive";
                    Filter = (cbIsActive.SelectedIndex != 0 && cbIsActive.SelectedIndex == 1) ? "1" : "2";
                    break;


            }
          

            dgvUsers.DataSource = clsUser.FilterUsersBy(Filter,ColumnName);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new Add_User_Edit(-1);
            frm.ShowDialog();
            _RefreshAllUsers();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1||cbFilter.SelectedIndex==3)
            {


                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the key press
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionsOfTextBox();
        }

      
        private void addNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new Add_User_Edit(-1);
            frm.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
    
            if (MessageBox.Show($"Are You Sure To Delete The User With : {UserID} ID ? ", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser("UserID", UserID))
                {
                    MessageBox.Show($"The User With ID : {UserID} Is Deleted Seccussfully >>");
                    _RefreshAllUsers();
                }
                else
                    MessageBox.Show($"The User With ID : {UserID} Is not Deleted, There is Data Linked To it >>");

            }
            else
                MessageBox.Show("The Deletion Operation is canceled /..");

         
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvUsers.CurrentRow.Cells[1].Value;

            Form frm = new Add_User_Edit(PersonID);
            frm.ShowDialog();
            _RefreshAllUsers();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvUsers.CurrentRow.Cells[1].Value;
            Form form = new ShowUserData(PersonID);
            form.ShowDialog();
            _RefreshAllUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedUser = (int)dgvUsers.CurrentRow.Cells[1].Value;
            Form frm = new ChangePassWord(SelectedUser);
            frm.ShowDialog();
            _RefreshAllUsers();
        }
    }
}
