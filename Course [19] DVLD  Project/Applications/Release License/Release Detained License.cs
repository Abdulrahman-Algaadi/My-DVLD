using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class Release_Detained_License : Form
    {

        int _SelectedLicenseID = -1;
      
        public Release_Detained_License()
        {
            InitializeComponent();
        
        }
        public Release_Detained_License(int LicenseID)
        {
            InitializeComponent();
            ctrFilterLicenseByIDAndShow1.LoadInfo(LicenseID);
            ctrFilterLicenseByIDAndShow1.FilterEnabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new ShowPersonHistoryLicenses(ctrFilterLicenseByIDAndShow1.License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void Release_Detained_License_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            llLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            btnSave.Enabled = false;
        }

        private void Release_Detained_License_Activated(object sender, EventArgs e)
        {
            ctrFilterLicenseByIDAndShow1.FilterFocus();
        }

        private void ctrFilterLicenseByIDAndShow1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text =_SelectedLicenseID.ToString();
            if (_SelectedLicenseID==-1)
            {
                return;
            }
            llLicenseHistory.Enabled = _SelectedLicenseID != -1;
            if (!clsDetainedLicense.IsLicenseDetained(_SelectedLicenseID))
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDetainID.Text = ctrFilterLicenseByIDAndShow1.License.DetainInfo.DetainedID.ToString();
            lblDetainDate.Text  =ctrFilterLicenseByIDAndShow1.License.DetainInfo.DetainDate.ToString();
            lblCreatedBy.Text =clsGlobal.User.UserName.ToString();
            lblApplicationFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            lblFineFees.Text = ctrFilterLicenseByIDAndShow1.License.DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblFineFees.Text) + Convert.ToDecimal(lblApplicationFees.Text)).ToString();

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            bool IsReleased = ctrFilterLicenseByIDAndShow1.License.ReleaseDetainedLicense(clsGlobal.User.UserID,ref ApplicationID);
            lblReleaseByAppID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ctrFilterLicenseByIDAndShow1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

        }
    } 
}
