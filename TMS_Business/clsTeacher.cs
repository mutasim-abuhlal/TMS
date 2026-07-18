using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsTeacher
    {
        private enum enMode { AddNew,Update}
        private enMode _Mode;

        public int TeacherID { get; set; }
        public int MajorID { get; set; }
        public clsMajor MajorInfo { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public DateTime CreationDate { get; set; }

        public clsTeacher()
        {
            TeacherID = -1;
            MajorID = -1;
            PersonID = -1;
            Notes = "";
            CreatedByUserID = -1;
            CreationDate = DateTime.MinValue;

            _Mode = enMode.AddNew;
        }

        private clsTeacher(int TeacherID,int MajorID,int PersonID,string Notes,
            int CreatedByUserID,DateTime CreationDate)
        {
            this.TeacherID = TeacherID;
            this.MajorID = MajorID;
            this.MajorInfo = clsMajor.Find(this.MajorID);
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
            this.CreationDate = CreationDate;

            _Mode = enMode.Update;
        }

        public static clsTeacher FindTeacherByTeacherID(int TeacherID)
        {
            int MajorID = -1, PersonID = -1, CreatedByUserID = -1;
            string Notes = "";
            DateTime CreationDate = DateTime.MinValue;

            if (clsTeacherData.GetTeacherInfoByID(TeacherID, ref MajorID, ref PersonID, ref Notes,
                ref CreatedByUserID, ref CreationDate))
                return new clsTeacher(TeacherID, MajorID, PersonID
                    , Notes, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static clsTeacher FindTeacherByPersonID(int PersonID)
        {
            int TeacherID = -1, MajorID = -1, CreatedByUserID = -1;
            string Notes = "";
            DateTime CreationDate = DateTime.MinValue;

            if (clsTeacherData.GetTeacherInfoByPersonID(PersonID, ref TeacherID, ref MajorID, ref Notes,
              ref CreatedByUserID, ref CreationDate))
                return new clsTeacher(TeacherID, MajorID, PersonID
                    , Notes, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static DataTable GetAllTeachers()
        {
            return clsTeacherData.GetAllTeachers();
        }

        private bool _AddNewTeacher()
        {
            this.TeacherID = clsTeacherData.AddNewTeacher(MajorID, PersonID, Notes, CreatedByUserID);

            return this.TeacherID > -1;
        }

        private bool _UpdateTeacher()
        {
            return clsTeacherData.UpdateTeacher(TeacherID, MajorID, Notes);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTeacher())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTeacher();
            }

            return false;
        }

        public static bool DeleteTeacher(int TeacherID)
        {
            return clsTeacherData.DeleteTeacher(TeacherID);
        }

        public static bool IsTeacherExistByTeacherID(int TeacherID)
        {
            return clsTeacherData.IsTeacherExistByTeacherID(TeacherID);    
        }

        public static bool IsTeacherExistByPersonID(int PersonID)
        {
            return clsTeacherData.IsTeacherExistByPersonID(PersonID);
        }
    }
}
