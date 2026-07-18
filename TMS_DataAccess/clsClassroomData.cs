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
    public class clsClassroomData
    {
        public static bool GetClassroomInfo(int ClassroomID,ref int MaxNumberOfStudents)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Classrooms WHERE ClassroomID = @ClassroomID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ClassroomID", ClassroomID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                MaxNumberOfStudents = (int)reader["MaxNumberOfStudents"];
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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static DataTable GetAllClassrooms()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Classrooms";

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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewClassroom(int MaxNumberOfStudents)
        {
            int ClassroomID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Classrooms(MaxNumberOfStudents)
                                     VALUES(@MaxNumberOfStudents);

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MaxNumberOfStudents", MaxNumberOfStudents);

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            ClassroomID = InsertedID;

                    }
                }
            }
            catch(Exception ex)
            {
                ClassroomID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,System.Diagnostics.EventLogEntryType.Error);
            }

            return ClassroomID;
        }

        public static bool UpdateClassroom(int ClassroomID,int MaxNumberOfStudents)
        {
            int RowAffected = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Classrooms
                                     SET MaxNumberOfStudents = @MaxNumberOfStudents
                                     WHERE ClassroomID = @ClassroomID";

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaxNumberOfStudetns", MaxNumberOfStudents);
                        command.Parameters.AddWithValue("@ClassroomID", ClassroomID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }
    }
}
