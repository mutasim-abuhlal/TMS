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
    public class clsCourse
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public clsSubject SubjectInfo { get; set; }
        public int TeacherID { get; set; }
        public clsTeacher TeacherInfo { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public DateTime CreationDate { get; set; }

        public clsCourse()
        {
            CourseID = -1;
            SubjectID = -1;
            TeacherID = -1;
            CourseName = "";
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            CreatedByUserID = -1;
            CreationDate = DateTime.MinValue;

            _Mode = enMode.AddNew;
        }

        private clsCourse(int CourseID,int SubjectID,int TeacherID,
            string CourseName,DateTime StartDate,DateTime EndDate,
            int CreatedByUserID,DateTime CreationDate)
        {
            this.CourseID = CourseID;
            this.SubjectID = SubjectID;
            this.SubjectInfo = clsSubject.Find(this.SubjectID);
            this.TeacherID = TeacherID;
            this.TeacherInfo = clsTeacher.FindTeacherByTeacherID(this.TeacherID);
            this.CourseName = CourseName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);
            this.CreationDate = CreationDate;

            this._Mode = enMode.Update;
        }

        public static clsCourse Find(int CourseID)
        {
            int SubjectID = -1, TeacherID = -1, CreatedByUserID = -1;
            string CourseName = "";
            DateTime StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, CreationDate = DateTime.MinValue;

            if (clsCourseData.GetCourseInfoByID(CourseID, ref SubjectID, ref TeacherID,
                ref CourseName, ref StartDate, ref EndDate,
                ref CreatedByUserID, ref CreationDate))
                return new clsCourse(CourseID, SubjectID, TeacherID, CourseName, StartDate,
                    EndDate, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static DataTable GetAllCourses()
        {
            return clsCourseData.GetAllCourses();
        }

        public static DataTable GetAllCourses(int StudentID)
        {
            return clsCourseData.GetAllCources(StudentID);
        }

        private bool _AddNewCourse()
        {
            this.CourseID = clsCourseData.AddNewCourse(SubjectID, TeacherID, CourseName,
                StartDate, EndDate, CreatedByUserID);

            return this.CourseID > -1;
        }

        private bool _UpdateCourse()
        {
            return clsCourseData.UpdateCourse(CourseID, SubjectID, TeacherID, CourseName,
                StartDate, EndDate);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCourse())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateCourse();
            }

            return false;
        }

        public static bool DeleteCourse(int CourseID)
        {
            return clsCourseData.DeleteCourse(CourseID);
        }

        public static bool IsCourseExist(int CourseID)
        {
            return clsCourseData.IsCourseExistByCourseID(CourseID);
        }

        public static bool IsCourseExist(string CourseName)
        {
            return clsCourseData.IsCourseExistByCourseName(CourseName);
        }
    }
}
