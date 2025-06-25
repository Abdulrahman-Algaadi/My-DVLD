using clsLogic;
using Course__19__DVLD___Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    
        clsPerson _Person;
        public ctrAddNewPerson()
        {
            

            InitializeComponent();

           
        }
        private void _ResetDefaultValues()
        {
            dtpBirthDate.Value = dtpBirthDate.Value.AddYears(-18);
            dtpBirthDate.MinDate = dtpBirthDate.Value.AddYears(-100);
            dtpBirthDate.MaxDate = dtpBirthDate.MaxDate;
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            cbCountries.SelectedItem = "Yemen";
            rbMale.Checked = true;


        }
        private void _LoadData()
        {
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            FillCountriesinComboBox();
          

            if (Mode == enMode.AddNew)
            {
                lblAddNew_Edit.Text = "Add New Person";
                _Person = new clsPerson();
                llRemoveImage.Visible = false;
                return;
            }
            else
            {
                lblAddNew_Edit.Text = $"Edit Mode For {PersonID}";
                lblPersonID.Text = $"{PersonID}";

                _Person = clsPerson.FindPerson(PersonID);
                if (_Person == null)
                {
                    MessageBox.Show("Person not found.");
                    return;
                }

                txtEmail.Text = string.IsNullOrEmpty(_Person.Email) ? "" : _Person.Email;
                txtAddress.Text = _Person.Address;
                txtFirstName.Text = _Person.FirstName;
                txtLastName.Text = _Person.LastName;
                txtThirdName.Text = string.IsNullOrEmpty(_Person.ThirdName) ? "" : _Person.ThirdName;
                txtSecondName.Text = _Person.SecondName;
                txtPhone.Text = _Person.Phone;
                txtNationalNo.Text = _Person.NationalNo;
                cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

                rbMale.Checked = _Person.Gendor == 0;
                rbFemale.Checked = _Person.Gendor == 1;

                pbPersonal.ImageLocation = string.IsNullOrEmpty(_Person.ImagePath) ? "" : _Person.ImagePath;
                llRemoveImage.Visible = !string.IsNullOrEmpty(pbPersonal.ImageLocation);
                llSetImage.Visible = string.IsNullOrEmpty(pbPersonal.ImageLocation)?true:false;
                dtpBirthDate.Value = _Person.BirthDate;
            }
        }
        private void FillCountriesinComboBox()
        {
           DataTable Dt= clsCountry.GetAllCountries();
            foreach(DataRow Row in Dt.Rows){
                cbCountries.Items.Add(Row["CountryName"]);
            }
            cbCountries.SelectedItem="Yemen";
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
            _ResetDefaultValues();
           _LoadData ();
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Reqauired ,Go And Follow  The Red Icon To Fix Them !!", "Validations", MessageBoxButtons.OK);
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }
            int NationalityID = clsCountry.FindCountry(cbCountries.Text).CountryID;
                _Person.Address = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? "" : txtAddress.Text.Trim();
                _Person.FirstName = txtFirstName.Text;
                _Person.LastName =   txtLastName.Text;
                _Person.Email = string.IsNullOrEmpty(txtEmail.Text.Trim()) ? "" : txtEmail.Text.Trim();
                _Person.SecondName = txtSecondName.Text;
                _Person.ThirdName = string.IsNullOrEmpty(txtThirdName.Text.Trim())?"":txtThirdName.Text.Trim();
                _Person.NationalNo =     txtNationalNo.Text;
                _Person.BirthDate =      dtpBirthDate.Value;
                _Person.Phone =         txtPhone.Text;
                if (rbFemale.Checked)
                {
                    _Person.Gendor = 1;
                }
                else
                    _Person.Gendor = 0;

                if (pbPersonal.ImageLocation!= null)
                {
                    _Person.ImagePath = pbPersonal.ImageLocation;
                  
                }
                else
                    _Person.ImagePath = "";

                _Person.NatialityCountryID =NationalityID;

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

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonal.Image = Resources.flight_attendant_male;
            }
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
                pbPersonal.ImageLocation =(FilePath);
                if (!
                    string.IsNullOrEmpty(FilePath))
                {
                 
                    llSetImage.Visible = false;
                    llRemoveImage.Visible = true;
                }
            }
         
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonal.ImageLocation = null;
            llRemoveImage.Visible = false;
            llSetImage.Visible = true;

        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            string NewNational = txtNationalNo.Text.Trim();
            if (string.IsNullOrEmpty(NewNational))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo,"This Field Is Reqaired!!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            
    

            if (NewNational!=_Person.NationalNo && clsPerson.IsColumnExists(NewNational, "NationalNo"))
            {
                errorProvider1.SetError(txtNationalNo, "This National No is there With Another Person !!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = txtEmail.Text.Trim();
            //if (!Email.EndsWith("@gmail.com"))
            //{
            //    errorProvider1.SetError(txtEmail, "Format is Not Correct ,it Must End With @gmail.com");
            //}
            //else
            //    errorProvider1.SetError(txtEmail, "");
            if (string.IsNullOrEmpty(Email))
                return;
            if (!clsValidation.ValidateEmail(Email))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Your Email is not Formmated Correctly !");

            }
            else
                errorProvider1.SetError(txtEmail,null);


        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonal.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonal.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonal.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonal.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }


    }
}
