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
    public partial class ctrDetain_Release : UserControl
    {
        clsUser _User;
        public delegate void SendDataBack(object obj,decimal Fees);
        public SendDataBack DataBack;
        public clsUser User
        {
            get { return _User; }
            set { _User = value;
                if (_User!=null)
                {
                    lblCreatedBy.Text = _User.UserName;
                }
            
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {

            get { return _LicenseID; }
            set
            {
                _LicenseID = value;
                if (_LicenseID!=-1)
                {
                    lblLicenseID.Text = _LicenseID.ToString();
                    lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                }
            }
        }


  
        public ctrDetain_Release()
        {
            InitializeComponent();
        }

        private void ctrDetain_Release_Load(object sender, EventArgs e)
        {

        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            decimal Fees = decimal.Parse(txtFees.Text);
            DataBack?.Invoke(this, Fees);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (txtFees.Text==string.Empty)
            {
                e.Cancel = true;
                MessageBox.Show("You need To Put The Amount Of Fees : ..");
            }
            else
            {
                e.Cancel= false;
            }
       
            
        }

        private void grpDetain_Release_Enter(object sender, EventArgs e)
        {

        }
    }
}
