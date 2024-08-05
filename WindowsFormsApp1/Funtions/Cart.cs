using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Funtions.Customer;

namespace WindowsFormsApp1.Funtions
{

    public class Cart
    {
        private dbconnect dbconnect;
        private Customers customers;
        private Cars cars;

        public Cart()
        {
            dbconnect = new dbconnect();
            customers = new Customers();
            cars = new Cars();
        }


        public void AddToCart(int userId, int carId, int quantity)
        {
            int customerId = customers.GetCustomerIdByUserId(userId);

            // Check if the item already exists in the cart for this customer
            string checkQuery = "SELECT CartItemID, Quantity FROM CartItems WHERE CustomerID = @CustomerID AND CarID = @CarID";
            SqlCommand checkCommand = new SqlCommand(checkQuery, dbconnect.GetConnection());
            checkCommand.Parameters.AddWithValue("@CustomerID", customerId);
            checkCommand.Parameters.AddWithValue("@CarID", carId);

            dbconnect.OpenConnection();
            SqlDataReader reader = checkCommand.ExecuteReader();

            if (reader.Read())
            {
                // Item exists, update the quantity
                int cartItemId = Convert.ToInt32(reader["CartItemID"]);
                int existingQuantity = Convert.ToInt32(reader["Quantity"]);
                reader.Close();

                string updateQuery = "UPDATE CartItems SET Quantity = @Quantity WHERE CartItemID = @CartItemID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, dbconnect.GetConnection());
                updateCommand.Parameters.AddWithValue("@Quantity", existingQuantity + quantity);
                updateCommand.Parameters.AddWithValue("@CartItemID", cartItemId);

                updateCommand.ExecuteNonQuery();
            }
            else
            {
                // Item does not exist, insert a new record
                reader.Close();

                string insertQuery = "INSERT INTO CartItems (CustomerID, CarID, Quantity, AddedOn) VALUES (@CustomerID, @CarID, @Quantity, @AddedOn)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, dbconnect.GetConnection());
                insertCommand.Parameters.AddWithValue("@CustomerID", customerId);
                insertCommand.Parameters.AddWithValue("@CarID", carId);
                insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                insertCommand.Parameters.AddWithValue("@AddedOn", DateTime.Now);

                insertCommand.ExecuteNonQuery();
            }

            dbconnect.CloseConnection();
        }


        public void RemoveFromCart(int userId, int carId)
        {
            int customerId = customers.GetCustomerIdByUserId(userId);

            string deleteQuery = "DELETE FROM CartItems WHERE CustomerID = @CustomerID AND CarID = @CarID";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbconnect.GetConnection());
            deleteCommand.Parameters.AddWithValue("@CustomerID", customerId);
            deleteCommand.Parameters.AddWithValue("@CarID", carId);

            dbconnect.OpenConnection();
            deleteCommand.ExecuteNonQuery();
            dbconnect.CloseConnection();
        }


        public void UpdateCartQuantity(int userId, int carId, int newQuantity)
        {
            int customerId = customers.GetCustomerIdByUserId(userId);

            string updateQuery = "UPDATE CartItems SET Quantity = @Quantity WHERE CustomerID = @CustomerID AND CarID = @CarID";
            SqlCommand updateCommand = new SqlCommand(updateQuery, dbconnect.GetConnection());
            updateCommand.Parameters.AddWithValue("@Quantity", newQuantity);
            updateCommand.Parameters.AddWithValue("@CustomerID", customerId);
            updateCommand.Parameters.AddWithValue("@CarID", carId);

            dbconnect.OpenConnection();
            updateCommand.ExecuteNonQuery();
            dbconnect.CloseConnection();
        }
    }
}
