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
    public partial class frmShowLocalApplicationDetail : Form
    {
        public frmShowLocalApplicationDetail(int LocalID)
        {
            InitializeComponent();
            ctrLALAndApplicationDaetails1._LoadData(LocalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
