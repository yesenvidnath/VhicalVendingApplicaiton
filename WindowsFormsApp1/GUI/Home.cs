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
using WindowsFormsApp1.GUI.MainUserControls;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        private HomeFuntions homeFunctions;
        private Label noCarsLabel;
        private int userId;
        private string currentBrandName; // Holds the current selected brand name

        public Home(int userId = -1)
        {
            InitializeComponent();
            // Initialize the instance
            homeFunctions = new HomeFuntions(); 

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

        // Configuring the filter buttons, 
        private void btnfiltercars_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Filter Cars clicked.");
            DisplayVehicles();
        }

        private void btncarparts_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Car Parts clicked.");
            DisplayParts();
        }

        private void btnall_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Display All clicked.");
            DisplayAll();
        }

        private void DisplayVehicles(string brandName = null)
        {
            var cards = homeFunctions.GetVehicleCardsByBrand(brandName);
            flpproducts.Controls.Clear();
            foreach (var card in cards)
            {
                flpproducts.Controls.Add(card);
            }
        }

        private void DisplayParts(string brandName = null)
        {
            var cards = homeFunctions.GetPartsCardsByBrand(brandName);
            flpproducts.Controls.Clear();
            foreach (var card in cards)
            {
                flpproducts.Controls.Add(card);
            }
        }

        private void DisplayAll(string brandName = null)
        {
            var combinedCards = homeFunctions.GetVehiclesAndPartsByBrand(brandName);
            flpproducts.Controls.Clear();

            foreach (var card in combinedCards)
            {
                if (card is VehicleCard vehicleCard)
                {
                    flpproducts.Controls.Add(vehicleCard);
                }
                else if (card is PartsCard partsCard)
                {
                    flpproducts.Controls.Add(partsCard);
                }
            }
        }

        private void flpproducts_Paint_1(object sender, PaintEventArgs e)
        {
        }
        private void flpbrands_Paint(object sender, PaintEventArgs e)
        {

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

    }
}
