using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TMS_DataAccess
{
    public static class clsUserData
    {
        public static bool GetUserInfoByID(int UserID,ref int PersonID,ref string UserName,
            ref string Password,ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID,ref string UserName,
            ref string Password,ref bool IsActive)
        {
            bool IsFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch
            {
                IsFound = false;
            }
            
            return IsFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(string UserName,string Password,
            ref int UserID,ref int PersonID,ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Users WHERE 
                                    UserName = @UserName AND Password = @Password";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select Users.UserID,People.PersonID, (People.FirstName + ' ' + People.SecondName + ' ' + IsNUll(People.ThirdName,'') + ' ' + People.LastName) as FullName,
                                    Users.UserName,Users.IsActive From Users 
                                    inner join People on Users.PersonID = People.PersonID;";

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
            catch
            {

            }

            return dt;
        }

        public static int AddNewUser(int PersonID,string UserName,string Password)
        {
            int UserID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Users(PersonID,UserName,Password,IsActive)
                                VALUES(@PersonID,@UserName,@Password,@IsActive);

                                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", true);

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            UserID = InsertedID;
                    }
                }
            }
            catch { UserID = -1; }

            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID,
            string UserName,string Password,
            bool IsActive)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Users
                                    SET PersonID = @PersonID,
                                        UserName = @UserName,
                                        Password = @Password,
                                        IsActive = @IsActive
                                    WHERE UserID = @UserID;";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                RowAffected = 0;
            }

            return RowAffected > 0;
        }  

        public static bool DeleteUser(int UserID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Users WHERE UserID = @UserID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool DisActiveUser(int UserID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Users
                                            SET IsActive = 0 WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool UpdatePassword(int UserID,string Password)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Users 
                                        SET Password = @Password WHERE UserID = @UserID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@UserID", UserID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { RowAffected = 0; }

            return RowAffected > 0;
        }

        public static bool IsUserExistByUserID(int UserID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection())
                {
                    connection.Open();

                    string query = @"SELECT Found = 1 FROM Users Where UserID = @UserID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

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

        public static bool IsUserExistByUserName(string UserName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.Open();

                    string query = @"SELECT Found = 1 FROM Users Where UserName = @UserName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

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

        public static int AddNewUserLogin(int UserID,bool LogAction)
        {
            int UserLoginID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO UserLogs(UserID,LogAction,LogDate)
                                    VALUES(@UserID,@LogAction,GetDate());

                                    SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@LogAction", LogAction);

                        object Result = command.ExecuteScalar();

                        if(Result != null && int.TryParse(Result.ToString(),out int InsertedID))
                            UserLoginID = InsertedID;
                    }
                }
            }
            catch { UserLoginID = -1; }

            return UserLoginID;
        }

        public static DataTable GetAllUsersLogs()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT UserLogs.LogID,(People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName,'') + ' ' + People.LastName) AS FullName,
                                Users.UserName, CASE 
                                
                                	WHEN UserLogs.LogAction = 0 THEN 'Login'
                                	ELSE 'Logout'
                                END as LogAction,UserLogs.LogDate
                                
                                FROM UserLogs INNER JOIN Users on UserLogs.UserID = Users.UserID
                                INNER JOIN People on People.PersonID = Users.PersonID
                                order by UserLogs.LogDate;";

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
    }
}
