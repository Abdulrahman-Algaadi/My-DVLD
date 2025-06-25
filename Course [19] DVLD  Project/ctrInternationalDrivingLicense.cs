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
    public partial class ctrInternationalDrivingLicense : UserControl
    {

        private int _ApplicationID =-1;

        private int _InternationalLicenseID=-1;
        public  int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
            set { _InternationalLicenseID = value;
                if (_InternationalLicenseID!=-1)
                {
                    lblLicenseID.Text =_InternationalLicenseID.ToString();
                }
            }
            
            }
        clsUser _User;
        public clsUser User {
            get 
            {
                return _User;
            } 
            set { 
                
                _User = value;
                if (_User!=null)
                {
                    lblCreatedByUserID.Text = _User.UserName.ToString();
                } 

            }
        }

        private int _LocalID;
        public int LocalDrivingLicenseID { get {return _LocalID; }set { _LocalID = value;_LoadData(_LocalID); } }
        public int ApplicationID { get {return _ApplicationID; } set { _ApplicationID = value;

                if (_ApplicationID != -1) { 
                lblILAppID.Text = _ApplicationID.ToString();
                }
                
            } }
        clsLocalDrivingLicenseApplication _Local;
        clsApplications _Application;
        public ctrInternationalDrivingLicense()
        {
            InitializeComponent();
        }
        private void _LoadData(int LocalID)
        {
            DateTime Current = DateTime.Now;
          
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            DateTime Future = Current.AddYears(1);
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = Future.ToString("dd/MMM/yyy");
            lblLocalLicenseID.Text = LocalID.ToString();
            
            lblFees.Text = "51";

        }
        private void ctrInternationalDrivingLicense_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
