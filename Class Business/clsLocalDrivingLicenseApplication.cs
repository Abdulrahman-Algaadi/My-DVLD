using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
    public  class clsLocalDrivingLicenseApplication : clsApplications
    {

        public enum enMode { AddNew,Update}
        public enMode Mode =enMode.AddNew;
        public int LocalDrivingLicenseAppID {  get; set; }
        public int ClassTypeID {  get; set; }
       
        public clsApplications ApplicationInfo { get; set; }
        public clsLicenseClass  LicenseClassInfo { get; set; }


        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseAppID = 0;
            this.ClassTypeID = 0;
          Mode =enMode.AddNew;
            
        }
       private  clsLocalDrivingLicenseApplication(int LocalDrivingLicenseAppID,int ClassTypeID,int ApplicationID,
           int PersonID, DateTime AppDate, int AppTypeID, clsApplications.enApplicationStatus AppStatusID, DateTime LastStatusDate, decimal Fees, int CreatedByUserID)
        {
            this.LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            this.ClassTypeID = ClassTypeID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = PersonID;
            this.ApplicationDate = AppDate;
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationStatus = AppStatusID;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationFees = Fees;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationInfo =clsApplications.FindApplicationByApplicationID(ApplicationID);
            this.LicenseClassInfo =clsLicenseClass.FindLicenceClassByID(ClassTypeID);
            Mode=enMode.Update;
            
        }
        public static DataTable GetAllLocalApplications()
        {
            return clsDataAccess_Sql.GetAllLocalApplications();
        }

        public static  clsLocalDrivingLicenseApplication FindLocalDrivingLicenseAppID(int LocalDrivingLicenseAppID)
        {
            int ClassTypeID = -1,ApplicationID=-1;
            bool Found = clsDataAccess_Sql.FindLocalDrivingLicenseAppID(LocalDrivingLicenseAppID,ref ClassTypeID,ref ApplicationID);

            clsApplications applications;
            if (Found)
            {
                applications=clsApplications.FindApplicationByApplicationID(ApplicationID);
            
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID,ClassTypeID,applications.ApplicationID,applications.ApplicantPersonID,applications.ApplicationDate,
                            applications.ApplicationTypeID,(enApplicationStatus)applications.ApplicationStatus,applications.LastStatusDate,applications.ApplicationFees,applications.CreatedByUserID);
            }
            return null;


        }
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseByApplicationID(int ApplicationID)
        {
            int ClassTypeID = -1, LocalDrivingLicenseAppID = -1;

            bool Found = clsDataAccess_Sql.FindLocalDrivingLicenseByApplicationID(ref LocalDrivingLicenseAppID, ref ClassTypeID, ApplicationID);

            clsApplications applications;
            if (Found)
            {
                applications = clsApplications.FindApplicationByApplicationID(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID, ClassTypeID, ApplicationID, applications.ApplicantPersonID, applications.ApplicationDate,
                            applications.ApplicationTypeID, (enApplicationStatus)applications.ApplicationStatus, applications.LastStatusDate, applications.ApplicationFees, applications.CreatedByUserID);
            }
            return null;


        }
        public bool UpdateLocalDrivingApplicationLicense()
        {
            return clsDataAccess_Sql.UpdateLocalDrivingLicenseApplication(this.LocalApplicationLicenseID,this.ClassTypeID);
        }
        private  bool AddNewLocalDrivingLicense()
        {
            this.LocalApplicationLicenseID = clsDataAccess_Sql.AddNewLocalLiceneApplication(this.ApplicationID,this.ClassTypeID);
            return (this.LocalApplicationLicenseID != -1);

        }
        public bool Save()
        {
            base.Mode =(clsApplications.enMode)Mode;
            bool IsSaved = false;
            if (!base.Save())
            {
                return false;
            }
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewLocalDrivingLicense())
                    {
                        Mode = enMode.Update; 
                       IsSaved = true;

                    }
                    break;
                case enMode.Update:
                    return UpdateLocalDrivingApplicationLicense();

            }
            return IsSaved; 

        }

        public static bool DeleteApplication(int LocalID)
        {
           return  clsDataAccess_Sql.DeleteApplication(LocalID);
            
        }
        public bool SetComplete()
        {
            return clsDataAccess_Sql.UpdateStatus(ApplicationID,3);
        }
        public bool SetCancel()
        {
            return clsDataAccess_Sql.UpdateStatus(ApplicationID, 2);
        }
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsDataAccess_Sql.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.ClassTypeID);
        }
        public bool DosePassedTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsDataAccess_Sql.DoesPassTestType(this.LocalDrivingLicenseAppID,(int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsDataAccess_Sql.DoesAttendTestType(this.LocalDrivingLicenseAppID,(int)TestTypeID);
        }
        public byte TotalTrialsPerTest( int TestTypeID)
        {
            return clsDataAccess_Sql.TotalTrialsPerTest(this.LocalDrivingLicenseAppID,TestTypeID);
        }
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassInfo.LicenceClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.ValidtyLengthPfLicense);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.LicenseFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }


    }
}
