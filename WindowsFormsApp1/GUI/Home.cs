using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.MainUserControls;
using WindowsFormsApp1;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {

        private HomeFuntions homeFunctions;
        private Label noCarsLabel;
        private int userId;

        public Home(int userId = -1)
        {
            InitializeComponent();
            homeFunctions = new HomeFuntions(); // Initialize the instance

            if (userId != -1)
            {
                SessionManager.LoggedInUserId = userId;
            }
            // Load the Nav Bar 
            NavBar navBar = new NavBar();
            navBar.Dock = DockStyle.Top;
            this.Controls.Add(navBar);

            //Load Brands
            LoadBrands();
            LoadVehicleCards();

            if (SessionManager.LoggedInUserId != -1)
            {
                Console.WriteLine("The user ID was passed to SessionManager and recognized by Home form.");
            }


        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void flpproducts_Paint(object sender, PaintEventArgs e)
        {

        }

        //Load Brands 
        private void LoadBrands()
        {
            List<BrandsList> brandControls = homeFunctions.GetBrands();
            foreach (BrandsList brand in brandControls)
            {
                brand.BrandSelected += Brand_BrandSelected;
                flpbrands.Controls.Add(brand);
            }
        }

        // Load Vehicles
        private void Brand_BrandSelected(object sender, string brandName)
        {
            LoadVehicleCards(brandName);
        }

        private void LoadVehicleCards(string brandName = null) 
        {
            HomeFuntions homeFunctions = new HomeFuntions();

            List<VehicleCard> vehicleCards = homeFunctions.GetVehicleCardsByBrand(brandName);
            flpproducts.Controls.Clear();


            if (string.IsNullOrEmpty(brandName))
            {
                vehicleCards = homeFunctions.GetVehicleCardsWithCarIDByBrand();
            }
            else
            {
                vehicleCards = homeFunctions.GetVehicleCardsWithCarIDByBrand(brandName);
            }


            // condition to display the cars regadless of the cound of items within the area
            if (vehicleCards.Count > 0)
            {
                foreach (VehicleCard card in vehicleCards)
                {
                    flpproducts.Controls.Add(card);
                }
            }
            else
            {
                
                MessageBox.Show("No Cars Avilable", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void flpproducts_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void flpbrands_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
