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
            // Create click events for labels
            lblhome.Click += lblhome_Click;
            lblsettings.Click += lblsettings_Click;
            lblorderlist.Click += lblorderlist_Click;
            lblorders.Click += lblorders_Click;
            lblloggedusername.Click += lblloggedusername_Click;
        }

        // Creat Nav Lable click event funtions
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
            Customer.Orders orders = new Customer.Orders();
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

        //Setting the logged in user 
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



    }
}
