using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilityLib;

namespace TMS_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID,ref string NationalNo,ref string FirstName,
            ref string SecondName,ref string ThirdName,ref string LastName,ref DateTime DateOfBirth,
            ref bool Gendor,ref string Phone,ref string Address,ref string Email,
            ref int NationalityCountryID,ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (bool)reader["Gendor"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    if (reader["Email"] == DBNull.Value)
                        Email = "";
                    else
                        Email = (string)reader["Email"];

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];
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

        public static bool GetPersonInfoByNationalNo(string NationalNo,ref int PersonID, ref string FirstName,
           ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref bool Gendor, ref string Phone, ref string Address, ref string Email,
           ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (bool)reader["Gendor"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    if (reader["Email"] == DBNull.Value)
                        Email = "";
                    else
                        Email = (string)reader["Email"];

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];
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

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                            People.DateOfBirth,
                        CASE 

	                        When People.Gendor = 0 then 'Male'
	                        else 'Female'

                        END AS Gendor
                        , People.Phone, People.Email, Countries.CountryName
                            FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID";

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

        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,string ThirdName,
            string LastName ,DateTime DateOfBirth,bool Gendor,string Phone,string Address,string Email,
            int NationalityCountryID,string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People(NationalNo,FirstName,SecondName,ThirdName,LastName,
                DateOfBirth,Gendor,Phone,Address,Email,NationalityCountryID,ImagePath)
                
                VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,
                @DateOfBirth,@Gendor,@Phone,@Address,@Email,@NationalityCountryID,@ImagePath);

                SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if(string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);

            if(string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if(string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && Int32.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;
            }
            catch
            {
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, bool Gendor, string Phone, string Address, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People
                            SET NationalNo = @NationalNo,
                                FirstName = @FirstName,
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                LastName = @LastName,
                                DateOfBirth = @DateOfBirth,
                                Gendor = @Gendor,
                                Phone = @Phone,
                                Address = @Address,
                                Email = @Email,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath = @ImagePath
                                WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

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

        public static bool DeletePerson(int PersonID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM People WHERE PersonID = @PersonID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.ConnectionString,ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }


            return RowAffected > 0;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    IsFound = true;

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    IsFound = true;

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
    }
}
