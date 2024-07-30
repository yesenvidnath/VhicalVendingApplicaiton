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
using WindowsFormsApp1;
using System.IO;

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


        /*
        //Car List
        public List<VehicleCard> GetVehicleCards()
        {
            List<VehicleCard> cards = new List<VehicleCard>();
            this.dbconnect.OpenConnection();
            // Updated SQL query with explicit column references and aliases
            SqlCommand cmd = new SqlCommand(
                "SELECT c.Model, b.BrandName, c.Year, c.Price, c.Image FROM Cars c " +
                "JOIN Brands b ON c.BrandID = b.BrandID", this.dbconnect.GetConnection());

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string model = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        string brand = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        int year = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        decimal price = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string relativePath = @"Assets\Img\";
                        string defaultImage = "vehical-default.png";
                        string imagePath = reader.IsDBNull(4) ? Path.Combine(basePath, relativePath, defaultImage) : Path.Combine(basePath, relativePath, reader.GetString(4));

                        VehicleCard card = new VehicleCard();
                        card.SetCarInfo(model, brand, year, price, imagePath);
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
        */

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
    }
}
