using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsPerson
    {
        private enum enMode { AddNew,Update}
        private enMode _Mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }

        public DateTime DateOfBirth { get; set; }
        public bool Gendor { get; set; }
        public string GendorCaption { get { return (!Gendor) ? "Male" : "Female"; } }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountryInfo { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = false;
            this.Phone = "";
            this.Address = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            this._Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID,string NationalNo,string FirstName,string SecondName,
            string ThirdName,string LastName,DateTime DateOfBirth,bool Gendor,string Phone,string Address,
            string Email,int NationalityCountryID,string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Phone = Phone;
            this.Address = Address;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(this.NationalityCountryID);
            this.ImagePath = ImagePath;

            this._Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Phone, this.Address, this.Email, this.NationalityCountryID, this.ImagePath);

            return this.PersonID != -1;
        }
        
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo,
                this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Phone, this.Address, this.Email,
                this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Phone = "", Address = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gendor = false;
            int NationalityCountryID = -1;


            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,ref LastName,
                ref DateOfBirth, ref Gendor,ref Phone,ref Address,ref Email,ref NationalityCountryID,ref ImagePath))
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gendor, Phone, Address, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Phone = "", Address = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gendor = false;
            int NationalityCountryID = -1, PersonID = -1;


            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID,ref FirstName,ref SecondName,ref ThirdName,ref LastName,
                ref DateOfBirth,ref Gendor,ref Phone,ref Address,ref Email,ref NationalityCountryID,ref ImagePath))
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gendor, Phone, Address, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
