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
    }
}
