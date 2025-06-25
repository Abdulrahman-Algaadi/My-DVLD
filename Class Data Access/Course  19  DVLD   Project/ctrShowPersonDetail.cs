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
              
        private clsBusiness _Person;
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



        private string _FullName()
        {
            return _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
        }
        public void LoadPersonData()
        {
            _Person = clsBusiness.FindPerson(PersonID);
            if (_Person == null)
            {
            
                return;
            }

            lblName.Text = _FullName();
            lblDateOfBirth.Text = _Person.BirthDate.ToShortDateString();
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblNationalNo.Text = _Person.NationalNo;
            lblCountry.Text = clsBusiness.FindCountry(_Person.NatialityCountryID);
            lblAddress.Text = _Person.Address;
            pbPersonal.ImageLocation = _Person.ImagePath;
            lblPersonID.Text = PersonID.ToString();
        }

        private void ctrShowPersonDetail_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Add_Person_EditForm(this.PersonID);
            frm.ShowDialog();
            LoadPersonData();
        }
    }
}
