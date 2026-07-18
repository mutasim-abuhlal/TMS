using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DataAccess;

namespace TMS_Business
{
    public class clsService
    {
        private enum enMode { AddNew,Update}
        private enMode _Mode;

        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public float ServiceFees { get; set; }

        public clsService()
        {
            this.ServiceID = -1;
            this.ServiceName = "";
            this.ServiceDescription = "";
            this.ServiceFees = -1;

            this._Mode = enMode.AddNew;
        }

        private clsService(int ServiceID,string ServiceName,string ServiceDescription,
            float ServiceFees)
        {
            this.ServiceID = ServiceID;
            this.ServiceName = ServiceName;
            this.ServiceDescription = ServiceDescription;
            this.ServiceFees = ServiceFees;

            this._Mode = enMode.Update;
        }

        public static clsService Find(int ServiceID)
        {
            string ServiceName = "", ServiceDescription = "";
            float ServiceFees = -1;

            if (clsServiceData.GetServiceInfoByID(ServiceID, ref ServiceName, ref ServiceDescription,
                ref ServiceFees))
                return new clsService(ServiceID, ServiceName, ServiceDescription,ServiceFees);
            else
                return null;
        }

        public static clsService Find(string ServiceName)
        {
            int ServiceID = -1;
            string ServiceDescription = "";
            float ServiceFees = -1;

            if (clsServiceData.GetServiceInfoByServiceName(ServiceName, ref ServiceID,
                ref ServiceDescription,ref ServiceFees))
                return new clsService(ServiceID, ServiceName, ServiceDescription,ServiceFees);
            else
                return null;
        }

        public static DataTable GetAllServices()
        {
            return clsServiceData.GetAllServices();
        }

        private bool _AddNewService()
        {
            this.ServiceID = clsServiceData.AddNewService(ServiceName, ServiceDescription,ServiceFees);

            return this.ServiceID > -1;
        }

        private bool _UpdateService()
        {
            return clsServiceData.UpdateService(this.ServiceID, this.ServiceName,
                this.ServiceDescription, this.ServiceFees);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewService())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateService();
            }

            return false;
        }
    }
}
