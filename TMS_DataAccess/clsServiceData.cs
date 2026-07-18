using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;

namespace TMS_DataAccess
{
    public class clsServiceData
    {
        public static bool GetServiceInfoByID(int ServiceID,ref string ServiceName,
            ref string ServiceDescription,ref float ServiceFees)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Services WHERE ServiceID = @ServiceID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;
                                ServiceName = (string)reader["ServiceName"];
                                ServiceDescription = (string)reader["ServiceDescription"];
                                ServiceFees = Convert.ToSingle((decimal)reader["ServiceFees"]);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                IsFound = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static bool GetServiceInfoByServiceName(string ServiceName,ref int ServiceID,
           ref string ServiceDescription, ref float ServiceFees)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Services WHERE ServiceName = @ServiceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                ServiceID = (int)reader["ServiceID"];
                                ServiceDescription = (string)reader["ServiceDescription"];
                                ServiceFees = Convert.ToSingle((decimal)reader["ServiceFees"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static DataTable GetAllServices()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Services";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                   System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewService(string ServiceName,string ServiceDescription,float ServiceFees)
        {
            int ServiceID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Services(ServiceName,ServiceDescription,ServiceFees)
                                    VALUES(@ServiceName,@ServiceDescription,@ServiceFees);

                                    SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue(@"ServiceName", ServiceName);
                        command.Parameters.AddWithValue(@"ServiceDescription", ServiceDescription);
                        command.Parameters.AddWithValue(@"ServiceFees", ServiceFees);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                            ServiceID = InsertedID;
                    }
                }
            }
            catch( Exception ex )
            {
                ServiceID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                   System.Diagnostics.EventLogEntryType.Error);
            }

            return ServiceID;
        }

        public static bool UpdateService(int ServiceID,string ServiceName,string ServiceDescription,
            float ServiceFees)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Services
                                     SET ServiceName = @ServiceName,
                                         ServiceDescription = @ServiceDescription
                                         ServiceFees = @ServiceFees
                                     WHERE ServiceID = @ServiceID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);
                        command.Parameters.AddWithValue("@ServiceDescription", ServiceDescription);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        command.Parameters.AddWithValue("@ServiceFees", ServiceFees);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }
    }
}
