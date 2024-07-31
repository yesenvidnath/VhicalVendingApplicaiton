using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace WindowsFormsApp1.Funtions
{
    public class Cars
    {
        private dbconnect dbconnect;

        public Cars()
        {
            dbconnect = new dbconnect();
        }

        // Create Plublic class for getting car details
        public class CarDetails
        {
            public string BrandName { get; set; }
            public string Model { get; set; }
            public string Make { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
            public int QuantityAvailable { get; set; }
            public string Image { get; set; }
        }

        public CarDetails GetCarDetails(int carId)
        {
            CarDetails carDetails = null;

            try
            {
                dbconnect.OpenConnection();
                string query = "SELECT Cars.Model, Brands.BrandName, Cars.Make, Cars.Year, Cars.Price, Cars.QuantityAvailable, Cars.Image " +
                               "FROM Cars " +
                               "JOIN Brands ON Cars.BrandID = Brands.BrandID " +
                               "WHERE Cars.CarID = @CarID";
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@CarID", carId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        carDetails = new CarDetails
                        {
                            Model = reader["Model"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            Make = reader["Make"].ToString(),
                            Year = (int)reader["Year"],
                            Price = (decimal)reader["Price"],
                            QuantityAvailable = (int)reader["QuantityAvailable"],
                            Image = reader["Image"].ToString()
                        };

                        Console.WriteLine("Car details found: " + carDetails.Model);
                    }
                    else
                    {
                        Console.WriteLine("No car details found for CarID: " + carId);
                    }
                }

            }catch(SqlException ex)
            {
                Console.WriteLine("SQL ERROR " + ex.Message);

            }catch (Exception ex)
            {
                Console.WriteLine("General Error " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return carDetails;
        }

    }
}
