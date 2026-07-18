using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsClass
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int ClassID { get; set; }
        public int CourseID { get; set; }
        public clsCourse CourseInfo { get; set; }
        public int ClassroomID { get; set; }
        public int NumberOfStudents { get; set; }
        public clsClassroom ClassroomInfo { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public DateTime CreationDate { get; set; }

        public clsClass()
        {
            ClassID = -1;
            CourseID = -1;
            ClassroomID = -1;
            NumberOfStudents = -1;
            CreatedByUserID = -1;
            CreationDate = DateTime.MinValue;

            _Mode = enMode.AddNew;
        }

        private clsClass(int ClassID, int CourseID,int ClassroomID,
            int NumberOfStudents,int CreatedByUserID,DateTime CreationDate)
        {
            this.ClassID = ClassID;
            this.CourseID = CourseID;
            this.CourseInfo = clsCourse.Find(this.CourseID);
            this.ClassroomID = ClassroomID;
            this.ClassroomInfo = clsClassroom.Find(this.ClassroomID);
            this.NumberOfStudents = NumberOfStudents;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);
            this.CreationDate = CreationDate;

            this._Mode = enMode.Update;
        }
        
        public static clsClass Find(int ClassID)
        {
            int CourseID = -1, ClassroomID = -1, CreatedByUserID = -1,
                    NumberOfStudents = -1;
            DateTime CreationDate= DateTime.MinValue;

            if (clsClassData.GetClassInfoByClassID(ClassID, ref CourseID, ref ClassroomID,
                ref NumberOfStudents, ref CreatedByUserID, ref CreationDate))
                return new clsClass(ClassID, CourseID, ClassroomID
                    ,NumberOfStudents, CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static DataTable GetAllClasses(int CourseID)
        {
            return clsClassData.GetAllClasses(CourseID);
        }

        private bool _AddNewClass()
        {
            this.ClassID = clsClassData.AddNewClass(this.CourseID, this.ClassroomID, this.CreatedByUserID);

            return this.ClassID > -1;
        }

        private bool _UpdateClass()
        {
            return clsClassData.UpdateClass(ClassID, this.ClassroomID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClass())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateClass();
            }

            return false;
        }

        public static bool DeleteClass(int SessionID)
        {
            return clsClassData.DeleteClass(SessionID);
        }

        public static bool IsClassExist(int SessionID)
        {
            return clsClassData.IsClassExist(SessionID);
        }
    }
}
