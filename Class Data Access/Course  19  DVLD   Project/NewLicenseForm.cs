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
    public partial class NewLicenseForm : Form
    {
        public int PersonID = 0;
        clsUser _User;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public int ClassTypeID {  get; set; }
        public int LocalDLID {  get; set; }
        public decimal Fees {  get; set; }
        clsApplications _Applications ;
        public NewLicenseForm(clsUser User,int LocalID)
        {
            InitializeComponent();
            if (LocalID!=-1)
            {
                LocalDLID = LocalID;
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppID(LocalID);
                _Applications = clsApplications.FindApplicationByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);
                tabControl1.SelectedIndex = 1;
                ctrShowPersonDetail1.PersonID=_Applications.ApplicantPersonID;
                return;
            }
            ctrFilterPerson_ADD1.DataBack += _TakeBackData;
            _User = User;
        }
        private void _TakeBackData(object s,int ID)
        {
            PersonID = ID;
            ctrShowPersonDetail1.PersonID = PersonID;
        } 

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PersonID!=0)
            {
                tabControl1.SelectedIndex = 1;
            
                lblAppFees.Text = 15.ToString()+"$";
                lblAppDate.Text = DateTime.Now.ToString();
                CreatedByUser.Text = _User.UserName.ToString();
            }
            else
            {
                MessageBox.Show("You Can't Preceed WithOut a person To make The Application ..");
            }
      
        }

        private void NewLicenseForm_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Personal Info";
            tabPage2.Text = "Application Info";
            _LoadData();
        }

        private void _FillComboWithDrivingLicensTypes()
        {
            DataTable dt = clsLisences.GetAllLicenseTypes();
            foreach (DataRow Row in dt.Rows)
            {
                cbLicenseClass.Items.Add(Row["ClassName"]);
            }

        }
        private void _LoadData()
        {


            _FillComboWithDrivingLicensTypes();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbLicenseClass.SelectedIndex<0)
            {
                MessageBox.Show("You Must Chooose One License Class ... ","Alert");
                return;
            }


            if (LocalDLID==-1)
            {
                _Applications = new clsApplications();
                _Applications.ApplicationFees = Fees;
                _Applications.ApplicantPersonID = PersonID;
                _Applications.ApplicationDate = DateTime.Now;
                _Applications.LastStatusDate = DateTime.Now;
                _Applications.ApplicationTypeID = 1;
                _Applications.ApplicationTypeStatus = 1;
                _Applications.CreatedByUserID = _User.UserID;
                _Applications.ClassTypeID = ClassTypeID;
            }
           
            

            if (!clsApplications.IsLicenseApplicationExists(_Applications.ApplicantPersonID,_Applications.ApplicationTypeID,_Applications.ApplicationTypeStatus))
            {
                if (_Applications.Save())
                {
                    MessageBox.Show("Application Is Saved Seccussfully ..");
                    lblDLAppID.Text = _Applications.LocalApplicationLicenseID.ToString();
                    tabControl1.Enabled = false;
                    btnSave.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Application Is not Saved Seccussfully ..");
                }
            }
            else
            {
                MessageBox.Show("You Can't have Two License From The Same Class >><>>><:)");
            }
              


        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
                    switch (cbLicenseClass.SelectedIndex)
            {
                case 0:
                    ClassTypeID = 1;
                    Fees = 15;
               
                    break;
                case 1: 
                    Fees = 30; 
                    ClassTypeID = 2; break;

                case 2: Fees = 20;
                    ClassTypeID = 3;
                    break;
                case 3: Fees = 200;
                    ClassTypeID = 4;
                    break;

                case 4: Fees = 50;
                    ClassTypeID = 5; 
                    break;
                case 5: Fees = 250;
                    ClassTypeID = 6;
                    break;
                case 6: Fees = 300;ClassTypeID= 7; break;
            }
        }
    }
}
