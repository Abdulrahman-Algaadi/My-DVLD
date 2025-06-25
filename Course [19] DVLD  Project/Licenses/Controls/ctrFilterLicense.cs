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
using System.Xml.Serialization;

namespace Course__19__DVLD___Project
{
    public partial class ctrFilterLicense : UserControl
    {

        clsLicense _License;

        public delegate void SendDataBack(object obj,int LicenseID);
        public SendDataBack DataBack;


        public ctrFilterLicense()
        {
            InitializeComponent();
        }

        private void txtFilterLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(txtFilterLicense.Text);

                if (clsLicense.IsLicenseExists(LicenseID))
                {
                

                    DataBack?.Invoke(this, LicenseID);
                }
                else
                    MessageBox.Show($"The license ID With Number {LicenseID} Dos'nt Exist ");
            
        }

     
    }
}
