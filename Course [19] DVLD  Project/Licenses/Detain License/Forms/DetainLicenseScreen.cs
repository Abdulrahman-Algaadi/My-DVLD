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
    public partial class DetainLicenseScreen : Form
    {
        private  int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public DetainLicenseScreen()
        {
            InitializeComponent();
        }


        private void ctrFilterLicenseByIDAndShow1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llLicenseHistory.Enabled = (_SelectedLicenseID != -1);
            if (_SelectedLicenseID ==-1)
            {
                return;
            }
            if (clsDetainedLicense.IsLicenseDetained(_SelectedLicenseID))
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFees.Focus();
            btnSave.Enabled = (true) ;


        }


        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            };


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };
        }

        private void DetainLicenseScreen_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.User.UserName;

            llLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrFilterLicenseByIDAndShow1.License.Detain(Convert.ToDecimal(txtFees.Text),clsGlobal.User.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            ctrFilterLicenseByIDAndShow1.FilterEnabled = false;
            txtFees.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm =new  frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(ctrFilterLicenseByIDAndShow1.License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void DetainLicenseScreen_Activated(object sender, EventArgs e)
        {
            ctrFilterLicenseByIDAndShow1.FilterFocus();
        }
    }
}
