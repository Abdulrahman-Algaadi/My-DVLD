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
    public partial class Update_TestTypes : Form
    {
        clsApplicationTest _Test;
        public Update_TestTypes(int TestTypeID)
        {
            InitializeComponent();
            _Test =clsApplicationTest.FindByID(TestTypeID);
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadData()
        {
            if (_Test!=null)
            {
                lblTestID.Text = _Test.ID.ToString();
                txtTitle.Text =_Test.TitleTestType.ToString();
                txtDescription.Text = _Test.DescriptionTestType.ToString();
                txtFees.Text =_Test.TestTypesFees.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           _Test.TitleTestType = txtTitle.Text;
            _Test.DescriptionTestType = txtDescription.Text;
            _Test.TestTypesFees = Convert.ToDecimal(txtFees.Text);
            if (_Test.Save())
            {
                MessageBox.Show("Test Type Is Update Seccussfully ..");
                this.Close();
            }
            else
                MessageBox.Show("Test Type Is Not Update Seccussfully ..");



        }
    }
}
