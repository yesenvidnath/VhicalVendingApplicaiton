using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.MainUserControls;
using static WindowsFormsApp1.Funtions.HomeFuntions;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1.GUI.SingleForms
{
    public partial class SingleParts : Form
    {
        private int userId;
        private int customerId;
        private Cart cart;
        public int PartID { get; set; }


        public SingleParts()
        {
            InitializeComponent();
            this.btnaddtolist.Click += btnaddtolist_Click;

            // Get the logged in user ID
            userId = SessionManager.LoggedInUserId;

            if (userId > 0)
            {
                // Get the customer ID based on the logged-in user ID
                Customers customers = new Customers();
                customerId = customers.GetCustomerIdByUserId(userId);
            }

            // Initialize Cart
            cart = new Cart();

            // Load the Nav Bar
            NavBar navBar = new NavBar();
            navBar.Dock = DockStyle.Top;
            this.Controls.Add(navBar);

        }

        public void SetPartDetails(string brandName, string partName, decimal price, int quantityAvailable, string description, string imagePath)
        {
            lblbrandname.Text = brandName;
            lblname.Text = partName;
            lblprice.Text = $"${price}";
            lblquntitty.Text = quantityAvailable.ToString();
            lblcarpartdiscription.Text = description;
            imgcarpart.ImageLocation = imagePath; 
        }

        private void btnaddtolist_Click(object sender, EventArgs e)
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

        private void btnbackhome_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void lblmodelname_Click(object sender, EventArgs e)
        {
        }

    }
}
