using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ctrFilterLicenseByIDAndShow : UserControl
    {
        public clsLicense License;
        
        public event Action<int> OnLicenseSelected;

        public void FilterFocus()
        {
            txtFilterByLicenseID.Focus();
        }
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler!=null)
            {
                handler(LicenseID);
            }
        }

        public ctrFilterLicenseByIDAndShow()
        {
            InitializeComponent();
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return ctrShowLicenseInfo1.LicenseID; }
        }
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                 groupBox1.Enabled = _FilterEnabled;
            }
        }
        private void txtFilterByLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
        private void _LoadInfo(int LicenseID)
        {
            ctrShowLicenseInfo1.LoadLicenseData(LicenseID);
            if (OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(LicenseID);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilterByLicenseID.Focus();
                return;

            } 
            int LicenseID =int.Parse(txtFilterByLicenseID.Text);
            License = clsLicense.FindLicenseByLicenseID(LicenseID);
            if (License==null)
            {
                MessageBox.Show($"There is No License With ID {txtFilterByLicenseID.Text}","Error",MessageBoxButtons.OK);
                return;
            }
            _LoadInfo(LicenseID);


        }

     
        private void txtFilterByLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterByLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterByLicenseID, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterByLicenseID, null);
            }
        }
    }
}
