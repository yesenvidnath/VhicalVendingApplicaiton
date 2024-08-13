using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.MainUserControls;

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

        // Add to cart
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
   

        // Remove from cart
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

        // Get the total cart items quntity
        public int GetTotalCartItemsQuantity(int customerId)
        {
            int totalQuantity = 0;
            try
            {
                dbconnect.OpenConnection();
                SqlCommand command = new SqlCommand("SELECT SUM(Quantity) FROM CartItems WHERE CustomerID = @CustomerID", dbconnect.GetConnection());
                command.Parameters.AddWithValue("@CustomerID", customerId);

                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalQuantity = Convert.ToInt32(result);
                    Console.WriteLine("Total Quantity Retrieved: " + totalQuantity); // Debugging output
                }
                else
                {
                    Console.WriteLine("No items found for customer ID: " + customerId); // Debugging output
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving total cart items quantity: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return totalQuantity;
        }

        //Get cart items in to the list 

        public List<CartItem> GetCartItems(int userId)
        {
            List<CartItem> cartItems = new List<CartItem>();

            // Get the CustomerID based on the logged-in UserID
            int customerId = customers.GetCustomerIdByUserId(userId);

            string query = @"SELECT ci.CartItemID, ci.Quantity, ci.AddedOn, 
                            ISNULL(c.Model, p.PartName) AS ItemName, 
                            ISNULL(c.Price, p.Price) AS Price, 
                            ISNULL(c.Image, p.Image) AS Image
                     FROM CartItems ci
                     LEFT JOIN Cars c ON ci.CarID = c.CarID
                     LEFT JOIN CarParts p ON ci.PartID = p.PartID
                     WHERE ci.CustomerID = @CustomerID";

            SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
            cmd.Parameters.AddWithValue("@CustomerID", customerId);

            dbconnect.OpenConnection();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CartItem cartItem = new CartItem
                    {
                        CartItemID = reader.GetInt32(reader.GetOrdinal("CartItemID")),
                        ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        ImagePath = reader.GetString(reader.GetOrdinal("Image"))
                    };
                    cartItems.Add(cartItem);
                }
            }
            dbconnect.CloseConnection();

            return cartItems;
        }


        public void RemoveFromCart(int cartItemId)
        {
            string deleteQuery = "DELETE FROM CartItems WHERE CartItemID = @CartItemID";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbconnect.GetConnection());
            deleteCommand.Parameters.AddWithValue("@CartItemID", cartItemId);

            dbconnect.OpenConnection();
            deleteCommand.ExecuteNonQuery();
            dbconnect.CloseConnection();
        }


    }

    public class CartItem
    {
        public int CartItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
