using System;
using System.Windows.Forms;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.MainUserControls;
using static WindowsFormsApp1.Funtions.Cars;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1
{
    public partial class SingleCar : Form
    {
        private int userId;
        private int customerId;
        private Cart cart;

        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)

        public SingleCar()
        {
            InitializeComponent();
            btnaddtolist.Click += btnaddtolist_Click;

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

        private void btnaddtolist_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerId > -1) // Ensure customer is logged in
                {
                    int quantity = 1; // You can modify this as needed

                    // Add the item to the cart using the CarID
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


        private void btnbackhome_Click(object sender, EventArgs e)
        {
            //Home homwpage = new Home();
            this.Hide();
            //homwpage.Show();
        }

        private void SingleCar_Load(object sender, EventArgs e)
        {

        }
    }
}
