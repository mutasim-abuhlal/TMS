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
    public class clsPaymentData
    {
        public static bool GetPaymentInfoByID(int PaymentID,ref int EnrollmentID,
            ref int PaymentMethodID,ref DateTime PaymentDate,ref int CreatedByUserID,
            ref int ServiceID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;
                                EnrollmentID = (int)reader["EnrollmentID"];
                                PaymentMethodID = (int)reader["PaymentMethodID"];
                                PaymentDate = (DateTime)reader["PaymentDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                ServiceID = (int)reader["ServiceID"];
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

        
        public static bool GetPaymentInfoByEnrollmentID(int EnrollmentID, ref int PaymentID,
            ref int PaymentMethodID, ref DateTime PaymentDate, ref int CreatedByUserID,
            ref int ServiceID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Payments WHERE EnrollmentID = @EnrollmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PaymentID = (int)reader["PaymentID"];
                                PaymentMethodID = (int)reader["PaymentMethodID"];
                                PaymentDate = (DateTime)reader["PaymentDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                ServiceID = (int)reader["ServiceID"];
                            }
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
        
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Payments.PaymentID,Payments.EnrollmentID,PaymentMethods.MethodName,
                                    Services.ServiceName,Payments.PaymentDate FROM Payments
                                    INNER JOIN PaymentMethods ON Payments.PaymentMethodID = PaymentMethods.MethodID
                                    INNER JOIN Services ON Payments.ServiceID = Services.ServiceID;";

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

        public static DataTable GetAllPaymentsPerStudent(int StudentID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Payments.PaymentID,Payments.EnrollmentID,PaymentMethods.MethodName,
                                     Services.ServiceName,Payments.PaymentDate FROM Payments
                                    INNER JOIN PaymentMethods ON Payments.PaymentMethodID = PaymentMethods.MethodID
                                    INNER JOIN Services ON Payments.ServiceID = Services.ServiceID
                                    INNER JOIN Enrollments ON Payments.EnrollmentID = Enrollments.EnrollmentID
                                    WHERE Enrollments.StudentID = @StudentID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
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
            catch (Exception ex)
            {
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewPayment(int EnrollmentID,int PaymentMethodID,
            int ServiceID,int CreatedByUserID)
        {
            int PaymentID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Payments(EnrollmentID,PaymentMethodID,ServiceID,CreatedByUserID,PaymentDate)
                                     VALUES (@EnrollmentID,@PaymentMethodID,@ServiceID,@CreatedByUserID,GETDATE());

                                     SELECT SCOPE_IDENTITY();";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
                        command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(),out int InsertedID))
                            PaymentID = InsertedID;
                    }
                }
            }
            catch(Exception ex)
            {
                PaymentID = -1;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return PaymentID;
        }

        public static bool UpdatePayment(int PaymentID, int PaymentMethodID)
        {
            int RowAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Payments
                                     SET PaymentMethodID = @PaymentMethodID
                                     WHERE PaymentID = @PaymentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
             }

            return RowAffected > 0;
        }

        public static bool DeletePayment(int PaymentID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                RowAffected = 0;
                clsUtility.WriteEventLogEntry(clsDataAccessSettings.AppName, ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
            }

            return RowAffected > 0;
        }

        public static bool IsPaymentExistByID(int PaymentID)
        {
            bool IsFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT FOUND = 1 FROM Payments WHERE PaymentID = @PaymentID";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);

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

        public static bool IsPaymentExistByEnrollmentID(int EnrollmentID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT FOUND = 1 FROM Payments WHERE EnrollmentID = @EnrollmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

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
