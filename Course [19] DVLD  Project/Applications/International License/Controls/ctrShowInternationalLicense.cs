using clsLogic;
using Course__19__DVLD___Project.Properties;
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
    public partial class ctrShowInternationalLicense : UserControl
    {
        private int _InternationalLicenseID;
        clsApplications _Application;
        clsInternationalLicense _InternationalLicense;
        clsLicense _IssuedLicense;
        clsPerson _Person;
        clsLocalDrivingLicenseApplication _Local;
        public int InternationalLicenseID {
            get
            {
                return _InternationalLicenseID;
            }


            set
            {
                _InternationalLicenseID = value;
                _LoadData(_InternationalLicenseID);
                
            }
        }
        private void _LoadData(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.FindInterNationalLicenseByID(InternationalLicenseID);
         
            if (_InternationalLicense!=null)
            {
                _Application = clsApplications.FindApplicationByApplicationID(_InternationalLicense.ApplicationID);
                _IssuedLicense = clsLicense.FindLicenseByLicenseID(_InternationalLicense.IssuedUsingLocalLicenseID);
                _Person = clsPerson.FindPerson(_Application.ApplicantPersonID);
                lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lblName.Text = _Person.FullName();
                lblIntLicenseID.Text = InternationalLicenseID.ToString();
                lblNationalNo.Text =_Person.NationalNo.ToString();
                lblIssueDate.Text=_InternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
                lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
                lblDriverID .Text=_InternationalLicense.DriverID.ToString();
                lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
                lblIsActive.Text = _InternationalLicense.IsActive == true ? "Yes" : "No";
                lblLicenseID.Text=_IssuedLicense.LicenseID.ToString();
                lblDateOfBirth.Text = _Person.BirthDate.ToString("dd/MMM/yyy");
                if (_Person.ImagePath!="")
                {
                    pictureBox1.ImageLocation = _Person.ImagePath;
                }
                else
                {
                    pictureBox1.Image = (_Person.Gendor == (byte)1) ? Resources.admin_female : Resources.flight_attendant_male;
                }
           
                
            }

        }
        public ctrShowInternationalLicense()
        {
            InitializeComponent();
        }

        private void ctrShowInternationalLicense_Load(object sender, EventArgs e)
        {


        }
    }
}
