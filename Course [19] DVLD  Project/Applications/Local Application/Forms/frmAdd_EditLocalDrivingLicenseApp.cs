using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ClsAdd_UpdateLocalApplication : Form
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public int PersonID = 0;
  
        clsUser _User = clsGlobal.User;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsPerson _Person;
        clsApplicationTypes _ApplicationTypes;
     
        public int LocalDrivingLicenseID{ get; set; }
       
        public ClsAdd_UpdateLocalApplication()
        {
            InitializeComponent();

            ctrFilterPerson_ADD1.DataBack += _TakeBackData;
            ctrFilterPerson_ADD1.DataBack1 += _TakeBackData1;
            ctrFilterPerson_ADD1.FilterEnabled = true;
            Mode=enMode.AddNew;

        }
        public ClsAdd_UpdateLocalApplication(int LocalID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            LocalDrivingLicenseID = LocalID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalDrivingLicenseID);
            ctrShowPersonDetail1.PersonID =_LocalDrivingLicenseApplication.ApplicantPersonID;
            ctrFilterPerson_ADD1.FilterTextBoxValue = _LocalDrivingLicenseApplication.ApplicantPersonID.ToString();
            ctrFilterPerson_ADD1.FilterEnabled = false;
            ctrFilterPerson_ADD1.ShowAddPerson = false;
            
        }
        


        private void _ResetDefaultValues()
        {
            _FillComboWithDrivingLicensTypes();
            if (Mode==enMode.AddNew)
            {
                this.Text = "Add New Local Driving License";
                lblTitle.Text = "Add New Local Driving License";
                //lblAppFees.Text =clsApplicationTypes.FindApplicationTypeByID(cls)
                _ApplicationTypes = clsApplicationTypes.FindApplicationTypeByID((int)clsApplications.enApplicationType.NewDrivingLicense);
                lblAppFees.Text = _ApplicationTypes.ApplicationFees.ToString() ;
                lblAppDate.Text = DateTime.Now.ToString();
                CreatedByUser.Text = _User.UserName.ToString();
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                tbAppInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrFilterPerson_ADD1.FocusFilter();

           
            }
            else
            {
                this.Text = "Update  Local Driving License";
                lblTitle.Text = "Update Local Driving License";
                lblAppDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString();   
                lblDLAppID.Text =_LocalDrivingLicenseApplication.LocalDrivingLicenseAppID.ToString();
                lblAppFees.Text = _LocalDrivingLicenseApplication.ApplicationInfo.ApplicationFees.ToString();
                cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.LicenceClassName);
                CreatedByUser.Text = clsUser.FindUserByID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName.ToString();
            }

        }
        private void _TakeBackData(object s,int ID)
        {
            PersonID = ID;
            _Person = clsPerson.FindPerson(ID);
            ctrShowPersonDetail1.PersonID = PersonID;
          
        }
        private void _TakeBackData1(object s, string  NationalNo)
        {
            _Person=clsPerson.FindPerson(NationalNo);
            ctrShowPersonDetail1.PersonID = _Person.PersonID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode==enMode.AddNew)
            {
                if (PersonID != 0)
                {
                    tabControl1.SelectedIndex = 1;
                    tbAppInfo.Enabled = true;
                    btnSave.Enabled = true;

                }
                else
                {
                    MessageBox.Show("You Can't Preceed WithOut a person To make The Application ..");
                }
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                tbAppInfo.Enabled = true;
                btnSave.Enabled = true;
            }
           
      
        }

        private void ClsAdd_UpdateLocalApplication_Load(object sender, EventArgs e)
        {
         
       _ResetDefaultValues();
     
        }

        private void _FillComboWithDrivingLicensTypes()
        {
            DataTable dt =clsLicenseClass.GetAllLicenseTypes();
            foreach (DataRow Row in dt.Rows)
            {
                cbLicenseClass.Items.Add(Row["ClassName"]);
            }

        }
  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Go And Put The Mouse Over To The Red Icon And Fix The Problem !!");
                return;
            }
            if (cbLicenseClass.SelectedIndex<0)
            {
                MessageBox.Show("You Must Chooose One License Class ... ","Alert");
                return;
            }
            int LicenseClassID = clsLicenseClass.FindLicenseClassByName(cbLicenseClass.Text).LicenceClassID;

          

            if (clsApplications.IsLicenseApplicationExists(ctrShowPersonDetail1.PersonID, LicenseClassID))
            {
                MessageBox.Show("You Can't have Two License From The Same Class >><>>><:)");
                return;
            }
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrShowPersonDetail1.PersonID;  
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationFees = Convert.ToDecimal(lblAppFees.Text);
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationTypeID =(int)clsApplications.enApplicationType.NewInternationalLicense;
            _LocalDrivingLicenseApplication.ClassTypeID = LicenseClassID;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.User.UserID;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;      

            if (_LocalDrivingLicenseApplication.Save()) { 
                    MessageBox.Show("Data Is Saved Seccussfully ..");
                    lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalApplicationLicenseID.ToString();
                Mode =enMode.Update;
                    tabControl1.Enabled = false;
                    btnSave.Enabled = false;

            }
            else
            {
                    MessageBox.Show("Data Is not Saved Seccussfully ..");
            }


        }
        private bool CheckAge()
        {

            clsLicenseClass _Licenses = clsLicenseClass.FindLicenseClassByName(cbLicenseClass.Text);
            DateTime dateTime = DateTime.Now;
            int Mini =  _Licenses.MinimumAllowedAge*-1;
            DateTime dateTime1 = dateTime.AddYears(Mini);
            if (_Person.BirthDate < dateTime1)
            {
                btnSave.Enabled = true;
                return true;
            }
            else
            {
                MessageBox.Show($"You Are Not Old Enough To Register in The {_Licenses.LicenceClassName} License,The Minimum Allowed Age is {_Licenses.MinimumAllowedAge} ,Try Again Next Year");
                btnSave.Enabled = false;
                return false;
            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mode==enMode.AddNew)
            {
                CheckAge();
            }
      
        }

        private void ClsAdd_UpdateLocalApplication_Activated(object sender, EventArgs e)
        {
            ctrFilterPerson_ADD1.FocusFilter();
        }
    }
}
