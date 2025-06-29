using clsDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
    public  class clsDetainedLicense
    {

        public int LicenseID {  get; set; }
        public int DetainedID {  get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees {  get; set; }
        public int CreatedByUserID { get; set; }
        public int ReleasedByApplicationID {  get; set; }
        public bool IsReleased { get; set;}
        public  DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        
        public clsDetainedLicense()
        {
            this.LicenseID = 0;
            this.DetainedID = 0;
            this.ReleaseDate =DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = 0;
            this.ReleasedByApplicationID = 0;
           this.IsReleased = false;
            this.DetainDate = DateTime.Now;
            this.ReleasedByUserID = 0;

        }

        private clsDetainedLicense(int licenseID,int DetainedID,decimal FineFees,int CreatedByUserID,DateTime DetainDate)
        {
            this.LicenseID = licenseID;
            this.CreatedByUserID= CreatedByUserID;
            this.DetainedID= DetainedID;
            this.DetainDate= DetainDate;
            this.FineFees= FineFees;
        }
        private clsDetainedLicense(int licenseID, int DetainedID, decimal FineFees, int CreatedByUserID, DateTime DetainDate
            ,int ReleasedByApplicationID, DateTime ReleaseDate,bool IsReleased,int ReleasedByUserID)
        {
            this.LicenseID = licenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.DetainedID = DetainedID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleasedByApplicationID = ReleasedByApplicationID;
            this.ReleaseDate = ReleaseDate;
            this.IsReleased = IsReleased;
        }

        public static bool IsActiveLicense(int LicenseID)
        {
            return clsDataAccess_Sql.IsActiveLicense(LicenseID);
        }

        public bool DetainLicense()
        {
            this.DetainedID = clsDataAccess_Sql.DetainLicense(this.LicenseID,this.FineFees,this.CreatedByUserID,this.DetainDate);

            return this.DetainedID!=0;
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDataAccess_Sql.IsLicenseDetained(LicenseID);
        }
        public static clsDetainedLicense FindDetainedLicenseByLicenseID(int LicenseID)
        {
            int DetainedID=-1; decimal FineFees=0; int CreatedByUserID=-1; DateTime DetainDate= DateTime.Now;
            if (clsDataAccess_Sql.FindDetainedLicenseByLicenseID(LicenseID,ref DetainedID,ref FineFees,ref CreatedByUserID,ref DetainDate))
            {
                return new clsDetainedLicense(LicenseID,DetainedID,FineFees,CreatedByUserID,DetainDate);
            }
            return null;
        }
     
        public static DataTable GetAllDetainedLicense()
        {
            return clsDataAccess_Sql.GetAllDetainedLicense();
        }
        public static DataTable FilterDetainedBy(string ColumnName,string  FilterBy)
        {
            return clsDataAccess_Sql.FilterDetainedBy(ColumnName, FilterBy);
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDataAccess_Sql.ReleaseDetainLicense(this.DetainedID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

    }
}
