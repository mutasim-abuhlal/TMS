using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DataAccess
{
    public class clsTeacherData
    {
        public static bool GetTeacherInfoByID(int TeacherID,ref int MajorID,ref int PersonID,ref string Notes,
            ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Teachers WHERE TeacherID = @TeacherID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                MajorID = (int)reader["MajorID"];
                                PersonID = (int)reader["PersonID"];
                                Notes = (reader["Notes"] == DBNull.Value) ? "" : (string)reader["Notes"];
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

        public static bool GetTeacherInfoByPersonID(int PersonID,ref int TeacherID,ref int MajorID,
         ref string Notes,ref int CreatedByUserID,ref DateTime CreationDate)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Teachers WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;
                                TeacherID = (int)reader["TeacherID"];
                                MajorID = (int)reader["MajorID"];
                                Notes = (reader["Notes"] == DBNull.Value) ? "" : (string)reader["Notes"];
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

        public static DataTable GetAllTeachers()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Teachers.TeacherID,Majors.MajorName,People.NationalNo,(People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName,'') + ' ' + People.LastName) AS FullName,
                    Teachers.CreationDate AS EnrollDate FROM Teachers INNER JOIN
		            Majors ON Teachers.MajorID = Majors.MajorID INNER JOIN
		            People ON Teachers.PersonID = People.PersonID;";

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

        public static int AddNewTeacher(int MajroID,int PersonID,string Notes,
            int CreatedByUserID)
        {
            int TeacherID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Teachers(MajorID,PersonID,Notes,CreatedByUserID,CreationDate)
                                     VALUES(@MajorID,@PersonID,@Notes,@CreatedByUserID,GETDATE());

                                    SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MajorID", MajroID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        if (string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);

                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            TeacherID = InsertedID;

                    }
                }
            }
            catch { TeacherID = -1; }

            return TeacherID;
        }

        public static bool UpdateTeacher(int TeacherID,int MajorID,string Notes)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Teachers
                                    SET MajorID = @MajorID,
                                        Notes = @Notes
                                    WHERE TeacherID = @TeacherID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MajorID", MajorID);
                        if (string.IsNullOrEmpty(Notes))
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool DeleteTeacher(int TeacherID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Teachers WEHRE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", TeacherID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool IsTeacherExistByTeacherID(int TeacherID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Teachers WHERE TeacherID = @TeacherID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);

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

        public static bool IsTeacherExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Found = 1 FROM Teachers WHERE PersonID = @PersonID";

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
