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
using static clsLogic.clsLicense;

namespace Course__19__DVLD___Project
{
    public partial class ReplacementForLostOrDamagedLicense : Form
    {
        int _NewLicenseID = -1;

        public decimal ApplicationFees {  get; set; }   
        public ReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();
         
     
        }

        private int _GetApplicationTypeID()
        {
            //this will decide which application type to use accirding 
            // to user selection.

            if (rdbDamaged.Checked)

                return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rdbDamaged.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            grpReplacement.BringToFront();
            ctrFilterLicenseByIDAndShow1.SendToBack();
            btnIssueReplacement.Enabled = false;
            rdbDamaged.Checked =true;
        }

        private void rdbDamaged_CheckedChanged(object sender, EventArgs e)
        {
       
            if (rdbDamaged.Checked == true)
            {
                lblTitle.Text = "Replacement For Damaged License";
                this.Text =lblTitle.Text;
                lblAppFees.Text =clsApplicationTypes.FindApplicationTypeByID(_GetApplicationTypeID()).ApplicationFees.ToString();
            }
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //Form frm = new ShowPersonHistoryLicenses(_LocalApplication.LocalDrivingLicenseAppID);
            //frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //clsLocalDrivingLicenseApplication _NewLocal = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(_NewApplication.ApplicationID);
            //Form frm = new frmShowLocalApplicationDetail(_NewLocal.LocalDrivingLicenseAppID);
            //frm.ShowDialog();
        }

        private void ctrApplicationInfoForReplacement1_Load(object sender, EventArgs e)
        {

        }

        private void rdbLost_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdbLost.Checked == true) {
                lblTitle.Text = "Replacement For Lost License";
                this.Text = lblTitle.Text;
                lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID(_GetApplicationTypeID()).ApplicationFees.ToString();
            }
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrFilterLicenseByIDAndShow1.License.Replace(_GetIssueReason(), clsGlobal.User.UserID);

            lblReplaceAppID.Text =NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRePlacedLicenseID.Text =_NewLicenseID.ToString();

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrFilterLicenseByIDAndShow1.FilterEnabled = false;
            grpReplacement.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            btnIssueReplacement.Enabled = false;

        }

        private void ctrFilterLicenseByIDAndShow1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            lblOldLicenseID.Text = LicenseID.ToString();
            lblCreatedBy.Text =clsGlobal.User.UserName;
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            if (LicenseID==-1)
            {
                return;
            }

            if (!ctrFilterLicenseByIDAndShow1.License.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
             , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;


        }

        private void ReplacementForLostOrDamagedLicense_Activated(object sender, EventArgs e)
        {
            ctrFilterLicenseByIDAndShow1.FilterFocus();
        }
    }
}
