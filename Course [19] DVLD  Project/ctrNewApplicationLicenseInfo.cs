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
    public partial class ctrNewApplicationLicenseInfo : UserControl
    {
        clsUser _User;
        private int _LicenseID=-1;

        public delegate void SendDataBack(object o,string Notes);
        public SendDataBack DataBack;
        public int LicenseID {
            get
            {
                return _LicenseID;            
            }
            set
            {
                _LicenseID = value;
                if (_LicenseID != -1)
                {

                    lblOldLicenseID.Text = _LicenseID.ToString();
                    _LoadData();
                }
            }
        }
        private int _R_ApplicationID;

        public int ReNewApplicationID { 
        
            get { return  _R_ApplicationID; }
            set { _R_ApplicationID = value;
            lblReNewAppID.Text = _R_ApplicationID.ToString();

            }
        }
        private int _RenewedLicenseID;
        public int RenewedLicenseID
        {
            get { return _RenewedLicenseID; }
            set { _RenewedLicenseID = value;
                lblReNewedLicenseID.Text = _RenewedLicenseID.ToString();        
            }
        }

        clsLicense _IssuedLicense;
        clsApplicationTypes _ApplicationTypes;
        clsApplications _Applications;
        public clsUser User { 
            get { return _User; }
            set { _User = value;
                if (_User!=null)
                {

                    lblCreatedBy.Text = _User.UserName.ToString();
                }
            }
        }

        public ctrNewApplicationLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _Applications = clsApplications.FindApplicationByApplicationID(_IssuedLicense.ApplicationID);
            _ApplicationTypes = clsApplicationTypes.FindApplicationTypeByID(_ApplicationTypes.ApplicationTypeID);
            decimal AppFees = _ApplicationTypes.ApplicationFees;
            decimal LicenseFees = 20;
            _IssuedLicense =clsLicense.FindLicenseByLicenseID(LicenseID);
            string Notes = "";
            DateTime Current = DateTime.Now;
            DateTime Future = Current.AddYears(10);
            if (_IssuedLicense!=null)
            {
                _Applications = clsApplications.FindApplicationByApplicationID(_IssuedLicense.ApplicationID);
                lblAppFees.Text = AppFees.ToString ();
                lblLicenseFees.Text = LicenseFees.ToString ();
                lblTotalFees.Text = (LicenseFees+AppFees).ToString();
             
                lblAppDate.Text = _Applications.ApplicationDate.ToString("dd/MMM/yyyy");
                lblIssueDate.Text = Current.ToString("dd/MMM/yyyy");
                lblExpirationDate.Text = Future.ToString("dd/MMM/yyyy");
                Notes =txtNotes.Text.ToString();
                DataBack?.Invoke(this, Notes);

            }

        }
        private void ctrNewApplicationLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
