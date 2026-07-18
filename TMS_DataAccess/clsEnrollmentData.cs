using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;

namespace TMS_DataAccess
{
    public class clsEnrollmentData
    {
        public static bool GetEnrollmentInfoByID(int EnrollmentID,ref int ClassID,
            ref int StudentID,ref string Notes,ref DateTime EnrollDate,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;
                                ClassID = (int)reader["ClassID"];
                                StudentID = (int)reader["StudentID"];

                                if (reader["Notes"] == DBNull.Value)
                                    Notes = "";
                                else
                                    Notes = (string)reader["Notes"];

                                EnrollDate = (DateTime)reader["EnrollDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllEnrollments()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                        Enrollments.EnrollmentID,
                                        Classes.ClassID,
                                        (People.FirstName + ' ' + People.SecondName + ' ' 
                                        + ISNULL(People.ThirdName,'') + ' ' + People.LastName) AS FullName,
                                        Enrollments.EnrollDate 
                                    FROM Enrollments

                                    INNER JOIN Classes ON Classes.ClassID = Enrollments.ClassID
                                    INNER JOIN Students ON Students.StudentID = Enrollments.StudentID
                                    INNER JOIN People ON Students.PersonID = People.PersonID;";

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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewEnrollment(int ClassID,int StudentID,string Notes,
            int CreatedByUserID)
        {
            int EnrollmentID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Enrollments(ClassID,StudentID,Notes,EnrollDate
                                    ,CreatedByUserID)
                                     VALUES(@ClassID,@StudentID,@Notes,GETDATE(),@CreatedByUserID);

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        if (!string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", Notes);
                        else
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                            EnrollmentID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                EnrollmentID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return EnrollmentID;
        }

        public static bool UpdateEnrollment(int EnrollmentID,string Notes)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Enrollments
                                     SET Notes = @Notes
                                     WHERE EnrollmentID = @EnrollmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        if (!string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", Notes);
                        else
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);

                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
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

        public static bool DeleteEnrollment(int EnrollmentID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
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

        public static bool IsEnrollmentExistByID(int EnrollmentID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT FOUND = 1 FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static bool IsStudentEnrolledInThisCourse(int StudentID,int ClassID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT FOUND = 1 FROM Enrollments
                                    WHERE
                                    StudentID = @StudentID AND
                                    ClassID = @ClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
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
    }
}
