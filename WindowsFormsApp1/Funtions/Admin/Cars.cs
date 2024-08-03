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


        // Insert a New Car
        public bool InsertCar(int brandId, string model, string make, int year, decimal price, int quantityAvailable, string image)
        {
            string query = "INSERT INTO Cars (BrandID, Model, Make, Year, Price, QuantityAvailable, Image) VALUES (@BrandID, @Model, @Make, @Year, @Price, @QuantityAvailable, @Image)";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@BrandID", brandId);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Make", make);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting car: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }

        }


        //Update an existing car 
        public bool UpdateCar(int carId, int brandId, string model, string make, int year, decimal price, int quantityAvailable, string image)
        {
            string query = "UPDATE Cars SET BrandID = @BrandID, Model = @Model, Make = @Make, Year = @Year, Price = @Price, QuantityAvailable = @QuantityAvailable, Image = @Image WHERE CarID = @CarID";

            try
            {
                dbconnect.OpenConnection();

                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@CarID", carId);
                cmd.Parameters.AddWithValue("@BrandID", brandId);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Make", make);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating car: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Delete 
        public bool DeleteCar(int carId)
        {
            string query = "DELETE FROM Cars WHERE CarID = @CarID";

            try
            {
                dbconnect.OpenConnection();

                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@CarID", carId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting car: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }

        }


        // Search for a car by ID 
        public List<Car> SearchCars(string model, string make, int year)
        {
            List<Car> cars = new List<Car>();
            string searchQuery = "SELECT * FROM Cars WHERE CarModel = @Model AND CarMake = @Make AND CarYear = @Year";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(searchQuery, dbconnect.GetConnection());
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Make", make);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new Car
                    {
                        CarID = reader.GetInt32(0),
                        Model = reader.GetString(1),
                        Make = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        // Map other properties
                    };
                    cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching cars: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return cars;
        }
    }


    // Car class to hold the data
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string Image { get; set; }
    }
}
