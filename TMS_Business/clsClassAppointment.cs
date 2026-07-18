using System;
using System.Data;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsClassAppointment
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int AppointmentID { get; set; }
        public byte Day { get; set; }
        public string DayCaption
        {
            get
            {
                switch(Day)
                {
                    case 0:
                        return "Satrday";
                    case 1:
                        return "Sunday";
                    case 2:
                        return "Monday";
                    case 3:
                        return "Thuesday";
                    case 4:
                        return "Wednesday";
                    case 5:
                        return "Thursday";
                    case 6:
                        return "Friday";
                }

                return "";
            }
        }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public int ClassID { get; set; }
        public clsClass ClassInfo { get;}
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; }
        public DateTime CreationDate { get; set; }

        public clsClassAppointment()
        {
            this.AppointmentID = -1;
            this.Day = 0;
            this.StartAt = new TimeSpan(0, 0, 0);
            this.EndAt = new TimeSpan(0, 0, 0);
            this.ClassID = -1;
            this.CreatedByUserID = -1;
            this.CreationDate = DateTime.MinValue;

            this._Mode = enMode.AddNew;
        }

        private clsClassAppointment(int AppointmentID,byte Day,TimeSpan StartAt,
            TimeSpan EndAt
            ,int ClassID,int CreatedByUserID,DateTime CreationDate)
        {
            this.AppointmentID = AppointmentID;
            this.Day = Day;
            this.StartAt = StartAt;
            this.EndAt = EndAt;
            this.ClassID = ClassID;
            this.ClassInfo = clsClass.Find(ClassID);
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
            this.CreationDate = CreationDate;

            this._Mode = enMode.Update;
        }

        public static clsClassAppointment Find(int AppointmentID)
        {
            int ClassID = -1,CreatedByUserID = -1;
            TimeSpan StartAt = new TimeSpan(0, 0, 0), EndAt = new TimeSpan(0, 0, 0);
            byte Day = 0;
            DateTime CreationDate = DateTime.MinValue;

            if (clsClassAppointmetsData.GetAppointmentInfoByID(AppointmentID, ref Day, ref StartAt,
                ref EndAt,ref ClassID, ref CreatedByUserID, ref CreationDate))
                return new clsClassAppointment(AppointmentID, Day, StartAt,EndAt, ClassID,
                    CreatedByUserID, CreationDate);
            else
                return null;
        }

        public static DataTable GetAllSessionAppointments()
        {
            return clsClassAppointmetsData.GetAllAppointments();
        }

        public static DataTable GetAllAppointmentsForOneClass(int ClassID)
        {
            return clsClassAppointmetsData.GetAllAppointmentsForOneClass(ClassID);
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsClassAppointmetsData.AddNewAppointment(Day, StartAt,
                EndAt,ClassID, CreatedByUserID,this.CreationDate);

            return this.AppointmentID != -1;
        }

        private bool _UpdateAppointment()
        {
            return clsClassAppointmetsData.UpdateAppointment(this.AppointmentID, Day, StartAt,EndAt);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            return clsClassAppointmetsData.DeleteAppointment(AppointmentID);
        }

        public static bool IsAppointmentExist(int AppointmentID)
        {
            return clsClassAppointmetsData.IsAppointmentExist(AppointmentID);
        }

        public static bool IsThereAnotherAppointmentAtSameTime(TimeSpan StartAt,
            TimeSpan EndAt,int Day)
        {
            return clsClassAppointmetsData.IsThereAnotherAppointmentAtSameTime(StartAt, EndAt, Day);
        }
    }
}
