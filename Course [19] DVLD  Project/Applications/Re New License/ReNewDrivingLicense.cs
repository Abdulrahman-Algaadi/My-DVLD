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
    public partial class ReNewDrivingLicense : Form
    {

        private int LicenseID=-1;
        private int _NewLicenseID = -1;

        public ReNewDrivingLicense()
        {
            InitializeComponent();
        }
        private void ReNewDrivingLicense_Load(object sender, EventArgs e)
        {
         
            lblAppDate.Text = clsFormat.DateToShort( DateTime.Now);
            lblIssueDate.Text =lblAppDate.Text;
            lblCreatedBy.Text = clsGlobal.User.UserID.ToString();
            lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrFilterLicenseByIDAndShow1.License.RenewLicense(txtNotes.Text, clsGlobal.User.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblReNewAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblReNewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReNew.Enabled = false;
           ctrFilterLicenseByIDAndShow1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
        //    Form frm= new frmShowLocalApplicationDetail();
        //    frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form frm = new ShowPersonHistoryLicenses();
            //frm.ShowDialog();
        }

        private void ctrFilterLicenseByIDAndShow1_OnLicenseSelected(int obj)
        {
            LicenseID = obj;   

           
            lblOldLicenseID.Text =LicenseID.ToString();

            llShowLicenseInfo.Enabled = (LicenseID != -1);
            if (LicenseID==-1)
            {
                return;
            }
            int LengthOfLicense = ctrFilterLicenseByIDAndShow1.License.LicenseClassInfo.ValidtyLengthPfLicense;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(LengthOfLicense));
            txtNotes.Text = ctrFilterLicenseByIDAndShow1.License.Notes;
            lblLicenseFees.Text = ctrFilterLicenseByIDAndShow1.License.LicenseClassInfo.LicenseFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblLicenseFees.Text)+Convert.ToDecimal(lblAppFees.Text)).ToString();

            if (!ctrFilterLicenseByIDAndShow1.License.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrFilterLicenseByIDAndShow1.License.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReNew.Enabled = false;
                return;

            }

            if (!ctrFilterLicenseByIDAndShow1.License.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReNew.Enabled = false;
                return;
            }

            btnReNew.Enabled = true;

        }

        private void ReNewDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrFilterLicenseByIDAndShow1.FilterFocus();
        }
    }
}
