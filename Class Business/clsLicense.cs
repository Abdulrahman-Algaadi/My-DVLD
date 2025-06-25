using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace clsLogic
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID {  get; set; }
        public int PersonID {  get; set; }
        public int CreatedByUserID {  get; set; }
        public int LicenseClassID {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes {  get; set; }
        public Decimal PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public enIssueReason IssueReason {  get; set; }
        public clsDriver DriverInfo { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.PersonID = -1;
    
            this.CreatedByUserID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes="";
            this.IsActive = false;
            this.IssueReason = 0;
            this.PaidFees = 0;
        }
        private clsLicense(int LicenseID,int ApplicationID,int DriverID,int CreatedByUserID,
            int LicenseClassID,DateTime IssueDate,DateTime ExpirationDate,string Notes,bool IsActive,enIssueReason IssueReason,decimal PaidFees)
        {
            this.LicenseID= LicenseID;
        this.ApplicationID=ApplicationID;
            this.DriverID=DriverID;
            this.CreatedByUserID=CreatedByUserID;
            this.LicenseClassID=LicenseClassID;
            this.IssueDate=IssueDate;
            this.ExpirationDate=ExpirationDate;
            this.Notes=Notes;
            this.IsActive =IsActive;
            this.IssueReason = IssueReason;
           this.PaidFees=PaidFees;
            DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            LicenseClassInfo =clsLicenseClass.FindLicenceClassByID(this.LicenseClassID);


        }
        public static clsLicense FindLicenseByApplicationID(int ApplicationID)
        {
            int LicenseID=-1,DriverID=-1, CreatedByUserID=-1,
             LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            bool IsActive =false;
            byte IssueReason = 1; decimal PaidFees = 0;
            if (clsDataAccess_Sql.FindLicenseByApplicationID(ApplicationID,ref LicenseID,ref DriverID
                ,ref CreatedByUserID,ref LicenseClassID,ref IssueDate,ref ExpirationDate,ref Notes,ref IsActive,ref IssueReason,ref PaidFees))
            {
                return new clsLicense(LicenseID,ApplicationID,DriverID,CreatedByUserID,LicenseClassID,IssueDate,ExpirationDate,Notes,IsActive,(enIssueReason)IssueReason,PaidFees);
            }
            return null;

        
        }
        public static clsLicense FindLicenseByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, CreatedByUserID = -1,
             LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            bool IsActive = false;
            byte IssueReason = 0; decimal PaidFees = 0;
            if (clsDataAccess_Sql.FindLicenseByLicenseID(ref ApplicationID,  LicenseID, ref DriverID
                , ref CreatedByUserID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref IsActive, ref IssueReason, ref PaidFees))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, CreatedByUserID, LicenseClassID, IssueDate, ExpirationDate, Notes, IsActive, (enIssueReason)IssueReason, PaidFees);
            }
            return null;


        }
        public static clsLicense FindLicenseByLicenseID(int LicenseID,int LicenseClass)
        {
            int ApplicationID = -1, DriverID = -1, CreatedByUserID = -1,
             LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            bool IsActive = false;
            byte IssueReason = 0; decimal PaidFees = 0;
            if (clsDataAccess_Sql.FindLicenseByLicenseID(LicenseClass,ref ApplicationID, LicenseID, ref DriverID
                , ref CreatedByUserID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref IsActive, ref IssueReason, ref PaidFees))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, CreatedByUserID, LicenseClassID, IssueDate, ExpirationDate, Notes, IsActive, (enIssueReason)IssueReason, PaidFees);
            }
            return null;


        }
        public static bool IsLicenseExists(int LicenseID)
        {
            return clsDataAccess_Sql.IsLicenseExists(LicenseID);

        }
        bool AddNewDriver()
        {

            this.DriverID = clsDataAccess_Sql.AddNewDriver(this.PersonID,this.CreatedByUserID);
            return this.DriverID != -1;
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsDataAccess_Sql.GetDriverLicenses(DriverID);
        }
        public  bool IssueLicense()
        {
            this.LicenseID = clsDataAccess_Sql.AddNewLicense( 
                this.CreatedByUserID,this.DriverID,this.ApplicationID,this.LicenseClassID,
                this.IssueDate,this.ExpirationDate,this.Notes,(byte)this.IssueReason,this.PaidFees,this.IsActive);
            return this.LicenseID != -1;
        }
        public bool DeActivate()
        {
            return clsDataAccess_Sql.DeActivateOldLicense(this.LicenseID);
        }
        public bool Activate()
        {
            return clsDataAccess_Sql.ActivateOldLicense(this.LicenseID);
        }
        public static DataTable GetAllLocalLicense(int PersonID)
        {
            return clsDataAccess_Sql.GetAllLocalLicenseByPersonID(PersonID);
        }
      public   bool Save()
        {
            bool IsSaved = false;
          
            if (AddNewDriver())
            {
                if (IssueLicense())
                {
                    IsSaved= true;
                }
                
            }
            return IsSaved; 

        }

    }
}
