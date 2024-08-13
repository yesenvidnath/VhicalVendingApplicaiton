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
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.GUI.SingleForms;
using WindowsFormsApp1.MainUserControls;
using static WindowsFormsApp1.Funtions.HomeFuntions;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1.GUI.MainUserControls
{
    public partial class PartsCard : UserControl
    {
        private int customerId;
        private Cart cart;
        public int PartID { get; set; } // Property to hold the PartID
        public decimal Price { get; set; } // Add this to store the price of the vehicle
        public PartsCard()
        {
            InitializeComponent();
            // Initialize Cart and get customer ID
            cart = new Cart();
            customerId = SessionManager.LoggedInUserId;
            this.btnseemore.Click += btnseemore_Click;
            this.btnaddlist.Click += btnaddlist_Click;
            btnorder.Click -= btnorder_Click; // Remove any previous attachments
            btnorder.Click += btnorder_Click;  // Attach the event handler

        }

        // controls to display these properties
        public void SetPartInfo(string partName, decimal price, int quantityAvailable, string imagePath)
        {
            try
            {
                lblPartName.Text = partName;
                lblPrice.Text = $"${price}";
                lblQuantityAvailable.Text = quantityAvailable.ToString();
                imgPart.ImageLocation = imagePath;
                this.Price = price;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"An error occurred while setting part info: {ex.Message}");
            }
        }

        // See more  button
        private void btnseemore_Click(object sender, EventArgs e)
        {
            if (PartID > 0)
            {
                HomeFuntions homeFunctions = new HomeFuntions();
                var partDetails = homeFunctions.GetPartDetails(PartID);

                if (partDetails != null)
                {
                    SingleParts singlePartsForm = new SingleParts();
                    singlePartsForm.PartID = PartID;
                    singlePartsForm.SetPartDetails(
                        partDetails.BrandName,
                        partDetails.PartName,
                        partDetails.Price,
                        partDetails.QuantityAvailable,
                        partDetails.Description,
                        partDetails.ImagePath
                    );
                    singlePartsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Part details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnaddlist_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerId > 0) 
                {
                    int quantity = 1; 

                    // Add the part to the cart, using PartID instead of CarID
                    cart.AddToCart(customerId, this.PartID, quantity);

                    // Show confirmation message
                    MessageBox.Show("Part added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the cart item count in the navigation bar
                    if (this.ParentForm != null && this.ParentForm.Controls["navbar"] is NavBar navBar)
                    {
                        navBar.UpdateCartItemCount();
                    }
                }
                else
                {
                    MessageBox.Show("You must be logged in to add parts to the cart.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the part to the cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to order this part?", "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            PartID = this.PartID,  // Assuming PartID is set for the part
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

        private void btnaddlist_Click_1(object sender, EventArgs e)
        {

        }
        private void btnseemore_Click_1(object sender, EventArgs e)
        {
        }
        private void btnorder_Click_1(object sender, EventArgs e)
        {

        }
    }
}
