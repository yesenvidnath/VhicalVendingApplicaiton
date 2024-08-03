using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Funtions.Customer
{
    public class Orders
    {
        private dbconnect dbconnect;

        public Orders()
        {
            dbconnect = new dbconnect();
        }

        // Insert a new order
        public int InsertOrder(int customerId, List<OrderDetail> orderDetails)
        {
            int orderId = -1;
            decimal totalAmount = CalculateTotalAmount(orderDetails);

            string insertOrderQuery = "INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status) " +
                                      "VALUES (@CustomerID, @OrderDate, @TotalAmount, @Status);" +
                                      "SELECT SCOPE_IDENTITY();";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(insertOrderQuery, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@Status", "Pending");

                orderId = Convert.ToInt32(cmd.ExecuteScalar());

                if (orderId > 0)
                {
                    foreach (var detail in orderDetails)
                    {
                        InsertOrderDetail(orderId, detail.CarID, detail.PartID, detail.Quantity, detail.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting order: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return orderId;
        }


        // Insert a new order detail
        private void InsertOrderDetail(int orderId, int? carId, int? partId, int quantity, decimal price)
        {
            string insertOrderDetailQuery = "INSERT INTO OrderDetails (OrderID, CarID, PartID, Quantity, Price) " +
                                            "VALUES (@OrderID, @CarID, @PartID, @Quantity, @Price)";

            try
            {
                SqlCommand cmd = new SqlCommand(insertOrderDetailQuery, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@CarID", carId.HasValue ? (object)carId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@PartID", partId.HasValue ? (object)partId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting order detail: " + ex.Message);
            }
        }


        // Update an order
        public bool UpdateOrder(int orderId, string status)
        {
            string updateOrderQuery = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(updateOrderQuery, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@Status", status);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating order: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Delete an order
        public bool DeleteOrder(int orderId)
        {
            string deleteOrderDetailsQuery = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";
            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";

            try
            {
                dbconnect.OpenConnection();

                // Start transaction
                SqlTransaction transaction = dbconnect.GetConnection().BeginTransaction();

                // Delete OrderDetails
                SqlCommand cmdOrderDetails = new SqlCommand(deleteOrderDetailsQuery, dbconnect.GetConnection(), transaction);
                cmdOrderDetails.Parameters.AddWithValue("@OrderID", orderId);
                cmdOrderDetails.ExecuteNonQuery();

                // Delete Order
                SqlCommand cmdOrder = new SqlCommand(deleteOrderQuery, dbconnect.GetConnection(), transaction);
                cmdOrder.Parameters.AddWithValue("@OrderID", orderId);
                int result = cmdOrder.ExecuteNonQuery();

                // Commit transaction
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting order: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Search for orders by ID or CustomerID
        public List<Order> SearchOrders(string keyword)
        {
            List<Order> orders = new List<Order>();
            string searchOrderQuery = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, Status FROM Orders " +
                                      "WHERE OrderID = @Keyword OR CustomerID = @Keyword";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(searchOrderQuery, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@Keyword", keyword);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            OrderDate = reader.GetDateTime(2),
                            TotalAmount = reader.GetDecimal(3),
                            Status = reader.GetString(4)
                        };
                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching orders: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return orders;
        }


        // Search for order details by OrderID
        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            string searchOrderDetailsQuery = "SELECT OrderDetailID, OrderID, CarID, PartID, Quantity, Price FROM OrderDetails " +
                                             "WHERE OrderID = @OrderID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(searchOrderDetailsQuery, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@OrderID", orderId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDetail detail = new OrderDetail
                        {
                            OrderDetailID = reader.GetInt32(0),
                            OrderID = reader.GetInt32(1),
                            CarID = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                            PartID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Quantity = reader.GetInt32(4),
                            Price = reader.GetDecimal(5)
                        };
                        orderDetails.Add(detail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving order details: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return orderDetails;
        }


        // Calculate the total amount for an order
        private decimal CalculateTotalAmount(List<OrderDetail> orderDetails)
        {
            decimal totalAmount = 0;

            foreach (var detail in orderDetails)
            {
                totalAmount += detail.Quantity * detail.Price;
            }

            return totalAmount;
        }
    }

    // Order class to hold the order data
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }

    // OrderDetail class to hold the order detail data
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int? CarID { get; set; }
        public int? PartID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
