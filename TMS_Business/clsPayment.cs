using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsPayment
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int PaymentID { get; set; }
        public int EnrollmentID { get; set; }
        public int PaymentMethodID { get; set; }
        public clsPaymentMethod PaymentMethodInfo { get; set; }
        public int ServiceID { get; set; }
        public clsService ServiceInfo { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public DateTime PaymentDate { get; set; }

        public clsPayment()
        {
            this.PaymentID = -1;
            this.EnrollmentID = -1;
            this.PaymentMethodID = -1;
            this.ServiceID = -1;
            this.CreatedByUserID = -1;
            this.PaymentDate = DateTime.MinValue;

            this._Mode = enMode.AddNew;
        }

        private clsPayment(int PaymentID,int EnrollmentID,
            int PaymentMethodID,int ServiceID,int CreatedByUserID,DateTime PaymentDate)
        {
            this.PaymentID = PaymentID;
            this.EnrollmentID = EnrollmentID;
            this.PaymentMethodID = PaymentMethodID;
            this.PaymentMethodInfo = clsPaymentMethod.Find(this.PaymentMethodID);
            this.ServiceID = ServiceID;
            this.ServiceInfo = clsService.Find(this.ServiceID);
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);
            this.PaymentDate = PaymentDate;

            this._Mode = enMode.Update;
        }

        public static clsPayment Find(int PaymentID)
        {
            int EnrollmentID = -1, PaymentMethodID = -1, ServiceID = -1, CreatedByUserID = -1;
            DateTime PaymentDate = DateTime.MinValue;

            if (clsPaymentData.GetPaymentInfoByID(PaymentID, ref EnrollmentID, ref PaymentMethodID,
                ref PaymentDate, ref CreatedByUserID, ref ServiceID))
                return new clsPayment(PaymentID, EnrollmentID, PaymentMethodID, ServiceID, CreatedByUserID,
                    PaymentDate);
            else
                return null;
        }

        public static clsPayment FindByEnrollmentID(int EnrollmentID)
        {
            int PaymentID = -1, PaymentMethodID = -1, ServiceID = -1, CreatedByUserID = -1;
            DateTime PaymentDate = DateTime.MinValue;

            if (clsPaymentData.GetPaymentInfoByEnrollmentID(EnrollmentID, ref PaymentID, ref PaymentMethodID,
                ref PaymentDate, ref CreatedByUserID, ref ServiceID))
                return new clsPayment(PaymentID, EnrollmentID, PaymentMethodID, ServiceID, CreatedByUserID,
                    PaymentDate);
            else
                return null;
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }

        public static DataTable GetAllPaymentsPerStudent(int StudentID)
        {
            return clsPaymentData.GetAllPaymentsPerStudent(StudentID);
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.EnrollmentID, this.PaymentMethodID,
                this.ServiceID, this.CreatedByUserID);

            return this.PaymentID != -1;
        }

        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(PaymentID, PaymentMethodID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePayment();
            }

            return false;
        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

        public static bool IsPaymentExistByID(int PaymentID)
        {
            return clsPaymentData.IsPaymentExistByID(PaymentID);
        }

        public static bool IsPaymentExistByEnrollmentID(int EnrollmentID)
        {
            return clsPaymentData.IsPaymentExistByEnrollmentID(EnrollmentID);
        }
    }
}
