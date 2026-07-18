using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsPaymentMethod
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        public int MethodID { get; set; }
        public string MethodName { get; set; }

        public clsPaymentMethod()
        {
            this.MethodID = -1;
            this.MethodName = "";

            this._Mode = enMode.AddNew;
        }

        private clsPaymentMethod(int MethodID,string MethodName)
        {
            this.MethodID = MethodID;
            this.MethodName = MethodName;

            this._Mode = enMode.Update;
        }

        public static clsPaymentMethod Find(int MethodID)
        {
            string MethodName = "";

            if (clsPaymentMethodData.GetPaymentMethodInfoByID(MethodID, ref MethodName))
                return new clsPaymentMethod(MethodID, MethodName);
            else
                return null;
        }

        public static clsPaymentMethod Find(string MethodName)
        {
            int MethodID = -1;

            if (clsPaymentMethodData.GetPaymentMethodInfoByName(MethodName, ref MethodID))
                return new clsPaymentMethod(MethodID, MethodName);
            else
                return null;
        }

        public static DataTable GetAllPaymentMethods()
        {
            return clsPaymentMethodData.GetAllPaymentMethods();
        }

        private bool _AddNewPaymentMethod()
        {
            this.MethodID = clsPaymentMethodData.AddNewPaymentMethod(MethodName);

            return this.MethodID != -1;
        }

        private bool _UpdatePaymentMethod()
        {
            return clsPaymentMethodData.UpdatePaymentMethod(this.MethodID, this.MethodName);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPaymentMethod())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePaymentMethod();
            }

            return false;
        }
    }
}
