using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsUser
    {
        private enum enMode { AddNew, Update};
        private enMode _Mode;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            this._Mode = enMode.AddNew;
        }

        private clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            this._Mode = enMode.Update;
        }

        public static clsUser FindUserByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = null,Password = null;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = null, Password = null;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static DataTable GetAllUsersLogs()
        {
            return clsUserData.GetAllUsersLogs();
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password);

            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public bool UpdatePassword()
        {
            return clsUserData.UpdatePassword(UserID, Password);
        }

        public static bool UpdatePassword(int UserID,string Password)
        {
            return clsUserData.UpdatePassword(UserID, Password);
        }

        public bool DisActive()
        {
            return clsUserData.DisActiveUser(UserID);
        }

        public static bool DisActive(int UserID)
        {
            return clsUserData.DisActiveUser(UserID);
        }

        public bool Login()
        {
            return clsUserData.AddNewUserLogin(this.UserID, false) > -1;
        }

        public bool Logout()
        {
            return clsUserData.AddNewUserLogin(this.UserID, true) > -1;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExistByUserID(int UserID)
        {
            return clsUserData.IsUserExistByUserID(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserData.IsUserExistByPersonID(PersonID);
        }

        public static bool IsUserExistByUserName(string UserName)
        {
            return clsUserData.IsUserExistByUserName(UserName);
        }
    }
}
