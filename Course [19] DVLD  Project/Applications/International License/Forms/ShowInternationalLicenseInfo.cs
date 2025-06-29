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
    public partial class ShowInternationalLicenseInfo : Form
    {
        public ShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            ctrShowInternationalLicense1.InternationalLicenseID = InternationalLicenseID;
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
