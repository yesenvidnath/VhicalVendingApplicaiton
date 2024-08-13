using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Customer;
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.GUI;

namespace WindowsFormsApp1.MainUserControls
{
    public partial class NavBar : UserControl
    {
        private void NavBar_Load(object sender, EventArgs e)
        {

        }

        public NavBar()
        {
            InitializeComponent();
            SetLoggedInUser();
            UpdateCartItemCount();

            // Create click events for labels
            lblhome.Click += lblhome_Click;
            lblsettings.Click += lblsettings_Click;
            lblorderlist.Click += lblorderlist_Click;
            lblorders.Click += lblorders_Click;
            lblloggedusername.Click += lblloggedusername_Click;
            picboxcart.Click += Picboxcart_Click;
        }

        // Create Nav Label click event functions
        private void lblhome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home(SessionManager.LoggedInUserId);
            homeForm.ShowDialog();
            this.ParentForm.Hide();
        }

        private void lblsettings_Click(object sender, EventArgs e)
        {
            Customer.Profile profileForm = new Customer.Profile();
            profileForm.Show();
            this.ParentForm.Hide();
        }

        private void lblorderlist_Click(object sender, EventArgs e)
        {
            Customer.OrderList orderlist = new Customer.OrderList();
            orderlist.Show();
            this.ParentForm.Hide();
        }

        private void lblorders_Click(object sender, EventArgs e)
        {
            Customer.Customer_Orders orders = new Customer.Customer_Orders();
            orders.Show();
            this.ParentForm.Hide();
        }

        private void lblloggedusername_Click(object sender, EventArgs e)
        {
            Customer.Profile profile = new Customer.Profile();
            profile.Show();
            this.ParentForm.Hide();
        }

        public static class SessionManager
        {
            public static int LoggedInUserId { get; set; } = -1; // Default to -1 meaning no user is logged in
            public static string UserRole { get; set; } = string.Empty;
        }

        //Display the Cart
        private void Picboxcart_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (SessionManager.LoggedInUserId > 0)
            {
                // User is logged in, open the CustomerCart form
                CustomerCart customerCartForm = new CustomerCart();
                customerCartForm.ShowDialog();
            }
            else
            {
                // User is not logged in, show a message prompting them to log in
                MessageBox.Show("Please log in to access your cart.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblCartdisplay_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (SessionManager.LoggedInUserId > 0)
            {
                // User is logged in, open the CustomerCart form
                CustomerCart customerCartForm = new CustomerCart();
                customerCartForm.ShowDialog();
            }
            else
            {
                // User is not logged in, show a message prompting them to log in
                MessageBox.Show("Please log in to access your cart.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LogOutUser()
        {
            SessionManager.LoggedInUserId = -1;
            SessionManager.UserRole = string.Empty;

            // Optionally, reset other session-related information here if needed

            // Show the login form after logout
            this.ParentForm.Hide();
            Home home = new Home();
            home.Show();
        }

        private void btnloginlogout_Click(object sender, EventArgs e)
        {
            if (btnloginlogout.Text == "Log Out")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LogOutUser();
                }
            }
            else if (btnloginlogout.Text == "Login/Register")
            {
                DialogResult result = MessageBox.Show("Are you an existing customer?", "Login/Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.ParentForm.Hide();
                    login loginForm = new login();
                    loginForm.Show();
                }
                else
                {
                    this.ParentForm.Hide();
                    Register registerForm = new Register();
                    registerForm.Show();
                }
            }
        }

        // Set the logged-in user
        public void SetLoggedInUser()
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId > 0)
            {
                Customers customers = new Customers();
                var (firstName, lastName, _, _) = customers.GetCustomerInfo(userId);

                if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName))
                {
                    lblloggedusername.Text = $"Welcome {firstName} {lastName}";
                    btnloginlogout.Text = "Log Out"; // Set button text to "Log Out"
                }
                else
                {
                    lblloggedusername.Text = "Log in Now";
                    btnloginlogout.Text = "Login/Register";
                }
            }
            else
            {
                lblloggedusername.Text = "Log In Now";
                btnloginlogout.Text = "Login/Register";
            }
        }

        public void UpdateCartItemCount()
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId > 0)
            {
                Customers customers = new Customers();
                int customerId = customers.GetCustomerIdByUserId(userId);

                if (customerId > 0)
                {
                    Cart cart = new Cart();
                    int totalCartItemsQuantity = cart.GetTotalCartItemsQuantity(customerId);

                    if (totalCartItemsQuantity > 0)
                    {
                        lblcartitemcount.Text = totalCartItemsQuantity.ToString();
                        Console.WriteLine("Cart Item Count Updated: " + totalCartItemsQuantity); // Debugging output
                    }
                    else
                    {
                        lblcartitemcount.Text = "0";
                        Console.WriteLine("Cart is empty for customer ID: " + customerId); // Debugging output
                    }
                }
                else
                {
                    lblcartitemcount.Text = "0";
                    Console.WriteLine("No customer found for user ID: " + userId); // Debugging output
                }
            }
            else
            {
                lblcartitemcount.Text = "0";
                Console.WriteLine("No user is logged in."); // Debugging output
            }
        }
    }
}
