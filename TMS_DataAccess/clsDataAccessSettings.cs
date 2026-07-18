using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TMS_DataAccess
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["TMS_ConnectionString"].ConnectionString;

        public static string AppName = ConfigurationManager.AppSettings["AppName"];


    }
}
