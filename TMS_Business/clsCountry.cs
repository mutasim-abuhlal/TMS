using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsCountry
    {
        private enum enMode { AddNew, Update}
        private enMode _Mode;

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";

            this._Mode = enMode.AddNew;
        }

        private clsCountry(int CountryID , string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;

            this._Mode = enMode.Update;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(CountryID, ref CountryName))
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryData.GetCountryInfoByName(CountryName, ref CountryID))
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryData.AddNewCountry(CountryName);

            return this.CountryID != -1;
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateCountry();
            }

            return false;
        }
    }
}
