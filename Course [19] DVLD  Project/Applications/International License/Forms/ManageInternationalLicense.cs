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
    public partial class ManageInternationalLicense : Form
    {

        static DataTable _InterNationalLicenses;
        public ManageInternationalLicense()
        {
            InitializeComponent();

        }

        private void ManageInternationalLicense_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            _InterNationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            lblRecord.Text = $"# Records : {dgvInternational.RowCount}";
            dgvInternational.DataSource = _InterNationalLicenses;
            cbFilter.SelectedIndex = 0;
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }

            if (cbFilter.SelectedIndex == 4)
            {
                cbIsActive.Visible = true;
                txtFilter.Visible = false;
            }
            else
            {
                cbIsActive.Visible = false;
                
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new InterNationalDrivingLicense();
            frm.ShowDialog();
            ManageInternationalLicense_Load(null, null);

        }

        private void showPersonDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications _Application = clsApplications.FindApplicationByApplicationID((int)dgvInternational.CurrentRow.Cells[1].Value);

            Form frm = new ShowDetailForm(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowInternationalLicenseInfo((int)dgvInternational.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsApplications.FindApplicationByApplicationID((int)dgvInternational.CurrentRow.Cells[1].Value).ApplicantPersonID;
            Form frm = new ShowPersonHistoryLicenses(PersonID);
            frm.ShowDialog();
            ManageInternationalLicense_Load(null, null);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColName = "", DataToSearchFor = "";

            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    ColName = "ApplicationID";

                    break;
                case 2:
                    ColName = "Int_LicenseID";
                    break;
                case 3:
                    ColName = "DriverID";
                    break;

            }
            DataToSearchFor = txtFilter.Text;

            if (string.IsNullOrEmpty(txtFilter.Text)||cbFilter.SelectedIndex==0)
            {
                _InterNationalLicenses.DefaultView.RowFilter = "";
                lblRecord.Text = $"# Records : {dgvInternational.RowCount}";
                return;

            }
            if (cbFilter.SelectedIndex !=0||cbFilter.SelectedIndex!=4)
            {
                _InterNationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}",ColName, DataToSearchFor);
            }

           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Col = "IsActive";
            string Filter = cbIsActive.Text;

            switch (Filter)
            {
                case "All":
                    break;
                case "Yes":
                    Filter = "1";
                    break;
                case "No":
                    Filter = "0";
                    break;
            }

            if (Filter== "All")
                _InterNationalLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
               _InterNationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}",Col, Filter);

            lblRecord.Text = _InterNationalLicenses.Rows.Count.ToString();
        }
    }
}
