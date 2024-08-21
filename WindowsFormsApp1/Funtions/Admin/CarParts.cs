using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Funtions.Admin;

namespace WindowsFormsApp1.Funtions
{
    public class CarParts
    {
        private dbconnect dbconnect;


        public CarParts()
        {
            dbconnect = new dbconnect();
        }

        // Insert a new Car Part
        public bool InsertCarPart(string brandName, string carModel, string carMake, int carYear, string partName, string description, decimal price, int quantityAvailable, string image)
        {
            Brands brands = new Brands();
            var brandList = brands.SearchBrands(brandName);

            if (brandList.Count == 0)
            {
                Console.WriteLine("Brand not found.");
                return false;
            }

            int brandId = brandList[0].BrandID;

            Cars cars = new Cars();
            var carList = cars.SearchCars(carModel, carMake, carYear);

            if (carList.Count == 0)
            {
                Console.WriteLine("Car not found.");
                return false;
            }

            int carId = carList[0].CarID;

            string query = "INSERT INTO CarParts (BrandID, CarID, PartName, Description, Price, QuantityAvailable, Image) " +
                           "VALUES (@BrandID, @CarID, @PartName, @Description, @Price, @QuantityAvailable, @Image)";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@BrandID", brandId);
                cmd.Parameters.AddWithValue("@CarID", carId);
                cmd.Parameters.AddWithValue("@PartName", partName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting car part: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }



        // Update an existing Car Part
        public bool UpdateCarPart(int partId, string brandName, string carModel, string carMake, int carYear, string partName, string description, decimal price, int quantityAvailable, string image)
        {
            Brands brands = new Brands();
            var brandList = brands.SearchBrands(brandName);

            if (brandList.Count == 0)
            {
                Console.WriteLine("Brand not found.");
                return false;
            }

            int brandId = brandList[0].BrandID;

            Cars cars = new Cars();
            var carList = cars.SearchCars(carModel, carMake, carYear);

            if (carList.Count == 0)
            {
                Console.WriteLine("Car not found.");
                return false;
            }

            int carId = carList[0].CarID;

            string query = "UPDATE CarParts SET BrandID = @BrandID, CarID = @CarID, PartName = @PartName, Description = @Description, " +
                           "Price = @Price, QuantityAvailable = @QuantityAvailable, Image = @Image WHERE PartID = @PartID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@PartID", partId);
                cmd.Parameters.AddWithValue("@BrandID", brandId);
                cmd.Parameters.AddWithValue("@CarID", carId);
                cmd.Parameters.AddWithValue("@PartName", partName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating car part: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Delete a Car Part
        public bool DeleteCarPart(int partId)
        {
            string query = "DELETE FROM CarParts WHERE PartID = @PartID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@PartID", partId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting car part: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Search for Car Parts by PartID or PartName
        public List<CarPart> SearchCarParts(string keyword)
        {
            List<CarPart> carParts = new List<CarPart>();
            string query = "SELECT PartID, BrandID, CarID, PartName, Description, Price, QuantityAvailable, Image FROM CarParts " +
                           "WHERE PartID = @Keyword OR PartName LIKE @KeywordLike";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@Keyword", keyword);
                cmd.Parameters.AddWithValue("@KeywordLike", "%" + keyword + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPart carPart = new CarPart
                        {
                            PartID = reader.GetInt32(0),
                            BrandID = reader.GetInt32(1),
                            CarID = reader.GetInt32(2),
                            PartName = reader.GetString(3),
                            Description = reader.GetString(4),
                            Price = reader.GetDecimal(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Image = reader.GetString(7)
                        };
                        carParts.Add(carPart);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching car parts: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return carParts;
        }

        // Fetch Total Parts
        public int GetTotalParts()
        {
            int totalParts = 0;

            string query = "SELECT COUNT(*) FROM CarParts";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
                totalParts = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving total parts: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return totalParts;
        }

    }

    // CarPart class to hold the data
    public class CarPart
    {
        public int PartID { get; set; }
        public int BrandID { get; set; }
        public int CarID { get; set; }
        public string PartName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string Image { get; set; }
    }
}
