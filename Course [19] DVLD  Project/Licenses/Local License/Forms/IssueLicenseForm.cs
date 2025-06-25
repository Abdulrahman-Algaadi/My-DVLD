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
    public partial class IssueLicenseForm : Form
    {
        clsLocalDrivingLicenseApplication _Local;
      
        int _LocalID = -1;
        public IssueLicenseForm(int LocalDLID)
        {
            InitializeComponent();
            ctrLALAndApplicationDaetails1._LoadData(LocalDLID);

            _LocalID = LocalDLID;
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {


         int LicenseID = _Local.IssueLicenseForTheFirtTime(textBox1.Text,clsGlobal.User.UserID);

            
            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IssueLicenseForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            _Local = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(_LocalID);
            if (_Local==null)
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _Local.GetActiveLicenseID();
            if (LicenseID != -1) {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            ctrLALAndApplicationDaetails1._LoadData(_LocalID);

        }
    }
}
