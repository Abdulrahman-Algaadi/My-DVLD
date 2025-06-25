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
    public partial class ctrShowLicenseInfo : UserControl
    {

        private int _LicenseID = 0;
        public int LicenseID{ get; set; }
       
        
      public  clsLicense _License;
    
        public ctrShowLicenseInfo()
        {
            InitializeComponent();
        }
    
        public void LoadLicenseData(int LICENSEID)
        {
            LicenseID = LICENSEID;
            _License =clsLicense.FindLicenseByLicenseID(LICENSEID);
            if (_License==null)
            {
                MessageBox.Show($"There IS no License ID Like {LICENSEID} !!","Error",MessageBoxButtons.OK);
                return;
            }

            lblclsName.Text =_License.LicenseClassInfo.LicenceClassName.ToString();
            lblName.Text = _License.DriverInfo.PersonInfo.FullName();
            lblLicenseID.Text =_License.LicenseID.ToString();
            lblNationalNo.Text =_License.DriverInfo.PersonInfo.NationalNo.ToString();
            lblGendor.Text = (_License.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToString();
            lblIssueReason.Text =_License.IssueReasonText.ToString();
            lblNotes.Text = _License.Notes.ToString();
            lblIsActive.Text = (_License.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text =_License.DriverInfo.PersonInfo.BirthDate.ToString();
            lblDriverID.Text =_License.DriverID.ToString();
            lblExpirationDate.Text =_License.ExpirationDate.ToString();
            pictureBox1.ImageLocation = string.IsNullOrEmpty(_License.DriverInfo.PersonInfo.ImagePath)?"": _License.DriverInfo.PersonInfo.ImagePath;
         
        }
        
    }
}
