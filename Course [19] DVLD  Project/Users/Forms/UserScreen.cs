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
    public partial class ManageUserScreen : Form
    {
        public ManageUserScreen()
        {
            InitializeComponent();
        }

       
        private static DataTable _dtAllUsers;


        private void UserScreen_Load(object sender, EventArgs e)
        {

            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource =_dtAllUsers;
            cbFilter.SelectedIndex = 0;

        }
        void ConditionsOfTextBox()
        {
        
            txtFilter.Visible = (cbFilter.SelectedIndex == 0)?false:true;

            if (cbFilter.SelectedIndex==5)
            { 
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return;
            }
            else
            {
                cbIsActive.Visible = false;
            }
            txtFilter.Text = "";
            txtFilter.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    break;
                case 2:
                    ColumnName = "UserName";
                    break;
                case 3:
                    ColumnName = "PersonID";
                    break; 
                case 4:
                    ColumnName = "FullName";
                    break;
                
            }

            Filter = txtFilter.Text.Trim(); 
            if (Filter==""||SelectedIndex==0)
            {

                _dtAllUsers.DefaultView.RowFilter ="";
                lblUserCount.Text =_dtAllUsers.Rows.Count.ToString(); ;
                return;
            }

            if (SelectedIndex!=4&&SelectedIndex!=2)
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, Filter);
            }
            else
     
            _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnName, Filter);

            lblUserCount.Text=dgvUsers.Rows.Count.ToString(); 
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new Add_User_Edit(-1);
            frm.ShowDialog();
            UserScreen_Load(null, null);
       
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
            UserScreen_Load(null, null);
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
    
            if (MessageBox.Show($"Are You Sure To Delete The User With : {UserID} ID ? ", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser("UserID", UserID))
                {
                    MessageBox.Show($"The User With ID : {UserID} Is Deleted Seccussfully >>");
                
                }
                else
                    MessageBox.Show($"The User With ID : {UserID} Is not Deleted, There is Data Linked To it >>");

            }
            else
                MessageBox.Show("The Deletion Operation is canceled /..");

            UserScreen_Load(null, null);

         
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            Form frm = new Add_User_Edit(UserID);
            frm.ShowDialog();
            UserScreen_Load(null, null);
  
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            Form form = new ShowUserData(UserID);
            form.ShowDialog();
       
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedUser = (int)dgvUsers.CurrentRow.Cells[0].Value;
            Form frm = new ChangePassWord(SelectedUser);
            frm.ShowDialog();
        
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";
            string ColName = "IsActive";
            switch (cbIsActive.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    FilterValue = "1";
                break;
                case 2:
                    FilterValue = "0";
                    break;
                    
            }

            if (cbIsActive.SelectedIndex==0)
            {
                _dtAllUsers.DefaultView.RowFilter = "";

            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}",ColName,FilterValue);
            }
            lblUserCount.Text =dgvUsers.RowCount.ToString();
        }
    }
}
