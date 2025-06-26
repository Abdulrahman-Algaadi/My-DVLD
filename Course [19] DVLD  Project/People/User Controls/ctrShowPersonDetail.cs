using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ctrShowPersonDetail : UserControl
    {
        private int _Person_ID ;
        public int PersonID {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
                LoadPersonData();

            }
        }
              
        private clsPerson _Person;
        public ctrShowPersonDetail()
        {
            InitializeComponent();
           
        } 
      

     
        private void btnClose_Click(object sender, EventArgs e)
        {
            Form ParentForm = this.FindForm();
            if (ParentForm!=null)
            {
                ParentForm.Close(); 
            }
        }



        private void LoadPersonData()
        {
            _Person = clsPerson.FindPerson(PersonID);
            if (_Person == null)
            {
            
                return;
            }

            lblName.Text = _Person.FullName();
            lblDateOfBirth.Text = _Person.BirthDate.ToShortDateString();
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblNationalNo.Text = _Person.NationalNo;
            lblCountry.Text = _Person.CountryInfo.CountryName.ToString();
            lblAddress.Text = _Person.Address;
            pbPersonal.ImageLocation = _Person.ImagePath;
            lblPersonID.Text = PersonID.ToString();
        }

    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Add_Person_EditForm(this.PersonID);
            frm.ShowDialog();
            LoadPersonData();
        }
    }
}
