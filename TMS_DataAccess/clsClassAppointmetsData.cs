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
    public class clsClassAppointmetsData
    {
        public static bool GetAppointmentInfoByID(int AppointmentID,ref byte day,ref TimeSpan StartAt,
            ref TimeSpan EndAt,ref int ClassID,ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM ClassAppointments WHERE AppointmentID = @AppointmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                day = (byte)reader["Day"];
                                StartAt = (TimeSpan)reader[("StartAt")];
                                EndAt = (TimeSpan)reader["EndAt"];
                                ClassID = (int)reader["ClassID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreationDate = (DateTime)reader["CreationDate"];
                            }
                            else
                                IsFound = false;
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

        public static DataTable GetAllAppointments()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT ClassAppointments.AppointmentID,
                                     CASE 
                                        WHEN ClassAppointments.Day = 0 then 'Starday'
										WHEN ClassAppointments.Day = 1 then 'Sunday'
									    WHEN ClassAppointments.Day = 2 then 'Monday'
									    WHEN ClassAppointments.Day = 3 then 'Tuesday'
										WHEN ClassAppointments.Day = 4 then 'Wednesday'
								        WHEN ClassAppointments.Day = 5 then 'Thirsday'
									    WHEN ClassAppointments.Day = 6 then 'Friday'
                                     END AS Day,
                                     CAST(StartAt AS time(0)) AS StartAt,
                                     CAST(EndAt AS time(0)) AS EndAt,
                                     ClassAppointments.CreationDate 
                                     FROM ClassAppointments;";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetAllAppointmentsForOneClass(int ClassID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT ClassAppointments.AppointmentID,
                                     CASE 
                                        WHEN ClassAppointments.Day = 0 then 'Starday'
										WHEN ClassAppointments.Day = 1 then 'Sunday'
									    WHEN ClassAppointments.Day = 2 then 'Monday'
									    WHEN ClassAppointments.Day = 3 then 'Tuesday'
										WHEN ClassAppointments.Day = 4 then 'Wednesday'
								        WHEN ClassAppointments.Day = 5 then 'Thirsday'
									    WHEN ClassAppointments.Day = 6 then 'Friday'
                                     END AS Day,
                                     CAST(StartAt AS time(0)) AS StartAt,
                                     CAST(EndAt AS time(0)) AS EndAt,
                                     ClassAppointments.CreationDate 
                                     FROM ClassAppointments WHERE ClassID = @ClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewAppointment(byte Day,TimeSpan StartAt,TimeSpan EndAt,
            int ClassID,int CreatedByUserID,DateTime CreationDate)
        {
            int AppointmentID = -1;

            try
            {
                using(SqlConnection connection= new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO ClassAppointments(Day,StartAt,EndAt,ClassID,CreatedByUserID,CreationDate)
                                     VALUES(@Day,@StartAt,@EndAt,@ClassID,@CreatedByUserID,@CreationDate);

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Day", Day);
                        command.Parameters.AddWithValue("@StartAt", StartAt);
                        command.Parameters.AddWithValue("@EndAt", EndAt);
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@CreationDate", CreationDate);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                            AppointmentID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                AppointmentID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return AppointmentID;
        }

        public static bool UpdateAppointment(int AppointmentID,byte Day,
            TimeSpan StartAt,TimeSpan EndAt)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE ClassAppointments
                                     SET Day = @Day,
                                         StartAt = @StartAt,
                                         EndAt = @EndAt
                                     WHERE AppointmentID = @AppointmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Day", Day);
                        command.Parameters.AddWithValue("@StartAt", StartAt);
                        command.Parameters.AddWithValue("@EndAt", EndAt);
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM ClassAppointments WHERE AppointmentID = @AppointmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }

        public static bool IsAppointmentExist(int AppointmentID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT FOUND = 1 FROM ClassAppointments WHERE AppointmentID = @AppointmentID";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
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

        public static bool IsThereAnotherAppointmentAtSameTime(TimeSpan StartAt,
            TimeSpan EndAt,int Day)
        {
            bool Found = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Found = 1 FROM ClassAppointments ca
                                    WHERE ca.Day = @Day AND
                                    NOT (@EndAt < ca.StartAt OR ca.EndAt < @StartAt);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Day", Day);
                        command.Parameters.AddWithValue("@StartAt", StartAt);
                        command.Parameters.AddWithValue("@EndAt", EndAt);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            Found = reader.HasRows;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Found = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return Found;
        }
    }
}
