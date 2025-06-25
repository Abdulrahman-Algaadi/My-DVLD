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
    public partial class ManageDetainedLicenses : Form
    {
        clsUser _User;
        public ManageDetainedLicenses(clsUser User)
        {
            InitializeComponent();
            _User = User;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new DetainLicenseScreen(_User);
            frm.ShowDialog();
        }
        private void _LoadData()
        {
            dgvDetainedLicenses.DataSource = clsDetainedLicense.GetAllDetainedLicense();
            lblRecord.Text = $"# Records : {dgvDetainedLicenses.RowCount}";
        }



        private void ManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            cbFilter.SelectedIndex = 0;
            _LoadData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson _Person = clsPerson.FindPerson((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            Form form = new ShowDetailForm(_Person.PersonID);
            form.ShowDialog();
            _LoadData();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense _Issued = clsLicense.FindLicenseByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            clsLocalDrivingLicenseApplication _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_Issued.ApplicationID);
            Form frm = new frmShowLocalApplicationDetail(_Local.LocalDrivingLicenseAppID);
            frm.ShowDialog();
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Release_Detained_License(_User);
            form.ShowDialog();
        }

        private void showPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense _Issued = clsLicense.FindLicenseByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            clsLocalDrivingLicenseApplication _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_Issued.ApplicationID);
            Form frm = new ShowPersonHistoryLicenses(_Local.LocalDrivingLicenseAppID);
            frm.ShowDialog();
            _LoadData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex==0)
            {
                txtFilter.Enabled=false;
            }
            else
            {
                txtFilter.Enabled=true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            string ColumnName = "", FilterBy = "";
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    ColumnName = "D_ID";
                    FilterBy= txtFilter.Text;
                    break;

                case 2:
                    ColumnName = "L_ID";
                    FilterBy = txtFilter.Text;
                    break;

                case 3:

                    ColumnName = "Is_Released";
                    FilterBy = txtFilter.Text;
                    break;

                case 4:
                    ColumnName = "N_No";
                    FilterBy = txtFilter.Text;
                    break;

                case 5:
                    ColumnName = "FullName";
                    FilterBy = txtFilter.Text;
                    break;

                case 6:
                    ColumnName = "Release_App_ID";
                    FilterBy = txtFilter.Text;
                    break;
                  
            }
            dgvDetainedLicenses.DataSource = clsDetainedLicense.FilterDetainedBy(ColumnName,FilterBy);

        }
    }
}
