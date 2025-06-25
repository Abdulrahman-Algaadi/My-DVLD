using clsLogic;
using Course__19__DVLD___Project.Properties;
using Guna.UI2.WinForms.Suite;
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


    
    public partial class ctrAddNewPerson : UserControl
    {


        public delegate void SendDataBack(object Sender, int ID);
        public event SendDataBack DataBack;

        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set
            {
                _PersonID = value;
                Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
            }
        }
        enum enMode
        {
            Update,AddNew
        }
        enMode Mode = enMode.AddNew;
    
        clsBusiness _Person;
        public ctrAddNewPerson()
        {
            

            InitializeComponent();

           
        }
        private void _LoadData()
        {
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            FillCountriesinComboBox();
            dtpBirthDate.Value = dtpBirthDate.Value.AddYears(-18);

            if (Mode == enMode.AddNew)
            {
                lblAddNew_Edit.Text = "Add New Person";
                _Person = new clsBusiness();
                llRemoveImage.Visible = false;
                return;
            }
            else
            {
                lblAddNew_Edit.Text = $"Edit Mode For {PersonID}";
                lblPersonID.Text = $"{PersonID}";

                _Person = clsBusiness.FindPerson(PersonID);
                if (_Person == null)
                {
                    MessageBox.Show("Person not found.");
                    return;
                }

                txtEmail.Text = string.IsNullOrEmpty(_Person.Email) ? "" : _Person.Email;
                txtAddress.Text = _Person.Address;
                txtFirstName.Text = _Person.FirstName;
                txtLastName.Text = _Person.LastName;
                txtThirdName.Text = _Person.ThirdName;
                txtSecondName.Text = _Person.SecondName;
                txtPhone.Text = _Person.Phone;
                txtNationalNo.Text = _Person.NationalNo;
                cbCountries.SelectedItem = clsBusiness.FindCountry(_Person.NatialityCountryID);

                rbMale.Checked = _Person.Gendor == 0;
                rbFemale.Checked = _Person.Gendor == 1;

                pbPersonal.ImageLocation = string.IsNullOrEmpty(_Person.ImagePath) ? "" : _Person.ImagePath;
                llRemoveImage.Visible = !string.IsNullOrEmpty(pbPersonal.ImageLocation);
                dtpBirthDate.Value = _Person.BirthDate;
            }
        }
        private void FillCountriesinComboBox()
        {
           DataTable Dt= clsBusiness.GetAllCountries();
            foreach(DataRow Row in Dt.Rows){
                cbCountries.Items.Add(Row["CountryName"]);
            }
            cbCountries.SelectedItem="Yemen";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonal.Image =Resources.admin_female ;
            }
            
        }
        
        private void ctrAddNewPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtSecondName.Text != "" && txtThirdName.Text != "" && txtLastName.Text != ""    &&
                txtNationalNo.Text!=""&&txtPhone.Text!="") {
                _Person.Address =   txtAddress.Text;
                _Person.FirstName = txtFirstName.Text;
                _Person.LastName =   txtLastName.Text;
                _Person.Email =      txtEmail.Text;
                _Person.SecondName = txtSecondName.Text;
                _Person.ThirdName =  txtThirdName.Text;
                _Person.NationalNo =     txtNationalNo.Text;
                _Person.BirthDate =      dtpBirthDate.Value;
                _Person.Phone =         txtPhone.Text;
                if (rbFemale.Checked)
                {
                    _Person.Gendor = 1;
                }
                else
                    _Person.Gendor = 0;

                if (pbPersonal.ImageLocation == "" || pbPersonal.Image == null)
                {
                    _Person.ImagePath = "";
                }
                else
                    _Person.ImagePath = pbPersonal.ImageLocation;


                _Person.NatialityCountryID = clsBusiness.FindCountry(cbCountries.Text);

                if (_Person.Save())
                {
                    MessageBox.Show("Data Is Saved SeccussFully ..");
                    DataBack?.Invoke(this,_Person.PersonID);
                }
                else
                    MessageBox.Show("Data Is Not Saved SeccussFully ..");

                lblPersonID.Text = $"{_Person.PersonID}";
                lblAddNew_Edit.Text = $"Edit Mode For {_Person.PersonID}";
                Mode = enMode.Update;
                

            }
            else
            {
                MessageBox.Show("You Need To Fill All The Fields  ");
                errorProvider1.SetError(txtFirstName, "Enter Your First Name !!");

                errorProvider1.SetError(txtSecondName, "Enter Your Second Name !!");

                errorProvider1.SetError(txtThirdName, "Enter Your Third Name !!");

                errorProvider1.SetError(txtLastName, "Enter Your Last Name !!");

                errorProvider1.SetError(txtNationalNo, "Enter Your National No Number !!");

                errorProvider1.SetError(txtPhone, "Enter Your Phone Number  !!");


                //if (txtEmail.Text!="")
                //{

                //}
            }





        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonal.Image = Resources.flight_attendant_male;
            }
        }

        private void lblAddNew_Edit_Click(object sender, EventArgs e)
        {

        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Form Parent = this.FindForm();
            if (Parent != null)
            {
                Parent.Close();
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog1.FileName;
                pbPersonal.Load(FilePath);
            }
         
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonal.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFirstName.Text=="")
            {
                errorProvider1.SetError(txtFirstName,"You need To Write Your FirstName");
            }
        }

        private void _FilterByNationalNO()
        {
           
        }
        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {
            string NewNational = txtNationalNo.Text.Trim();
            if (_Person!=null&&NewNational==_Person.NationalNo)
            {
                errorProvider1.SetError(txtNationalNo, "");
                return;
            }

            if (clsBusiness.IsColumnExists(NewNational,"NationalNo"))
            {
                errorProvider1.SetError(txtNationalNo,"This National No With Another Person !!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
            }
   
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

    

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string Email =txtEmail.Text;
            if (!Email.EndsWith("@gmail.com"))
            {
                errorProvider1.SetError(txtEmail, "Format is Not Correct ,it Must End With @gmail.com");
            }
            else
                errorProvider1.SetError(txtEmail, "");
        }

  
    }
}
