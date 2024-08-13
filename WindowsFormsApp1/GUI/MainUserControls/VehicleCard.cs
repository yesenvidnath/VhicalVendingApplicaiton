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
using WindowsFormsApp1.Funtions.Admin;
using WindowsFormsApp1.Funtions.Customer;
using static WindowsFormsApp1.Funtions.Cars;
using static WindowsFormsApp1.Funtions.HomeFuntions;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1.MainUserControls
{
    public partial class VehicleCard : UserControl
    {

        private int customerId;
        private Cart cart;

        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)
        public decimal Price { get; set; } // Add this to store the price of the vehicle


        public VehicleCard()
        {
            InitializeComponent();
            btnseemore.Click += Btnseemore_Click;
            btnaddlist.Click += Btnaddlist_Click;
            btnorder.Click -= btnorder_Click; // Remove any previous attachments
            btnorder.Click += btnorder_Click;  // Attach the event handler

            // Get the logged in customer ID 
            cart = new Cart();
            customerId = SessionManager.LoggedInUserId;
        }

        public void SetCarInfo(string carName, string brand, int year, decimal price, string imagePath)
        {
            lblcarname.Text = carName;
            lblbrand.Text = brand;
            lblyear.Text = year.ToString();
            lblprice.Text = $"${price}";
            imgbox.ImageLocation = imagePath;
            this.Price = price;
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

        // Set the "See More" button event once it's clicked
        private void Btnseemore_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"See More button clicked for CarID: {CarID}");

            HomeFuntions homeFunctions = new HomeFuntions();
            CarDetails carDetails = homeFunctions.GetCarDetails(CarID);

            if (carDetails != null)
            {
                SingleCar singleCarForm = new SingleCar();

                // Set the CarID before showing the form
                singleCarForm.CarID = CarID;
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
                if (customerId > 0) // Ensure customer is logged in
                {
                    int quantity = 1; // You can modify this as needed

                    // Add the item to the cart
                    cart.AddToCart(customerId, CarID, quantity);

                    // Show confirmation message
                    MessageBox.Show("Item added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the cart item count in the navigation bar
                    if (this.ParentForm != null && this.ParentForm.Controls["navbar"] is NavBar navBar)
                    {
                        navBar.UpdateCartItemCount();
                    }
                }
                else
                {
                    MessageBox.Show("You must be logged in to add items to the cart.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item to the cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to order this vehicle?", "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int userId = SessionManager.LoggedInUserId;
                int customerId = new Customers().GetCustomerIdByUserId(userId);

                if (customerId > 0)
                {
                    Orders orders = new Orders();
                    List<OrderDetail> orderDetails = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            CarID = this.CarID,  // Assuming CarID is set for the vehicle
                            Quantity = 1, // Default quantity to 1 or allow the user to choose
                            Price = this.Price // Use the Price property
                        }
                    };

                    int orderId = orders.InsertOrder(customerId, orderDetails);

                    if (orderId > 0)
                    {
                        MessageBox.Show("Your order has been placed successfully!", "Order Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while placing your order. Please try again.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must be logged in to place an order.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void imgbox_Click_1(object sender, EventArgs e)
        {

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
    }
}
