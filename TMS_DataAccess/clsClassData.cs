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
    public class clsClassData
    {
        public static bool GetClassInfoByClassID(int ClassID, ref int CourseID,
            ref int ClassroomID,ref int NumberOfStudents,
            ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Classes WHERE ClassID = @ClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                CourseID = (int)reader["CourseID"];
                                ClassroomID = (int)reader["ClassroomID"];
                                NumberOfStudents = Convert.ToInt32(reader["NumberOfStudents"]);
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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static DataTable GetAllClasses(int CourseID)
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                    	cs.ClassID,
                                    	cs.ClassroomID,
                                    	C.CourseName,
                                    	dbo.GetPersonFullNameByID(T.PersonID) AS TeacherName,
                                    	cs.NumberOfStudents
                                    FROM Classes cs
                                    INNER JOIN Courses C ON cs.CourseID = C.CourseID
                                    INNER JOIN Teachers T ON C.TeacherID = T.TeacherID
                                    WHERE cs.CourseID = @CourseID;";

                    using(SqlCommand command = new SqlCommand (query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);

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

        public static int AddNewClass(int CourseID,int ClassroomID,int CreatedByUserID)
        {
            int ClassID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Classes(CourseID,ClassroomID,CreatedByUserID,CreationDate)
                                     VALUES(@CourseID,@ClassroomID,@CreatedByUserID,GETDATE());

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);
                        command.Parameters.AddWithValue("@ClassroomID", ClassroomID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object Result = command.ExecuteScalar();

                        if(Result != null && int.TryParse(Result.ToString(),out int InsertedID))
                            ClassID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                ClassID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return ClassID;
        }

        public static bool UpdateClass(int ClassID,int ClassroomID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Classes
                                     SET ClassroomID = @ClassroomID
                                     WHERE ClassID = @ClassID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ClassroomID", ClassroomID);
                        command.Parameters.AddWithValue("@ClassID", ClassID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }

        public static bool DeleteClass(int ClassID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Classes WHERE ClassID = @ClassID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.ConnectionString,ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }

        public static bool IsClassExist(int ClassID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT FOUND = 1 FROM Classes WHERE ClassID = @ClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.ConnectionString, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }
    }
}
