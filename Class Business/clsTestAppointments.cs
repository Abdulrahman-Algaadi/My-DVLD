using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;
namespace clsLogic
{
    public class clsTestAppointments
    {
        enum enMode { Update,AddNew}
        enMode Mode = enMode.AddNew;
        public int TestAppointmentID {  get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsLocked {  get; set; }
        public int Count {  get; set; }
        public int ReTakeTestID {  get; set; }


        public clsTestAppointments()
        {
            this.TestTypeID = -1;
            this.IsLocked = false;
            this.LocalDrivingLicenseID = 0;
            this.PaidFees = 0;
            this.CreatedByUserID = 0;
            this.AppointmentDate = DateTime.Now;
            this.TestAppointmentID = -1;
            this.ReTakeTestID = -1;

            Mode = enMode.AddNew;


        }

        public static int CountTrial(int LocalID,clsTestTypes.enTestType TestTypeID)
        {
            int C = clsDataAccess_Sql.CountTrial(LocalID,(int) TestTypeID);
            return (C == 0 || C == null) ? 0 : C; 
        }
        private clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseID
            , DateTime AppointmentDate, decimal PaidFees, bool IsLocked,int CreatedByUserID,int ReTakeTestID)
        {

            this.TestTypeID = TestTypeID;
            this.IsLocked = IsLocked;
            this.PaidFees= PaidFees;
            this.AppointmentDate = AppointmentDate;
           this.LocalDrivingLicenseID= LocalDrivingLicenseID;
            this.TestAppointmentID= TestAppointmentID;
            this.CreatedByUserID= CreatedByUserID;
            this.ReTakeTestID= ReTakeTestID;
            Mode = enMode.Update;
        }
        public static int PassedTestCount(int LocalID,int PassedCount)
        {
            return clsDataAccess_Sql.PassedTest(LocalID,PassedCount);
        }
     
         public static int TestsThatAlreadyPassed(int LocalID)
        {
            return clsDataAccess_Sql.TestsThatAlreadyPassed(LocalID);
        }
        public static int IsLockedReturnNumber(int LocalID)
        {
            return clsDataAccess_Sql.IsLockedReturnNumber(LocalID);
        }
        public static clsTestAppointments FindAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseID = -1, CreatedByUserID = -1 ;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            bool IsLocked = false;
            int ReTakeTestID = -1;

            if (clsDataAccess_Sql.FindAppointmentByID( TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseID
            ,ref AppointmentDate, ref PaidFees, ref IsLocked, ref CreatedByUserID,ref ReTakeTestID))
            {
                return new clsTestAppointments(TestAppointmentID,  TestTypeID, LocalDrivingLicenseID
            , AppointmentDate, PaidFees,  IsLocked,  CreatedByUserID,ReTakeTestID);
            }
            return null;

        }
        public static clsTestAppointments FindAppointmentByLocalLicenseID(int LocalDrivingLicenseID,bool IsLocked)
        {
            int TestTypeID = -1, TestAppointmentID= -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int RetakeTestApplicationID = -1;
            

            if (clsDataAccess_Sql.FindAppointmentByLocalLicenseID(ref TestAppointmentID, ref TestTypeID, LocalDrivingLicenseID
            , ref AppointmentDate, ref PaidFees, ref IsLocked, ref CreatedByUserID,ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseID
            , AppointmentDate, PaidFees, IsLocked, CreatedByUserID,RetakeTestApplicationID);
            }
            return null;

        }
        public  bool _UpdateAppointment()
        {
            return clsDataAccess_Sql._UpdateAppointment(this.TestAppointmentID,this.AppointmentDate,
                    this.CreatedByUserID,this.PaidFees,this.TestTypeID,this.LocalDrivingLicenseID,this.IsLocked);
          
        }
        bool _AddNewAppointment()
        {
            this.TestAppointmentID = clsDataAccess_Sql.AddNewAppointment(this.TestTypeID,this.LocalDrivingLicenseID,this.AppointmentDate,this.PaidFees
                ,this.IsLocked,this.CreatedByUserID);
            return this.TestAppointmentID != -1;
        }
        public bool Save()
        {
            bool IsSaved = false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointment())
                    {
                        IsSaved = true;
                        Mode=enMode.Update; 
                    }
                    break;
                case enMode.Update:
                    return _UpdateAppointment();

            }
            return IsSaved; 
        }

        public static DataTable GetAppointmentForALocalID(int LocalID,int TestTypeID)
        {
            return clsDataAccess_Sql.GetAppointmentsForALocalID(LocalID, TestTypeID);
        }
    } 
}  
    
