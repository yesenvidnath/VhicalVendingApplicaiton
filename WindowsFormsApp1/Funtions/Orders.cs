using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.MainUserControls.NavBar;
using System.Windows.Forms;
using WindowsFormsApp1.GUI.MainUserControls;

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

        //method to get all orders for a specific customer
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, Status FROM Orders WHERE CustomerID = @CustomerID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                            Status = reader.GetString(reader.GetOrdinal("Status"))
                        };
                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving orders: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return orders;
        }


        // Method to get total amounts of parts and vehicles over time ( this methode supports for the admin panel charts of OrderSummaryChart )
        public List<OrderSummary> GetOrderSummaryByDate()
        {
            List<OrderSummary> orderSummaries = new List<OrderSummary>();
            string query = @"
            SELECT 
                OrderDate,
                SUM(CASE WHEN PartID IS NOT NULL THEN Quantity * Price ELSE 0 END) AS TotalPartsAmount,
                SUM(CASE WHEN CarID IS NOT NULL THEN Quantity * Price ELSE 0 END) AS TotalVehiclesAmount
            FROM 
                OrderDetails
            INNER JOIN 
                Orders ON OrderDetails.OrderID = Orders.OrderID
            GROUP BY 
                OrderDate
            ORDER BY 
                OrderDate";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderSummary summary = new OrderSummary
                        {
                            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            TotalPartsAmount = reader.GetDecimal(reader.GetOrdinal("TotalPartsAmount")),
                            TotalVehiclesAmount = reader.GetDecimal(reader.GetOrdinal("TotalVehiclesAmount"))
                        };
                        orderSummaries.Add(summary);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving order summaries: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return orderSummaries;
        }

        // Method to get total amounts of parts and vehicles over time ( this methode supports for the admin panel charts : Profile )
        public List<OrderSummary> GetEarningsByDate()
        {
            List<OrderSummary> earningsSummaries = new List<OrderSummary>();
            string query = @"
            SELECT 
                OrderDate,
                SUM(CASE WHEN PartID IS NOT NULL THEN Quantity * Price ELSE 0 END) AS TotalPartsEarnings,
                SUM(CASE WHEN CarID IS NOT NULL THEN Quantity * Price ELSE 0 END) AS TotalVehiclesEarnings
            FROM 
                OrderDetails
            INNER JOIN 
                Orders ON OrderDetails.OrderID = Orders.OrderID
            GROUP BY 
                OrderDate
            ORDER BY 
                OrderDate";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderSummary summary = new OrderSummary
                        {
                            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            TotalPartsAmount = reader.GetDecimal(reader.GetOrdinal("TotalPartsEarnings")),
                            TotalVehiclesAmount = reader.GetDecimal(reader.GetOrdinal("TotalVehiclesEarnings"))
                        };
                        earningsSummaries.Add(summary);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving earnings summaries: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return earningsSummaries;
        }


        // Method to get total items by brand and product type
        public List<ItemSummaryByBrand> GetTotalItemsByBrand()
        {
            List<ItemSummaryByBrand> itemSummaries = new List<ItemSummaryByBrand>();

            string partsQuery = @"
        SELECT 
            b.BrandName,
            SUM(od.Quantity) AS TotalParts
        FROM 
            OrderDetails od
        INNER JOIN 
            CarParts cp ON od.PartID = cp.PartID
        INNER JOIN 
            Brands b ON cp.BrandID = b.BrandID
        GROUP BY 
            b.BrandName";

            string vehiclesQuery = @"
        SELECT 
            b.BrandName,
            SUM(od.Quantity) AS TotalVehicles
        FROM 
            OrderDetails od
        INNER JOIN 
            Cars c ON od.CarID = c.CarID
        INNER JOIN 
            Brands b ON c.BrandID = b.BrandID
        GROUP BY 
            b.BrandName";

            try
            {
                dbconnect.OpenConnection();

                // Get parts summary
                SqlCommand cmdParts = new SqlCommand(partsQuery, dbconnect.GetConnection());
                using (SqlDataReader reader = cmdParts.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemSummaryByBrand summary = new ItemSummaryByBrand
                        {
                            BrandName = reader.GetString(reader.GetOrdinal("BrandName")),
                            TotalParts = reader.GetInt32(reader.GetOrdinal("TotalParts")),
                            TotalVehicles = 0 // Initialize to 0; will be updated later
                        };
                        itemSummaries.Add(summary);
                    }
                }

                // Get vehicles summary
                SqlCommand cmdVehicles = new SqlCommand(vehiclesQuery, dbconnect.GetConnection());
                using (SqlDataReader reader = cmdVehicles.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string brandName = reader.GetString(reader.GetOrdinal("BrandName"));
                        int totalVehicles = reader.GetInt32(reader.GetOrdinal("TotalVehicles"));

                        // Find the matching brand and update the total vehicles
                        var summary = itemSummaries.FirstOrDefault(s => s.BrandName == brandName);
                        if (summary != null)
                        {
                            summary.TotalVehicles = totalVehicles;
                        }
                        else
                        {
                            // If the brand wasn't found in parts, add a new entry
                            itemSummaries.Add(new ItemSummaryByBrand
                            {
                                BrandName = brandName,
                                TotalParts = 0,
                                TotalVehicles = totalVehicles
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving item summaries by brand: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return itemSummaries;
        }

        //Fetch Total Earnings
        public decimal GetTotalEarnings()
        {
            decimal totalEarnings = 0;

            string query = "SELECT SUM(TotalAmount) FROM Orders WHERE Status = 'Completed'";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                totalEarnings = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving total earnings: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return totalEarnings;
        }
    }

    // Get item summery by brand helper class 
    public class ItemSummaryByBrand
    {
        public string BrandName { get; set; }
        public int TotalParts { get; set; }
        public int TotalVehicles { get; set; }
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

    // create the helper class for the application
    public class OrderSummary
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPartsAmount { get; set; }
        public decimal TotalVehiclesAmount { get; set; }
    }
}
