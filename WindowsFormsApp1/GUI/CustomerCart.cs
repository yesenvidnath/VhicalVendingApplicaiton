using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.MainUserControls.NavBar;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.GUI.MainUserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Data.SqlClient;
using WindowsFormsApp1.MainUserControls;

namespace WindowsFormsApp1.GUI
{
    public partial class CustomerCart : Form
    {
        private int userId;
        private int customerId;
        private Cart cart;

        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)


        public CustomerCart()
        {
            InitializeComponent();
            LoadCartItems();

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

        private void CustomerCart_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            Cart cart = new Cart();
            int userId = SessionManager.LoggedInUserId;

            // Fetch the cart items using the UserID
            List<CartItem> cartItems = cart.GetCartItems(userId);

            flpcartitems.Controls.Clear();
            foreach (CartItem item in cartItems)
            {
                CartItems cartItemControl = new CartItems();
                cartItemControl.ItemName = item.ItemName;
                cartItemControl.Price = $"${item.Price}";
                cartItemControl.Quantity = item.Quantity.ToString();
                cartItemControl.ImagePath = item.ImagePath;

                cartItemControl.RemoveButton.Click += (s, e) => RemoveItemFromCart(item.CartItemID);

                flpcartitems.Controls.Add(cartItemControl);
            }

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveItemFromCart(int cartItemId)
        {
            Cart cart = new Cart();
            cart.RemoveFromCart(cartItemId);

            // Refresh the cart items after removal
            LoadCartItems();

            // Update the cart item count in the navbar
            if (Application.OpenForms["MainForm"] is Home mainForm)
            {
                if (mainForm.Controls["navbar"] is NavBar navBar)
                {
                    navBar.UpdateCartItemCount();
                }
            }
        }




        private void btnproceedtocheckout_Click(object sender, EventArgs e)
        {

        }
    }
}
