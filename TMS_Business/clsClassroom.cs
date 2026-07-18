using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsClassroom
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int ClassroomID { get; set; }
        public int MaxNumberOfStudents { get; set; }

        public clsClassroom()
        {
            ClassroomID = -1;
            MaxNumberOfStudents = -1;

            _Mode = enMode.AddNew;
        }

        private clsClassroom(int ClassroomID ,int MaxNumberOfStudents)
        {
            this.ClassroomID = ClassroomID;
            this.MaxNumberOfStudents = MaxNumberOfStudents;

            this._Mode = enMode.Update;
        }

        public static clsClassroom Find(int ClassroomID)
        {
            int MaxNumberOfStudents = -1;

            if (clsClassroomData.GetClassroomInfo(ClassroomID, ref MaxNumberOfStudents))
                return new clsClassroom(ClassroomID, MaxNumberOfStudents);
            else
                return null;
        }

        public static DataTable GetAllClassrooms()
        {
            return clsClassroomData.GetAllClassrooms();
        }

        private bool _AddNewClassroom()
        {
            this.ClassroomID = clsClassroomData.AddNewClassroom(this.MaxNumberOfStudents);

            return this.ClassroomID > -1;
        }

        private bool _UpdateClassroom()
        {
            return clsClassroomData.UpdateClassroom(this.ClassroomID, this.MaxNumberOfStudents);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClassroom())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateClassroom();
            }

            return false;
        }
    }
}
