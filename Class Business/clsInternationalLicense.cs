using clsDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace clsLogic
{
    public  class clsInternationalLicense
    {
        public int InernationalLicenseID {  get; set; }
        public int ApplicationID {  get; set; } 
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate { get; set; } 
        public DateTime ExpirationDate {  get; set; }
        public bool IsActive { get; set; }  
        public int CreatedByUserID {  get; set; }


        public clsInternationalLicense()
        {
            this.InernationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate= DateTime.Now;   
        }
        private clsInternationalLicense(int InternationalLicenseID,int AppID,int DriverID ,int IssuedUsingLocalID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive,int CreatedByUserID)
        {
            this.InernationalLicenseID= InternationalLicenseID;
            this.ApplicationID= AppID;
            this.DriverID= DriverID;
            this.IsActive=IsActive;
            this.IssueDate = IssueDate;
            this.IssuedUsingLocalLicenseID= IssuedUsingLocalID;
            this.ExpirationDate = ExpirationDate;
            this.CreatedByUserID= CreatedByUserID;
        }
        public static DataTable FilterDataBy(string ColName, string DataToSearchFor)
        {
            return clsDataAccess_Sql.FilterDataBy(ColName, DataToSearchFor);
        }

        public static DataTable GetAllInternationalLicenses(int PersonID)
        {
            return clsDataAccess_Sql.GetAllInternationalLicenseByPersonID(PersonID);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return clsDataAccess_Sql.GetAllInternationalLicenseByPersonID();
        }

        public static bool IsLicenseExists(int LicenseID)
        {
            return clsDataAccess_Sql.IsInternationalLicenseExists(LicenseID);
        }
     public  bool AddNewInternationalLicense()
        {

            this.InernationalLicenseID = clsDataAccess_Sql.AddNewInternationalLicense(this.ApplicationID,
                this.DriverID,this.ExpirationDate,this.IssueDate,this.IsActive,this.CreatedByUserID,this.IssuedUsingLocalLicenseID);
            return this.InernationalLicenseID != -1;
        }

    public static clsInternationalLicense FindInterNationalLicenseByID(int InternationalLicenseID)
        {
            int AppID = -1, DriverID = -1, IssuedUsingLocalID = -1; DateTime IssueDate = DateTime.Now;DateTime ExpirationDate = DateTime.Now; bool IsActive = false;int CreatedByUserID = -1;


            if (clsDataAccess_Sql.FindInterNationalLicenseByID(InternationalLicenseID,ref AppID,ref DriverID,ref IssuedUsingLocalID,ref IssueDate,ref ExpirationDate,ref IsActive,ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID,AppID,DriverID,IssuedUsingLocalID,IssueDate,ExpirationDate,IsActive,CreatedByUserID);
            }
            return null;
        }
        public bool Save()
        {
            bool IsSaved = false;
            if (AddNewInternationalLicense())
            {
                IsSaved = true;
            }
            return IsSaved;
        }

    }
}
