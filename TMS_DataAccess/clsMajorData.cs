using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DataAccess
{
    public class clsMajorData
    {
        public static bool GetMajorInfoByID(int MajorID,ref string MajorName)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Majors WHERE MajorID = @MajorID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MajorID", MajorID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                MajorName = (string)reader["MajorName"];
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

        public static bool GetMajorInfoByMajorName(string MajorName, ref int MajorID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Majors WHERE MajorName = @MajorName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MajorName", MajorName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                MajorID = (int)reader["MajorID"];
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

        public static DataTable GetAllMajors()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Majors";

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

        public static int AddNewMajor(string MajorName)
        {
            int MajorID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Majors(MajorName)
                                     VALUES(@MajorName);

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MajorName", MajorName);

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            MajorID = InsertedID;
                    }
                }
            }
            catch { MajorID = -1; }

            return MajorID;
        }

        public static bool UpdateMajor(int MajorID,string MajorName)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Majors
                                     SET MajorName = @MajorName

                                     WHERE MajorID = @MajorID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MajorID", MajorID);
                        command.Parameters.AddWithValue("@MajorName", MajorName);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = -1; }

            return RowAffected > 0;
        }
    }
}
