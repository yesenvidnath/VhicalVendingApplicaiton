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

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {

        private HomeFuntions homeFunctions;

        public Home()
        {
            InitializeComponent();
            homeFunctions = new HomeFuntions(); // Initialize the instance

            //Load Vehicles
            LoadVehicleCards();
            //Load Brands
            LoadBrands();

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
                flpbrands.Controls.Add(brand);
            }
        }

        // Load Vehicles
        private void LoadVehicleCards()
        {
            List<VehicleCard> vehicleCards = homeFunctions.GetVehicleCards(); // Use the instance to call GetVehicleCards
            foreach (VehicleCard card in vehicleCards)
            {
                flpproducts.Controls.Add(card); // Assuming flpProducts is your FlowLayoutPanel
            }
        }

    }
}
