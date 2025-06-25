using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
  public class clsTests
    {

        public int TestID {  get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID {  get; set; }


        public clsTests()
        {
            this.TestID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.TestAppointmentID = -1;
            this.CreatedByUserID = -1;
        }
        private clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }
        public static clsTests FindTestByAppID(int TestAppID)
        {
            bool TestResult=false;
            int CreatedByUserID=-1,TestID = -1;
            string Notes = "";
            if (clsDataAccess_Sql.FindTestByAppID(TestID,TestAppID,ref TestResult,ref Notes,ref CreatedByUserID))
            {
                return new clsTests(TestID,TestAppID,TestResult,Notes,CreatedByUserID);
            }
            return null;
        }

        bool AddNewTest()
        {
            this.TestID = clsDataAccess_Sql.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
            return this.TestID != -1;
        }
        public bool Save()
        {
            bool IsSaved =false;
            if (AddNewTest())
            {
                IsSaved = true;
            }
            return IsSaved;
        }

    }
}
