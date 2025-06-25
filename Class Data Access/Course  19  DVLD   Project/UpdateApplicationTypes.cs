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
    public partial class UpdateApplicationTypes : Form
    {
        clsApplicationTypes _Application;


        public UpdateApplicationTypes(int ApplicationID)
        {
            InitializeComponent();
            _Application = clsApplicationTypes.FindApplicationTypeByID(ApplicationID);
        }

        private void UpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            if (_Application != null)
            {
                lblAppID.Text = _Application.ApplicationTypeID.ToString();
                txtTitle.Text =_Application.ApplicationTitle.ToString();
                txtFees.Text = _Application.ApplicationFees.ToString(); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _Application.ApplicationFees = Convert.ToDecimal(txtFees.Text);
            _Application.ApplicationTitle= txtTitle.Text;

            if (_Application.clsUpdateNameOrFeesOfApplication())
            {
                MessageBox.Show("The Application Type Is Updated Seccussfully ..");
            }
            else
                MessageBox.Show("The Application Type Is not Updated Seccussfully ..");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

