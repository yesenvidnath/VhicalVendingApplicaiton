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
using static WindowsFormsApp1.Funtions.Cars;

namespace WindowsFormsApp1
{
    public partial class SingleCar : Form
    {
        private int userId;

        public SingleCar()
        {
            InitializeComponent();

            // Load the Nav Bar 
            NavBar navBar = new NavBar();
            navBar.Dock = DockStyle.Top;
            this.Controls.Add(navBar);
            navBar.SetLoggedInUser(userId); // Set the logged-in user's name on the NavBar 
        }

        public void SetCarDetails(CarDetails carDetails)
        {
            lblbrandname.Text = carDetails.BrandName;
            lblmodelname.Text = carDetails.Model;
            lblmake.Text = carDetails.Make;
            lblyear.Text = carDetails.Year.ToString();
            lblprice.Text = $"${carDetails.Price}";
            lblquntitty.Text = carDetails.QuantityAvailable.ToString();
            imgvehicle.ImageLocation = carDetails.Image;
        }

        private void SingleCar_Load(object sender, EventArgs e)
        {

        }

        private void btnbackhome_Click(object sender, EventArgs e)
        {
            //Home homwpage = new Home();
            this.Hide();
            //homwpage.Show();
        }
    }
}
