using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DataAccess
{
    public class clsStudentData
    {
        public static bool GetStudentInfoByID(int StudentID, ref int PersonID,ref string Notes,
            ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Students WHERE StudentID = @StudentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)reader["PersonID"];
                                if (reader["Notes"] == DBNull.Value)
                                    Notes = "";
                                else
                                    Notes = (string)reader["Notes"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreationDate = (DateTime)reader["CreationDate"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch { IsFound = false; }

            return IsFound;
            }

        public static bool GetStudentInfoByPersonID(int PersonID,ref int StudentID,ref string Notes
            ,ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Students WHERE PersonID = @PersonID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                StudentID = (int)reader["PersonID"];
                                Notes = (string)reader["Notes"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreationDate = (DateTime)reader["CreationDate"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch { IsFound = false; }

            return IsFound;
        }

        public static DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Students.StudentID,Students.PersonID,People.NationalNo,(People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName,'') + ' ' + People.LastName) 
                        AS FullName,Users.UserName as CreatedBy,Students.CreationDate AS EnrollmentDate FROM Students INNER JOIN People ON People.PersonID = Students.PersonID
                        INNER JOIN Users ON Users.UserID = Students.CreatedByUserID;";

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
            catch { }

            return dt;
        }

        public static int AddNewStudent(int PersonID,string Notes,int CreatedByUserID)
        {
            int StudentID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Students(PersonID,Notes,CreatedByUserID,CreationDate)
                                    VALUES(@PersonID,@Notes,@CreatedByUserID,GETDATE())

                                    SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        if (string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                            StudentID = InsertedID;
                    }
                }
            }
            catch { StudentID = -1; }

            return StudentID;
        }

        public static bool UpdateStudent(int StudentID,string Notes)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Students
                                    SET Notes = @Notes
                                    WHERE StudentID = @StudentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        if (string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool DeleteStudent(int StudentID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Students WHERE PersonID = @PersonID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", StudentID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool IsStudentExistByStudentID(int StudentID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Students WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", StudentID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
                        }
                    }
                }
            }
            catch { IsFound = false; }

            return IsFound;
        }

        public static bool IsStudentExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Students WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
                        }
                    }
                }
            }
            catch { IsFound = false; }

            return IsFound;
        }
    }
}
