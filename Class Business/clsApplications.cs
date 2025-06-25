using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace clsLogic
{
    public class clsApplications
    {
       public  enum enMode { AddNew , Update}
       public  enMode Mode = enMode.AddNew;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public int ApplicationID {  get; set; }


        public  decimal ApplicationFees {  get; set; }
        public int LocalApplicationLicenseID {  get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ClassTypeID {  get; set; }
        public int ApplicationTypeID { get; set; }
      
        public DateTime LastStatusDate { get; set; }
        public int CreatedByUserID {  get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public clsUser UserInfo {  get; set; }
        public clsApplicationTypes ApplicationTypesInfo { get; set; }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicationTypeID = -1;
             this.ApplicationStatus =enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.CreatedByUserID = -1;
            this.ApplicationFees = 0;
            this.ApplicationDate = DateTime.Now;
           this.ApplicantPersonID = -1;
            this.LocalApplicationLicenseID = -1;
            this.ClassTypeID = -1;
            Mode = enMode.AddNew;



        }
        private clsApplications(int AppID,int PersonID, DateTime AppDate, int AppTypeID, byte AppStatusID, DateTime LastStatusDate, decimal Fees,int CreatedByUserID)
        {
            this.ApplicationID = AppID;
            this.ApplicantPersonID =PersonID;
            this.ApplicationDate=AppDate;
            this.ApplicationTypeID =AppTypeID;
            this.ApplicationTypesInfo =clsApplicationTypes.FindApplicationTypeByID(AppTypeID);
            this.ApplicationStatus=(enApplicationStatus)AppStatusID;
            this.LastStatusDate =LastStatusDate;
            this.ApplicationFees=Fees;
            this.CreatedByUserID =CreatedByUserID;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.UserInfo =clsUser.FindUserByID(CreatedByUserID);
            Mode = enMode.Update;   
        }
      
       public static bool IsLicenseApplicationExists(int PersonID, int ClassTypeID  )
        {
            return clsDataAccess_Sql.IsLicenseWithClassExists(PersonID,ClassTypeID);
        
        }
        public static clsApplications FindApplicationByApplicationID(int AppID)
        {
            DateTime AppDate = DateTime.Now;
            int AppTypeID = -1, CreatedByUserID = -1,PersonID=-1;
            byte AppStatusID = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal Fees = 0;
            if (clsDataAccess_Sql.FindApplicationByApplicationID(AppID,
                ref PersonID, ref AppDate, ref AppTypeID, ref AppStatusID, ref LastStatusDate, ref Fees, ref CreatedByUserID))
            {
                return new clsApplications(AppID,PersonID, AppDate, AppTypeID, AppStatusID, LastStatusDate, Fees, CreatedByUserID);
            }
            return null;
        }


       public  bool AddNewApplication()
        {
            this.ApplicationID = clsDataAccess_Sql.AddNewApplication(this.ApplicationTypeID,(int)this.ApplicationStatus,this.LastStatusDate
                ,this.ApplicationDate,this.CreatedByUserID,this.ApplicationFees,this.ApplicantPersonID);

            return ApplicationID != -1;
        }
        private bool UpdateApplication()
        {

            return clsDataAccess_Sql.UpdateApplication(this.ApplicationID,
                this.ApplicationTypeID, this.ApplicationDate, this.ApplicationFees, this.ApplicantPersonID,this.LastStatusDate,
                this.CreatedByUserID,(int)this.ApplicationStatus);

        }
        public bool AddNewLocalLiceneApplication()
        {
              this.LocalApplicationLicenseID =  clsDataAccess_Sql.AddNewLocalLiceneApplication(this.ApplicationID,this.ClassTypeID);

            return this.LocalApplicationLicenseID != -1;
        }
  
        public bool Save()
        {
            bool IsSaved = false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewApplication())
                    {
                        IsSaved = true;
                        Mode=enMode.Update;
                    }
                    break;
                case enMode.Update:
                    return UpdateApplication();

            }

            return IsSaved;
        }
        
    
    }
}
