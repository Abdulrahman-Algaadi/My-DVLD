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
    public partial class ctrDetainInfo : UserControl
    {
        public clsDetainedLicense _DetainedLicense;
        public clsUser _User;
        private int _LicenseID = -1;

        private int _ReleasedApplicationID = -1;
        public int ReleasedApplicationID
        {
            get
            {
                return _ReleasedApplicationID;
            }
            set
            {
                _ReleasedApplicationID = value;
                if (_ReleasedApplicationID!=-1)
                {
                    lblReleaseByAppID.Text = _ReleasedApplicationID.ToString();
                }
            }

        }
        public int LicenseID
        {

            get { return _LicenseID; }
            set
            {
                _LicenseID = value;
                if (_LicenseID != -1)
                {
                    lblLicenseID.Text = _LicenseID.ToString();
                    _DetainedLicense = clsDetainedLicense.FindDetainedLicenseByLicenseID(_LicenseID);
                    lblDetainID.Text = _DetainedLicense.DetainedID.ToString();
                    _User = clsUser.FindUserByID(_DetainedLicense.CreatedByUserID);
                    lblCreatedBy.Text =_User.UserName.ToString();
                    lblApplicationFees.Text =15.ToString(); 
                    lblTotalFees.Text =(15+_DetainedLicense.FineFees).ToString();
                    lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("dd/MMM/yyyy");
                    lblFineFees.Text =_DetainedLicense.FineFees.ToString();


                }
            }
        }

        public ctrDetainInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
