using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DataAccess
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int CountryID,ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                }

                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetCountryInfoByName(string CountryName,ref int CountryID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)reader["CountryID"];
                }

                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries";

            SqlCommand command = new SqlCommand(query, connection);
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddNewCountry(string CountryName)
        {
            int CountryID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Countries(CountryName)
                            VALUES(@CountryName);

                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && Int32.TryParse(result.ToString(), out int InsertedID))
                    CountryID = InsertedID;
            }
            catch
            {
                CountryID = -1;
            }
            finally
            {
                connection.Close();
            }

            return CountryID;
        }

        public static bool UpdateCountry(int CountryID,string CountryName)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Countries
                            Set CountryName = @CountryName
                            WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch
            {
                RowAffected = 0;
            }
            finally
            {
                connection.Close();
            }

            return RowAffected > 0;
        }
    }
}
