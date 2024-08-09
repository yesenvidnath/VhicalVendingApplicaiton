using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using WindowsFormsApp1.MainUserControls;
using WindowsFormsApp1.Funtions; // insert the funtions 
using WindowsFormsApp1;
using System.IO;
using static WindowsFormsApp1.Funtions.Cars;
using WindowsFormsApp1.GUI.MainUserControls;

namespace WindowsFormsApp1.Funtions
{
    public class HomeFuntions
    {
        private dbconnect dbconnect;

        public HomeFuntions()
        {
            this.dbconnect = new dbconnect();
        }

        //Car List
        public List<VehicleCard> GetVehicleCardsByBrand(String brandName = null)
        {
            List<VehicleCard> cards = new List<VehicleCard>();
            this.dbconnect.OpenConnection();

            // Updated SQL query with explicit column references and aliases
            string query = "SELECT c.Model, c.Make, c.Year, c.Price, c.Image, b.BrandName " +
                   "FROM Cars c JOIN Brands b ON c.BrandID = b.BrandID";


            // Load the Cars in to the Car listing Grid Regadless of brand been selected
            if (!string.IsNullOrEmpty(brandName))
            {
                query += " WHERE b.BrandName = @BrandName";
            }

            SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

            if (!string.IsNullOrEmpty(brandName))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
            }

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string model = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        string make = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        int year = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        decimal price = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        string image = reader.IsDBNull(4) ? "default_path.jpg" : reader.GetString(4);
                        string brand = reader.IsDBNull(5) ? "" : reader.GetString(5);

                        VehicleCard card = new VehicleCard();
                        card.SetCarInfo(model, brand, year, price, image);
                        cards.Add(card);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                this.dbconnect.CloseConnection();
            }

            return cards;
        }


        // Brand List
        public List<BrandsList> GetBrands()
        {
            List<BrandsList> brands = new List<BrandsList>();
            dbconnect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT BrandName, Image FROM Brands", dbconnect.GetConnection());

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string brandName = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        string image = reader.IsDBNull(1) ? "./Assets/Img/logo-defult.png" : "Assets/Img/" + reader.GetString(1);

                        BrandsList brandControl = new BrandsList();
                        brandControl.SetBrandInfo(brandName, image);
                        brands.Add(brandControl);
                    }
                }
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return brands;
        }

        public List<VehicleCard> GetVehicleCardsWithCarIDByBrand(string brandName = null)
        {
            List<VehicleCard> cards = new List<VehicleCard>();
            dbconnect.OpenConnection();

            // Updated SQL query with explicit column references and aliases, including CarID
            string query = "SELECT c.CarID, c.Model, c.Make, c.Year, c.Price, c.Image, b.BrandName " +
                           "FROM Cars c JOIN Brands b ON c.BrandID = b.BrandID";

            // Load the Cars into the Car listing Grid regardless of brand being selected
            if (!string.IsNullOrEmpty(brandName))
            {
                query += " WHERE b.BrandName = @BrandName";
            }

            SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

            if (!string.IsNullOrEmpty(brandName))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
            }

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int carID = reader.GetInt32(0);
                        string model = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        string make = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        int year = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        decimal price = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                        string image = reader.IsDBNull(5) ? "default_path.jpg" : reader.GetString(5);
                        string brand = reader.IsDBNull(6) ? "" : reader.GetString(6);

                        VehicleCard card = new VehicleCard();
                        card.SetCarInfoByID(carID, model, brand, year, price, image);
                        cards.Add(card);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return cards;
        }


        public List<PartsCard> GetPartsCardsByBrand(string brandName = null)
        {
            List<PartsCard> partsCards = new List<PartsCard>();
            string query = "SELECT PartID, PartName, Description, Price, QuantityAvailable, Image, BrandID FROM CarParts ";

            if (!string.IsNullOrEmpty(brandName))
            {
                query += "JOIN Brands ON CarParts.BrandID = Brands.BrandID WHERE Brands.BrandName = @BrandName";
            }

            SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());
            if (!string.IsNullOrEmpty(brandName))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
            }

            dbconnect.OpenConnection();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        PartsCard card = new PartsCard();
                        string partName = reader["PartName"].ToString();
                        decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                        int quantityAvailable = reader.GetInt32(reader.GetOrdinal("QuantityAvailable"));
                        string imagePath = reader["Image"].ToString();

                        Console.WriteLine($"Retrieved - PartName: {partName}, Price: {price}, Quantity: {quantityAvailable}, ImagePath: {imagePath}");

                        card.SetPartInfo(partName, price, quantityAvailable, imagePath);
                        partsCards.Add(card);
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"Error casting data: {ex.Message}");
                    }
                }
            }
            dbconnect.CloseConnection();
            return partsCards;
        }


        public List<VehicleCard> GetVehicleAndPartsCardsByBrand(string brandName = null)
        {
            var vehicleCards = GetVehicleCardsByBrand(brandName);
            var partsCards = GetPartsCardsByBrand(brandName);
            // Convert PartsCards to VehicleCards or use a common interface/base class
            return vehicleCards.Concat(partsCards.Cast<VehicleCard>()).ToList();
        }

        public List<object> GetVehiclesAndPartsByBrand(string brandName = null)
        {
            var vehicleCards = GetVehicleCardsByBrand(brandName);
            var partsCards = GetPartsCardsByBrand(brandName);

            // Combine both lists into a single list of objects since they may not share a common base class or interface
            List<object> combined = new List<object>(vehicleCards.Cast<object>().Concat(partsCards.Cast<object>()));
            return combined;
        }

        //Get car details methode 
        public CarDetails GetCarDetails(int carId)
        {
            Cars cars = new Cars(); 
            return cars.GetCarDetails(carId);
        }
    }
}
