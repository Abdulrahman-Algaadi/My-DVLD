using clsDataAccess;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
   public class clsApplicationTest
    {
        public int ID { get; set; }
        public string TitleTestType { get; set; }
        public string DescriptionTestType { get; set; }
        public decimal TestTypesFees { get; set; }



        private clsApplicationTest(int ID ,string Title,string DescriptionTestType,decimal Fees)
        {
            this.ID=ID;
            this.TitleTestType=Title;       
            this.DescriptionTestType=DescriptionTestType;   
            this.TestTypesFees=Fees;
        }

        public static DataTable GetAllTests()
        {
            return clsDataAccess_Sql.GetAllTestsType();
        }
        public static clsApplicationTest FindByID(int ID)
        {
            string Title = "", description = "";
            decimal Fees = 0;
            if (clsDataAccess_Sql.FindApplicationTestByID(ID,ref Title,ref description,ref Fees))
            {
                return new clsApplicationTest(ID,Title,description,Fees);
            }
            return null;

        }

        bool  UpdateApplicationTest()
        {
            return clsDataAccess_Sql.UpdateApplicationTest(this.ID,this.DescriptionTestType,this.TitleTestType,this.TestTypesFees);
        }

        public bool Save()
        {
            return UpdateApplicationTest();
        }

    }
}
