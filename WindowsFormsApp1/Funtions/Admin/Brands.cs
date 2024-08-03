using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Funtions.Admin
{
    public class Brands
    {
        private dbconnect dbconnect;

        public Brands()
        {
            dbconnect = new dbconnect();
        }

        // Method to retrieve Brand ID and Name
        public Dictionary<int, string> GetAllBrands()
        {
            Dictionary<int, string> brands = new Dictionary<int, string>();

            string query = "SELECT BrandID, BrandName FROM Brands";

            try
            {
                dbconnect.OpenConnection();

                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int brandId = reader.GetInt32(0);
                        string brandName = reader.GetString(1);
                        brands.Add(brandId, brandName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving brands: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return brands;
        }


        // Insert a new Brand
        public bool InsertBrand(string brandName, string description, string image)
        {
            string query = "INSERT INTO Brands (BrandName, Description, Image) VALUES (@BrandName, @Description, @Image)";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@BrandName", brandName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting brand: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Update an existing Brand
        public bool UpdateBrand(int brandId, string brandName, string description, string image)
        {
            string query = "UPDATE Brands SET BrandName = @BrandName, Description = @Description, Image = @Image WHERE BrandID = @BrandID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@BrandID", brandId);
                cmd.Parameters.AddWithValue("@BrandName", brandName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Image", image);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating brand: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Delete a Brand
        public bool DeleteBrand(int brandId)
        {
            string query = "DELETE FROM Brands WHERE BrandID = @BrandID";

            try
            {
                dbconnect.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbconnect.GetConnection());

                cmd.Parameters.AddWithValue("@BrandID", brandId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting brand: " + ex.Message);
                return false;
            }
            finally
            {
                dbconnect.CloseConnection();
            }
        }


        // Search for Brands by BrandID or BrandName
        public List<Brand> SearchBrands(string keyword)
        {
            List<Brand> brands = new List<Brand>();
            string query = "SELECT BrandID, BrandName, Description, Image FROM Brands WHERE BrandID = @Keyword OR BrandName LIKE @KeywordLike";

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
                        Brand brand = new Brand
                        {
                            BrandID = reader.GetInt32(0),
                            BrandName = reader.GetString(1),
                            Description = reader.GetString(2),
                            Image = reader.GetString(3)
                        };
                        brands.Add(brand);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching brands: " + ex.Message);
            }
            finally
            {
                dbconnect.CloseConnection();
            }

            return brands;
        }


    }

    // Brand class to hold the data
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
