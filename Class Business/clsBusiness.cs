using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using clsDataAccess;
using Microsoft.SqlServer.Server;
namespace clsLogic
{
    public class clsPerson
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int NatialityCountryID { get; set; }
        public string NationalNo { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ImagePath {  get; set; }
        public byte Gendor {  get; set; }
        public clsCountry CountryInfo { get; set; }
        
        
        private clsPerson( int PersonID ,string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phone,
            DateTime BirthDate, int NatioalityCountryID, string NationalNo,string ImagePath,string Address,byte Gendor)
        {
          this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.BirthDate = BirthDate;
            this.NatialityCountryID = NatioalityCountryID;
            this.NationalNo = NationalNo;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.Gendor = Gendor;
            this.CountryInfo = clsCountry.FindCountry(NatioalityCountryID);

            Mode = enMode.Update;
        }
        public clsPerson()
        {
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.BirthDate=DateTime.Now;
            this.ImagePath = "";
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.NatialityCountryID = -1;
            this.NationalNo = "";
            this.Gendor = 0;

            Mode= enMode.AddNew;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsDataAccess_Sql.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName,this.Email,this.Phone,
           this.BirthDate, this.NatialityCountryID, this.NationalNo,this.ImagePath,this.Address,this.Gendor);

            return this.PersonID!=-1;
               
        }
        public static  clsPerson FindPerson(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = ""
               , NationalNo = "", ImagePath = "", Address = "";
        DateTime BirthDate = DateTime.Now;
            int NatioalityCountryID = -1;
            byte Gendor = 0;

            if (clsDataAccess_Sql.FindPersonByID(ID,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref Email,ref Phone,
                ref BirthDate,ref NatioalityCountryID,ref NationalNo,ref ImagePath,ref Address,ref Gendor))
            {
                return new clsPerson(ID,FirstName,SecondName,ThirdName,LastName,Email,Phone,BirthDate,NatioalityCountryID,NationalNo,ImagePath,Address,Gendor);
            }
            return null;
        }
        public  string FullName()
        {
            return this.FirstName +" "+this.SecondName+" "+this.ThirdName+" "+this.LastName;
        }
        public static clsPerson FindPerson(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = ""
               , ImagePath = "", Address = "";
            DateTime BirthDate = DateTime.Now;
            int NatioalityCountryID = -1;
            int ID = -1;
            byte Gendor = 0;

            if (clsDataAccess_Sql.FindPersonByNationalNo(ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Email, ref Phone,
                ref BirthDate, ref NatioalityCountryID,  NationalNo, ref ImagePath, ref Address, ref Gendor))
            {
                return new clsPerson(ID, FirstName, SecondName, ThirdName, LastName, Email, Phone, BirthDate, NatioalityCountryID, NationalNo, ImagePath, Address, Gendor);
            }
            return null;
        }
        private bool _UpdatePerson()
        {
         string errormessage = "";

            return clsDataAccess_Sql.UpdatePerson(this.PersonID,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.Email,this.Phone,this.BirthDate,
                this.NatialityCountryID,this.NationalNo,this.ImagePath,this.Address,this.Gendor);

        }
        public bool Save()
        {
            bool IsSaved = false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        IsSaved= true; 
                        break;
                    }
                    break;
                case enMode.Update:
                    return _UpdatePerson();
            }
            return IsSaved;
        }
        public static DataTable GetAllPeople()
        {
            return clsDataAccess_Sql.GetAllPeople(); ;
        }
        public static bool IsColumnExists(string NewNational,string Column)
        { 
            return clsDataAccess_Sql.IsColumnExists(NewNational,Column);
        }
        public static bool DeletePerson(string Column,int TheWay)
        {
            return clsDataAccess_Sql.DeletePerson(Column,TheWay);
        }
    }
}
