using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UtilityLib;

namespace TMS_DataAccess
{
    public class clsCourseData
    {
        public static bool GetCourseInfoByID(int CourseID,ref int SubjectID,ref int TeacherID,ref string CourseName,
            ref DateTime StartDate,ref DateTime EndDate,ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                SubjectID = (int)reader["SubjectID"];
                                TeacherID = (int)reader["TeacherID"];
                                CourseName = (string)reader["CourseName"];
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreationDate = (DateTime)reader["CreationDate"];
                            }
                            else
                                IsFound = false;
                    }
                    }
                }
            }catch(Exception ex)
            {
                IsFound = false;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static DataTable GetAllCourses()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                        Courses.CourseID,
                                        Courses.CourseName,
                                        Courses.TeacherID,
                                        Subjects.SubjectName,
                                        Courses.StartDate,
                                        Courses.EndDate
                                    FROM Courses 
                                    INNER JOIN Subjects on Courses.SubjectID = Subjects.SubjectID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
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

        public static DataTable GetAllCources(int StudentID)
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Students.StudentID,
                            (People.FirstName + CHAR(32) + People.SecondName +
                            CHAR(32) + ISNULL(People.ThirdName,'') + CHAR(32) + People.LastName) AS StudentName,
                            Courses.CourseName,Teachers.TeacherID,Subjects.SubjectName FROM Courses 
                            INNER JOIN Subjects ON Subjects.SubjectID = Courses.SubjectID
                            INNER JOIN Teachers ON Teachers.TeacherID = Courses.TeacherID
                            INNER JOIN Enrollments ON Enrollments.CourseID = Courses.CourseID
                            INNER JOIN Students ON Enrollments.StudentID = @StudentID
                            INNER JOIN People ON People.PersonID = Students.PersonID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", StudentID);
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

        public static int AddNewCourse(int SubjectID,int TeacherID,string CourseName,
            DateTime StartDate,DateTime EndDate,int CreatedByUserID)
        {
            int CourseID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Courses(SubjectID,TeacherID,CourseName,
                                    StartDate,EndDate,CreatedByUserID,CreationDate)
                
                                    VALUES(@SubjectID,@TeacherID,@CourseName,
                                    @StartDate,@EndDate,@CreatedByUserID,GETDATE());

                                    SELECT SCOPE_IDENTITY();";
                    
                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@SubjectID", SubjectID);
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);
                        command.Parameters.AddWithValue("@CourseName", CourseName);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                       
                        object Result = command.ExecuteScalar();

                        if (Result != null && Int32.TryParse(Result.ToString(), out int InsertedID))
                            CourseID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                CourseID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return CourseID;
        }

        public static bool UpdateCourse(int CourseID,int SubjectID,int TeacherID,string CourseName,
            DateTime StartDate,DateTime EndDate)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Courses
                                   SET SubjectID = @SubjectID,
                                       TeacherID = @TeacherID,
                                       CourseName = @CourseName,
                                       StartDate = @StartDate,
                                       EndDate = @EndDate
                                   WHERE CourseID = @CourseID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);
                        command.Parameters.AddWithValue("@SubjectID", SubjectID);
                        command.Parameters.AddWithValue("@CourseName", CourseName);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

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

        public static bool DeleteCourse(int CourseID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Courses WHERE CourseID = @CourseID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);
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

        public static bool IsCourseExistByCourseID(int CourseID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Courses WHERE CourseID = @CourseID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", CourseID);

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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }

        public static bool IsCourseExistByCourseName(string CourseName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Courses WHERE CourseName = @CourseName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseName", CourseName);

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
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return IsFound;
        }
    }
}
