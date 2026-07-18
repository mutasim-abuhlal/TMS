using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsMajor
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;
        public int MajorID { get; set; }
        public string MajorName { get; set; }

        public clsMajor()
        {
            MajorID = -1;
            MajorName = "";

            _Mode = enMode.AddNew;
        }

        public clsMajor(int MajorID,string MajorName)
        {
            this.MajorID = MajorID;
            this.MajorName = MajorName;

            _Mode = enMode.Update;
        }

        public static clsMajor Find(int MajorID)
        {
            string MajorName = "";

            if (clsMajorData.GetMajorInfoByID(MajorID, ref MajorName))
                return new clsMajor(MajorID, MajorName);
            else
                return null;
        }

        public static clsMajor Find(string MajorName)
        {
            int MajorID = -1;

            if (clsMajorData.GetMajorInfoByMajorName(MajorName, ref MajorID))
                return new clsMajor(MajorID, MajorName);
            else
                return null;
        }

        public static DataTable GetAllMajors()
        {
            return clsMajorData.GetAllMajors();
        }

        private bool _AddNewMajor()
        {
            this.MajorID = clsMajorData.AddNewMajor(MajorName);

            return this.MajorID > -1;
        }

        private bool _UpdateMajor()
        {
            return clsMajorData.UpdateMajor(this.MajorID, this.MajorName);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewMajor())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdateMajor();
            }

            return false;
        }
    }
}
