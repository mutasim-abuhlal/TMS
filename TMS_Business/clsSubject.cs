using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsSubject
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }

        public clsSubject()
        {
            SubjectID = -1;
            SubjectName = "";
            SubjectDescription = "";

            _Mode = enMode.AddNew;
        }

        private clsSubject(int SubjectID,string SubjectName,string SubjectDescription)
        {
            this.SubjectID = SubjectID;
            this.SubjectName = SubjectName;
            this.SubjectDescription = SubjectDescription;

            this._Mode = enMode.Update;
        }

        public static clsSubject Find(int SubjectID)
        {
            string SubjectName = "", SubjectDescription = "";

            if (clsSubjectData.GetSubjetInfoByID(SubjectID, ref SubjectName, ref SubjectDescription))
                return new clsSubject(SubjectID, SubjectName, SubjectDescription);
            else
                return null;
        }

        public static clsSubject Find(string SubjectName)
        {
            int SubjectID = -1;
            string SubjectDescription = "";

            if (clsSubjectData.GetSubjectInfoBySubjectName(SubjectName, ref SubjectID, ref SubjectDescription))
                return new clsSubject(SubjectID, SubjectName, SubjectDescription);
            else
                return null;
        }

        public static DataTable GetAllSubjects()
        {
            return clsSubjectData.GetAllSubjects();
        }

        private bool _AddNewSubject()
        {
            this.SubjectID = clsSubjectData.AddNewSubject(SubjectName, SubjectDescription);

            return SubjectID > -1;
        }

        private bool _UpdateSubject()
        {
            return clsSubjectData.UpdateSubject(SubjectID, SubjectName, SubjectDescription);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubject())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateSubject();
            }

            return false;
        }
    }
}
