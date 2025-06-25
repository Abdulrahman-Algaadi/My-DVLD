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
    public partial class ctrApplicationInfoForReplacement : UserControl
    {
        private decimal _ApplicationFees = -1;
        public decimal ApplicationFees
        {
            get { return _ApplicationFees; }
            set
            {
                _ApplicationFees = value;
                if (_ApplicationFees != -1)
                {
                    lblAppFees.Text = _ApplicationFees.ToString();
                }
            }
        }

        clsUser _User;
        public clsUser User
        {

            get { return _User; }
            set {_User = value;
                if (_User!=null)
                {
                    lblCreatedBy.Text = _User.UserName;
                }
            }
        }
        private int _OldLicenseID=-1;
        public int OldLicenseID { get { return _OldLicenseID; }

            set
            {
                _OldLicenseID = value;
                if (_OldLicenseID!=-1)
                {
                 lblOldLicenseID.Text = _OldLicenseID.ToString();
                    lblAppDate.Text =DateTime.Now.ToString("dd/MMM/yyyy");
                }
            }
        }
        private int _L_R_ApplicationID = -1;
        public int L_R_ApplicationID
        {

            get { return _L_R_ApplicationID; }
            set { _L_R_ApplicationID = value;
           if(_L_R_ApplicationID != -1)
                {
                    lblReplaceAppID.Text =_L_R_ApplicationID.ToString();
                }
            }
        }

        private int _ReplacedLicenseID=-1;
        public int ReplacedLicenseID
        {
            get { return _ReplacedLicenseID; }
            set
            {
                _ReplacedLicenseID = value;
                if (_ReplacedLicenseID!=-1)
                {
                    lblRePlacedLicenseID.Text = _ReplacedLicenseID.ToString();
                }
            }

        }

        public ctrApplicationInfoForReplacement()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
