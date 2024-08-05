﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.Funtions.Admin;
using static WindowsFormsApp1.Funtions.Cars;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1.MainUserControls
{
    public partial class VehicleCard : UserControl
    {

        private int customerId;
        private Cart cart;

        public int CarId { get; set; } // Property to hold the CarID
        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)

        public VehicleCard()
        {
            InitializeComponent();
            btnseemore.Click += Btnseemore_Click;
            btnaddlist.Click += Btnaddlist_Click;

            // Get the logged in customer ID 
            cart = new Cart();
            customerId = SessionManager.LoggedInUserId;
        }

        //Set the see more button event once it's clicked
        private void Btnseemore_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"See More button clicked for CarID: {CarID}");

            HomeFuntions homeFunctions = new HomeFuntions();
            CarDetails carDetails = homeFunctions.GetCarDetails(CarID);

            if (carDetails != null)
            {
                SingleCar singleCarForm = new SingleCar();
                singleCarForm.SetCarDetails(carDetails);
                singleCarForm.Show();
            }
            else
            {
                Console.WriteLine($"No car details found for CarID: {CarID}");
                MessageBox.Show("Car details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event handler for adding the item to the cart
        private void Btnaddlist_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming a default quantity of 1 when adding to the cart
                int quantity = 1;

                // Add to cart using the CarID and CustomerID
                cart.AddToCart(customerId, CarID, quantity);

                // Display success message
                MessageBox.Show("Item added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur
                MessageBox.Show($"Failed to add item to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SetCarInfo(string carName, string brand, int year, decimal price, string imagePath)
        {
            lblcarname.Text = carName;
            lblbrand.Text = brand;
            lblyear.Text = year.ToString();
            lblprice.Text = $"${price}";
            imgbox.ImageLocation = imagePath;
        }

        public void SetCarInfoByID(int carID, string model, string brand, int year, decimal price, string imagePath)
        {
            CarID = carID;
            lblcarname.Text = model;
            lblbrand.Text = brand;
            lblyear.Text = year.ToString();
            lblprice.Text = $"${price}";
            imgbox.ImageLocation = imagePath;
        }

        private void VehicleCard_Load(object sender, EventArgs e)
        {

        }
        private void imgbox_Click(object sender, EventArgs e)
        {

        }
        private void btnaddlist_Click(object sender, EventArgs e)
        {



        }
        private void btnseemore_Click(object sender, EventArgs e)
        {
            
        }
        private void btnorder_Click(object sender, EventArgs e)
        {
            
        }
        private void imgbox_Click_1(object sender, EventArgs e)
        {

        }
    }
}
