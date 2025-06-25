using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using clsDataAccess;

namespace clsLogic
{
    public  class clsApplicationTypes
    {
    
        public int ApplicationTypeID {  get; set; }
        public string ApplicationTitle { get; set; }
        public decimal ApplicationFees { get; set; }


        public static DataTable GetAllApplicationTypes()
        {
            return clsDataAccess_Sql.GetAllApplicationTypes();

        }
        private clsApplicationTypes(int AppTypeID,string AppTypeTitle,decimal Fees)
        {
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationTitle = AppTypeTitle;
            this.ApplicationFees = Fees;
        }
        public static clsApplicationTypes FindApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTitle = "";
            decimal AppFees = 0;
            if (clsDataAccess_Sql.FindApplicationTypeByID(ApplicationTypeID,ref ApplicationTitle,ref AppFees))
            {
                return new clsApplicationTypes(ApplicationTypeID,ApplicationTitle,AppFees);
            }
            return null;
        }
        public bool clsUpdateNameOrFeesOfApplication()
        {
            return clsDataAccess_Sql.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTitle, this.ApplicationFees);
        }
    }
}
