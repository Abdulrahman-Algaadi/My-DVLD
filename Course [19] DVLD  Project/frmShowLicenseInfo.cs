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
    public partial class frmShowLicenseInfo : Form
    {
        int _LicenseID = -1;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrShowLicenseInfo1.LoadLicenseData(_LicenseID);
        }
    }
}
