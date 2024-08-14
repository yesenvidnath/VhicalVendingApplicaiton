using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Funtions
{
    public class Users
    {

        private dbconnect dbconnect;

        public Users()
        {
            dbconnect = new dbconnect();
        }

        // Insert User
        public bool InsertUser(string firstName, string lastName, string email, string phone, string username, string password, string role)
        {
            try
            {
                dbconnect.OpenConnection();

                string insertUserQuery = "INSERT INTO Users (FirstName, LastName, Email, Phone, Username, Password, Role) " +
                                         "OUTPUT INSERTED.UserID VALUES (@FirstName, @LastName, @Email, @Phone, @Username, @Password, @Role)";

                SqlCommand cmd = new SqlCommand(insertUserQuery, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                int userId = (int)cmd.ExecuteScalar(); // Get the inserted UserID

                if (role == "Customer")
                {
                    string insertCustomerQuery = "INSERT INTO Customers (CustomerID, UserID) VALUES (@CustomerID, @UserID)";
                    SqlCommand customerCmd = new SqlCommand(insertCustomerQuery, dbconnect.GetConnection());
                    customerCmd.Parameters.AddWithValue("@CustomerID", userId);
                    customerCmd.Parameters.AddWithValue("@UserID", userId);
                    customerCmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during user insertion: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }



        // Update User
        public bool UpdateUser(int userId, string firstName, string lastName, string email, string phone, string username, string password, string role)
        {
            try
            {
                dbconnect.OpenConnection();

                string updateUserQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, " +
                                         "Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(updateUserQuery, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                cmd.ExecuteNonQuery();

                if (role == "Customer")
                {
                    // Check if the customer already exists
                    string checkCustomerQuery = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
                    SqlCommand checkCmd = new SqlCommand(checkCustomerQuery, dbconnect.GetConnection());
                    checkCmd.Parameters.AddWithValue("@CustomerID", userId);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Customer exists, update the UserID
                        string updateCustomerQuery = "UPDATE Customers SET UserID = @UserID WHERE CustomerID = @CustomerID";
                        SqlCommand customerCmd = new SqlCommand(updateCustomerQuery, dbconnect.GetConnection());
                        customerCmd.Parameters.AddWithValue("@CustomerID", userId);
                        customerCmd.Parameters.AddWithValue("@UserID", userId);
                        customerCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Customer does not exist, insert new record
                        string insertCustomerQuery = "INSERT INTO Customers (UserID) VALUES (@UserID)";
                        SqlCommand insertCmd = new SqlCommand(insertCustomerQuery, dbconnect.GetConnection());
                        insertCmd.Parameters.AddWithValue("@UserID", userId);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during user update: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Delete User
        public bool DeleteUser(int userId)
        {
            try
            {
                dbconnect.OpenConnection();

                // First delete from Customers table if user is a Customer
                string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @UserID";
                SqlCommand customerCmd = new SqlCommand(deleteCustomerQuery, dbconnect.GetConnection());
                customerCmd.Parameters.AddWithValue("@UserID", userId);
                customerCmd.ExecuteNonQuery();

                // Then delete from Users table
                string deleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(deleteUserQuery, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during user deletion: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }



        // Search User (by ID or Name)
        public DataTable SearchUser(string searchTerm)
        {
            try
            {
                dbconnect.OpenConnection();

                string searchQuery = "SELECT * FROM Users WHERE UserID = @SearchTerm OR FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm";
                SqlCommand cmd = new SqlCommand(searchQuery, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                return resultTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during user search: " + ex.Message);
                return null;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }

        // GetUserInfoById Method
        public User GetUserInfoById(int userId)
        {
            User user = null;
            string query = "SELECT UserID, FirstName, LastName, Email, Phone, Username, Password FROM Users WHERE UserID = @UserID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            Password = reader.GetString(reader.GetOrdinal("Password")) // Again, consider how you handle passwords
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving user information: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return user;
        }
    }

    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
