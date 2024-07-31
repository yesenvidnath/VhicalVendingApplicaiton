using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.Funtions
{
    public class loginRegistration
    {
        private dbconnect dbconnect;

        public loginRegistration()
        {
            dbconnect = new dbconnect();
        }

        // Create the Registration methode
        public bool RegisterUser(string firstName, string lastName, string email, string phone, string username, string password, string role)
        {
            try
            {
                dbconnect.OpenConnection();


                //Check if the user name exisst within the db 
                string checkUserQuery = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, dbconnect.GetConnection());
                checkUserCmd.Parameters.AddWithValue("@Username", username);


                int userExists = (int)checkUserCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    Console.WriteLine("User Name Already Exisits");
                    return false;
                }


                string userQuery = "INSERT INTO Users (FirstName, LastName, Email, Phone, Username, Password, Role) OUTPUT INSERTED.UserID VALUES (@FirstName, @LastName, @Email, @Phone, @Username, @Password, @Role)";

                SqlCommand userCmd = new SqlCommand(userQuery, dbconnect.GetConnection());
                userCmd.Parameters.AddWithValue("@FirstName", firstName);
                userCmd.Parameters.AddWithValue("@LastName", lastName);
                userCmd.Parameters.AddWithValue("@Email", email);
                userCmd.Parameters.AddWithValue("@Phone", phone);
                userCmd.Parameters.AddWithValue("@Username", username);
                userCmd.Parameters.AddWithValue("@Password", password);
                userCmd.Parameters.AddWithValue("@Role", role);

                // Execute the command and get the inserted UserID
                int newUserId = (int)userCmd.ExecuteScalar();

                if (role == "Customer")
                {
                    string customerQuery = "INSERT INTO Customers (UserID) VALUES (@UserID)";
                    SqlCommand customerCmd = new SqlCommand(customerQuery, dbconnect.GetConnection());
                    customerCmd.Parameters.AddWithValue("@UserID", newUserId);
                    customerCmd.ExecuteNonQuery();
                }
                else
                {
                    string adminQuery = "INSERT INTO Admin (UserID) VALUES (@UserID)";
                    SqlCommand adminCmd = new SqlCommand(@adminQuery, dbconnect.GetConnection());
                    adminCmd.Parameters.AddWithValue("@UserID", newUserId);
                    adminCmd.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception
                return false;
            }
            finally
            {
                //Close connection 
                dbconnect.CloseConnection();
            }
        }


        // Cretate the login methode 
        public (bool isAuthenticated, int userId, string role) LoginUser(string username, string password)
        {
            int userId = -1;
            string role = string.Empty;
            bool isAuthenticated = false;

            try
            {
                dbconnect.OpenConnection();
                string query = "SELECT UserID, Role FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isAuthenticated = true; // Authentication is true if we have a row
                        userId = reader.IsDBNull(reader.GetOrdinal("UserID")) ? -1 : reader.GetInt32(reader.GetOrdinal("UserID"));
                        role = reader.IsDBNull(reader.GetOrdinal("Role")) ? string.Empty : reader.GetString(reader.GetOrdinal("Role"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                isAuthenticated = false; // Ensure the flag is set correctly in case of an exception
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return (isAuthenticated, userId, role); // Return the tuple with all three values
        }
    }
}
