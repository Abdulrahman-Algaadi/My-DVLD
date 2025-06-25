using clsDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace clsLogic
{
public  class clsUser
    {
        public int UserID {  get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID {  get; set; }
        public bool IsActive { get; set; }
       public  clsPerson PerosnInfo { get; set; }

        enum enMode { AddNew,Update}
        enMode Mode = enMode.AddNew;
        public clsUser()
        { 
            this.IsActive = false;
            this.UserID = -1;
            this.Password = "";
            this.PersonID = -1;
            this.UserName = "";
            Mode = enMode.AddNew;
        }
        private clsUser(int PersonID,int UserID,string UserName,string PasssWord ,bool IsActive)
        {
            this.Password= PasssWord;
            this.PersonID = PersonID;
            this.PerosnInfo = clsPerson.FindPerson(this.PersonID);
            this.UserName = UserName;
            this.IsActive = IsActive;
            this.UserID =UserID;
      Mode = enMode.Update;
        }
        private clsUser(int UserID, string UserName, string PasssWord, bool IsActive)
        {
            this.Password = PasssWord;
            this.UserName = UserName;
            this.IsActive = IsActive;
            this.UserID = UserID;
            Mode = enMode.Update;
        }
        public static clsUser FindUserByUserNameAndPassWord(string UserName,string PassWord)
        {
            int UserID = -1, PersonID = -1;
         
            bool IsActive = false;
            string error = "";
            if (clsDataAccess_Sql.FindUserByUserNameAndPassWord(ref UserID, UserName, ref PersonID, PassWord, ref IsActive))
            {
                return new clsUser(PersonID,UserID,UserName,PassWord,IsActive);
            }
            else
                return null;
        }
        public static clsUser FindUserByPersonID(int PersonID)
        {
            int UserID = -1;

            bool IsActive = false;
            string error = "";
            string UserName = "", Password = "";
            if (clsDataAccess_Sql.FindUserByPersonID( ref UserID,ref UserName,  PersonID, ref Password, ref IsActive))
            {
                return new clsUser(PersonID, UserID, UserName, Password, IsActive);
            }
            else
                return null;
        }
        public static clsUser FindUserByID(int UserID)
        {

            bool IsActive = false;
            int PersonID = 0;
            string UserName = "", Password = "";
            if (clsDataAccess_Sql.FindUserByID( UserID, ref UserName, ref Password, ref IsActive, ref PersonID))
            {
                return new clsUser(PersonID, UserID, UserName, Password, IsActive);
            }
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsDataAccess_Sql.GetAllUsers();
        } 
        public static bool IsUserExists(int PersonID)
        {
            return clsDataAccess_Sql.IsColumnExistsUser(PersonID.ToString(),"PersonID");
        }
        public static bool IsUserExists(string UserName)
        {
            return clsDataAccess_Sql.IsColumnExistsUser(UserName, "UserName");
        }

        private  bool _AddUser()
        {
            this.UserID = clsDataAccess_Sql.AddNewUser(this.UserName,this.PersonID,this.Password,this.IsActive);
            return( this.UserID != -1);
          
        }
        private bool _UpdateUser()
        {
            return clsDataAccess_Sql.UpdateUser(this.UserID,this.UserName,this.PersonID,this.Password,this.IsActive);
        }
        public bool Save()
        {
            bool IsSaved = false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddUser())
                    {
                        Mode = enMode.Update;
                        IsSaved = true;
                        break;
                       
                    }
                    break;
                case enMode.Update:
                    return _UpdateUser();
            }
            return IsSaved;
        }
 
        public static bool DeleteUser(string Col,int UserID)
        {
            return clsDataAccess_Sql.DeleteUser(Col,UserID);
        } 
    }
}
