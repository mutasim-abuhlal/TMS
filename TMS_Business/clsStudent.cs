using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsStudent
    {
        private enum enMode { AddNew,Update}
        private enMode _Mode;

        public int StudentID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public DateTime CreationDate { get; set; }

        public clsStudent()
        {
            this.StudentID = -1;
            this.PersonID = -1;
            this.Notes = "";
            this.CreatedByUserID = -1;
            this.CreationDate = DateTime.MinValue;

            this._Mode = enMode.AddNew;
        }

        private clsStudent(int StudentID,int PersonID,string Notes,int CreatedByUserID,
            DateTime CreationDate)
        {
            this.StudentID = StudentID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);
            this.CreationDate = CreationDate;

            this._Mode = enMode.Update;
        }

        private bool _AddNewStudent()
        {
            this.StudentID = clsStudentData.AddNewStudent(this.PersonID, this.Notes, this.CreatedByUserID);

            return this.StudentID != -1;
        }

        private bool _UpdateStudent()
        {
            return clsStudentData.UpdateStudent(this.StudentID, this.Notes);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateStudent();
            }

            return false;
        }

        public static DataTable GetAllStudents()
        {
            return clsStudentData.GetAllStudents();
        }


        public static clsStudent FindStudentByStudentID(int StudentID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            string Notes = "";
            DateTime CreationDate = DateTime.MinValue;

            if (clsStudentData.GetStudentInfoByID(StudentID, ref PersonID, ref Notes, ref CreatedByUserID,
                ref CreationDate))
                return new clsStudent(StudentID, PersonID, Notes, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static clsStudent FindStudentByPersonID(int PersonID)
        {
            int StudentID = -1, CreatedByUserID = -1;
            string Notes = "";
            DateTime CreationDate = DateTime.MinValue;

            if (clsStudentData.GetStudentInfoByPersonID(PersonID, ref StudentID, ref Notes, ref CreatedByUserID,
                ref CreationDate))
                return new clsStudent(StudentID, PersonID, Notes, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static bool DeleteStudent(int StudentID)
        {
            return clsStudentData.DeleteStudent(StudentID);
        }

        public static bool IsStudentExistByStudentID(int StudentID)
        {
            return clsStudentData.IsStudentExistByStudentID(StudentID);
        }

        public static bool IsStudentExistByPersonID(int PersonID)
        {
            return clsStudentData.IsStudentExistByStudentID(PersonID);
        }

        public static bool IsStudentEnrolledInThisCourseBefore(int StudentID,int CourseID)
        {
            return clsEnrollmentData.IsStudentEnrolledInThisCourse(StudentID, CourseID);
        }

    }
}
