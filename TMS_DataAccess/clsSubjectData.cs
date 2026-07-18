using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;

namespace TMS_DataAccess
{
    public class clsSubjectData
    {
        public static bool GetSubjetInfoByID(int SubjectID,ref string SubjectName
            ,ref string SubjectDescription)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Subjects WHERE SubjectID = @SubjectID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@SubjectID", SubjectID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                SubjectName = (string)reader["SubjectName"];
                                SubjectDescription = (string)reader["SubjectDescription"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                IsFound = true;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static bool GetSubjectInfoBySubjectName(string SubjectName,ref int SubjectID,
            ref string SubjectDescription)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Subjects WHERE SubjectName = @SubjectName";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@SubjectName", SubjectName);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;
                                SubjectID = (int)reader["SubjectID"];
                                SubjectName = (string)reader["SubjectName"];
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                IsFound = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static DataTable GetAllSubjects()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Subjects";

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

        public static int AddNewSubject(string SubjectName,string SubjectDescription)
        {
            int SubjectID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Subjects(SubjectName,SubjectDescription)
                                            VALUES(@SubjectName,@SubjectDescription);

                                            SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@SubjectName", SubjectName);
                        command.Parameters.AddWithValue("@SubjectDescription", SubjectDescription);

                        object Result = command.ExecuteScalar();

                        if(Result != null && int.TryParse(Result.ToString(),out int InsertedID))
                            SubjectID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                SubjectID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,System.Diagnostics.EventLogEntryType.Error);
            }

            return SubjectID;
        }

        public static bool UpdateSubject(int SubjectID, string SubjectName, string SubjectDescription)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Subjects
                                     SET SubjectName = @SubjectName,
                                         SubjectDescription = @SubjectDescription

                                     WHERE SubjectID = @SubjectID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubjectName", SubjectName);
                        command.Parameters.AddWithValue("@SubjectDescription", SubjectDescription);
                        command.Parameters.AddWithValue("@SubjectID", SubjectID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }
    }
}
