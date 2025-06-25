using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
   public  class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestTypeID {  get; set; }
        public string TestTypeTitle {  get; set; }
        public string TestTypeDescription { get; set; }
        public  decimal TestTypeFees {  get; set; }

        private clsTestTypes(enTestType TestTypeID , string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
                
        }


        public static  clsTestTypes FindTestTypeByID(enTestType TestTypeID)
        {
            string TestTypeTitle = ""; 
                string TestTypeDescription = " "; 
                decimal TestTypeFees = 0;

            if (clsDataAccess_Sql.FindTestTypeByID((int)TestTypeID,ref TestTypeTitle,ref TestTypeDescription,ref TestTypeFees))
            {
                return new clsTestTypes(TestTypeID,TestTypeTitle,TestTypeDescription,TestTypeFees);
            }
            return null;
        } 

    }
}
