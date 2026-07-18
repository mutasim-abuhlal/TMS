using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsEnrollment
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int EnrollmentID { get; set; }
        public int ClassID { get; set; }
        public clsClass ClassInfo { get; set; }
        public int StudentID { get; set; }
        public clsStudent StudentInfo { get; set; }
        public string Notes { get; set; }
        public DateTime EnrollDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }

        public clsEnrollment()
        {
            this.EnrollmentID = -1;
            this.ClassID = -1;
            this.StudentID = -1;
            this.Notes = "";
            this.EnrollDate = DateTime.MinValue;
            this.CreatedByUserID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsEnrollment(int EnrollmentID,int ClassID,int StudentID,
            string Notes,DateTime EnrollDate,int CreatedByUserID)
        {
            this.EnrollmentID = EnrollmentID;
            this.ClassID = ClassID;
            this.ClassInfo = clsClass.Find(this.ClassID);
            this.StudentID = StudentID;
            this.StudentInfo = clsStudent.FindStudentByStudentID(this.StudentID);
            this.Notes = Notes;
            this.EnrollDate = EnrollDate;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);

            this._Mode = enMode.Update;
        }

        public static clsEnrollment Find(int EnrollmentID)
        {
            int ClassID = -1, StudentID = -1, CreatedByUserID = -1;
            string Notes = "";
            DateTime EnrollDate = DateTime.MinValue;

            if (clsEnrollmentData.GetEnrollmentInfoByID(EnrollmentID, ref ClassID, ref StudentID,
                ref Notes, ref EnrollDate, ref CreatedByUserID))
                return new clsEnrollment(EnrollmentID, ClassID, StudentID, Notes,
                    EnrollDate, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllEnrollments()
        {
            return clsEnrollmentData.GetAllEnrollments();
        }

        public static bool DeleteEnrollment(int EnrollmentID)
        {
            return clsEnrollmentData.DeleteEnrollment(EnrollmentID);
        }

        public static bool IsEnrollmentExist(int EnrollmentID)
        {
            return clsEnrollmentData.IsEnrollmentExistByID(EnrollmentID);
        }

        private bool _AddNewEnrollment()
        {
            this.EnrollmentID = clsEnrollmentData.AddNewEnrollment(ClassID, StudentID,
                Notes, CreatedByUserID);

            return this.EnrollmentID != -1;
        }

        private bool _UpdateEnrollment()
        {
            return clsEnrollmentData.UpdateEnrollment(EnrollmentID, Notes);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEnrollment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                    case enMode.Update:
                    return _UpdateEnrollment();
            }

            return false;
        }
    }
}
