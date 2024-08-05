using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Funtions.Customer
{
    public class Customers
    {
        private dbconnect dbconnect;

        public Customers() 
        {
            dbconnect = new dbconnect();    
        }


        //Set Customer Info based on ID 
        public (string firstName, string lastName, string email, string phone) GetCustomerInfo(int userId)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;

            try
            {
                dbconnect.OpenConnection();
                string query = "SELECT FirstName, LastName, Email, Phone " +
               "FROM Users " +
               "WHERE UserID = @UserID AND Role = 'customer'";
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? "" : reader.GetString(reader.GetOrdinal("FirstName"));
                        lastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? "" : reader.GetString(reader.GetOrdinal("LastName"));
                        email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email"));
                        phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? "" : reader.GetString(reader.GetOrdinal("Phone"));
                    }
                    else
                    {
                        Console.WriteLine("SQL error please check");
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error retrieving customer info:" + ex.Message); 
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return(firstName, lastName, email, phone);
        }


        //Insert Customer
        public bool InsertCustomer(string firstName, string lastName, string email, string phone, string username, string password)
        {
            bool isInserted = false;
            try
            {
                dbconnect.OpenConnection();
                // Insert into Users table
                string queryUser = "INSERT INTO Users (FirstName, LastName, Email, Phone, Username, Password, Role) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone, @Username, @Password, 'Customer'); " +
                                   "SELECT SCOPE_IDENTITY();";

                SqlCommand cmdUser = new SqlCommand(queryUser, dbconnect.GetConnection());
                cmdUser.Parameters.AddWithValue("@FirstName", firstName);
                cmdUser.Parameters.AddWithValue("@LastName", lastName);
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.Parameters.AddWithValue("@Phone", phone);
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@Password", password);


                // Execute and get the generated UserID
                int userId = Convert.ToInt32(cmdUser.ExecuteScalar());

                if (userId > 0)
                {
                    // Insert into Customers table using the generated UserID
                    string queryCustomer = "INSERT INTO Customers (CustomerID, UserID) VALUES (@CustomerID, @UserID)";
                    SqlCommand cmdCustomer = new SqlCommand(queryCustomer, dbconnect.GetConnection());
                    cmdCustomer.Parameters.AddWithValue("@CustomerID", userId);
                    cmdCustomer.Parameters.AddWithValue("@UserID", userId);

                    cmdCustomer.ExecuteNonQuery();
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting customer: " + ex.Message);
                isInserted = false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return isInserted;
        }


        //Update custoemr 
        public bool UpdateCustomer(int userId, string firstName, string lastName, string email, string phone, string username, string password)
        {
            bool isUpdated = false;

            try
            {
                dbconnect.OpenConnection();
                // Update Users table
                string queryUser = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                                   "Phone = @Phone, Username = @Username, Password = @Password " +
                                   "WHERE UserID = @UserID AND Role = 'Customer'";

                SqlCommand cmdUser = new SqlCommand(queryUser, dbconnect.GetConnection());
                cmdUser.Parameters.AddWithValue("@FirstName", firstName);
                cmdUser.Parameters.AddWithValue("@LastName", lastName);
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.Parameters.AddWithValue("@Phone", phone);
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@Password", password);
                cmdUser.Parameters.AddWithValue("@UserID", userId);

                int rowsAffected = cmdUser.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating customer: " + ex.Message);
                isUpdated = false;
            }
            finally
            {
                dbconnect.CloseConnection();    
            }

            return isUpdated;
        }


        //Delete customer 
        public bool DeleteCustomer(int userId)
        {
            bool isDeleted = false;

            try
            {
                dbconnect.OpenConnection();

                // Delete from Customers table
                string queryCustomer = "DELETE FROM Customers WHERE UserID = @UserID";
                SqlCommand cmdCustomer = new SqlCommand(queryCustomer, dbconnect.GetConnection());
                cmdCustomer.Parameters.AddWithValue("@UserID", userId);
                cmdCustomer.ExecuteNonQuery();

                // Delete from Users table
                string queryUser = "DELETE FROM Users WHERE UserID = @UserID AND Role = 'Customer'";
                SqlCommand cmdUser = new SqlCommand(queryUser, dbconnect.GetConnection());
                cmdUser.Parameters.AddWithValue("@UserID", userId);

                int rowsAffected = cmdUser.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error deleting customer: " + ex.Message);
                isDeleted = false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return !isDeleted;
        }

        //Search Customer 
        public (string firstName, string lastName, string email, string phone) SearchCustomer(int userId)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;

            try
            {
                dbconnect.OpenConnection();
                string query = "SELECT FirstName, LastName, Email, Phone FROM Users WHERE UserID = @UserID AND Role = 'Customer'";
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        lastName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        email = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        phone = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching customer: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return (firstName, lastName, email, phone);
        }


        public int GetCustomerIdByUserId(int userId)
        {
            int customerId = 0;
            string query = "SELECT CustomerID FROM Customers WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, dbconnect.GetConnection());
            command.Parameters.AddWithValue("@UserID", userId);

            dbconnect.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                customerId = Convert.ToInt32(reader["CustomerID"]);
            }
            reader.Close();
            dbconnect.CloseConnection();

            return customerId;
        }
    }
}
