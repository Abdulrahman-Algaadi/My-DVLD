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
    public  class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        public clsCountry(int countryid,string countryname) {
        this.CountryID = countryid;
        this.CountryName = countryname;
        }

        public static DataTable GetAllCountries()
        {
            return clsDataAccess_Sql.GetAllCountries(); ;

        }
        public static clsCountry FindCountry(string CountryName)
        {
            int CountryID = -1;

           if(clsDataAccess_Sql.FindCountryByName(CountryName,ref CountryID)){
                return new clsCountry(CountryID,CountryName);
            }
            return null;
        }
        public static clsCountry FindCountry(int CountryID)
        {

            string CountryName = "";
            if (clsDataAccess_Sql.FindCountryByID(ref CountryName,  CountryID))
            {
                return new clsCountry(CountryID, CountryName);
            }
            return null;
        }
    }
}
