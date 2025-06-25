using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
    public  class clsLicenseClass
    {
        public int LicenceClassID { get; set; }
        public string LicenceClassName { get; set; }
        public decimal LicenseFees{ get; set; }
        public byte ValidtyLengthPfLicense {  get; set; }
        public byte MinimumAllowedAge {  get; set; }

        public static DataTable GetAllLicenseTypes()
        {
            return clsDataAccess_Sql.GetAllLicensesTypes();
        }

        private clsLicenseClass(int ID, string Title, decimal Fees, byte validtyLengthPfLicense, byte minimumAllowedAge)
        {
            this.LicenceClassID = ID;
            this.LicenceClassName = Title;
            this.LicenseFees = Fees;
            this.ValidtyLengthPfLicense = validtyLengthPfLicense;
            this.MinimumAllowedAge = minimumAllowedAge;
        }
        public static clsLicenseClass FindLicenceClassByID(int ApplicationID)
        {
            string AppName = "";
            decimal Fees = 0;
            byte ValidtyLengthPfLicense = 0;
            byte MinimumAllowedAge = 0;
            if (clsDataAccess_Sql.FindLicenseClassByID(ApplicationID, ref AppName, ref Fees,ref ValidtyLengthPfLicense,ref MinimumAllowedAge))
            { 
                return new clsLicenseClass(ApplicationID, AppName, Fees,ValidtyLengthPfLicense,MinimumAllowedAge);
            }

            return null;
        }
        public static clsLicenseClass FindLicenseClassByName(string ClassName)
        {
            decimal Fees = 0;
            byte ValidtyLengthPfLicense = 0;
            byte MinimumAllowedAge = 0;
            int ApplicationID = -1;
            if (clsDataAccess_Sql.FindLicenseClassByName(ref ApplicationID,  ClassName, ref Fees, ref ValidtyLengthPfLicense, ref MinimumAllowedAge))
            {
                return new clsLicenseClass(ApplicationID, ClassName, Fees, ValidtyLengthPfLicense, MinimumAllowedAge);
            }

            return null;
        }


    }
}
