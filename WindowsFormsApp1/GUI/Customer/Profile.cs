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

namespace WindowsFormsApp1.Customer
{
    public partial class Profile : Form
    {
        private int userId;
        private int customerId;
        private Cart cart;

        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)

        public Profile()
        {

            InitializeComponent();
            LoadCartItems();
            LoadOrders();
            LoadOrderStatusChart();
            LoadUserInfo();

            // Hide text boxes initially
            txtFname.Visible = false;
            txtLname.Visible = false;
            txtEmail.Visible = false;
            txtPhone.Visible = false;
            txtUsername.Visible = false;
            txtPwd.Visible = false;

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

        /*
         * 
         * The Cart List Displaying and funtoning code 
         * Start
         * 
         * */
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

        private void btnproceedtocheckout_Click_1(object sender, EventArgs e)
        {
            // Ask the user for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to proceed with the checkout?", "Confirm Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int userId = SessionManager.LoggedInUserId;
                Cart cart = new Cart();
                List<CartItem> cartItems = cart.GetCartItems(userId);

                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Your cart is empty. Cannot proceed with checkout.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Orders orders = new Orders();
                List<OrderDetail> orderDetails = new List<OrderDetail>();

                // Prepare the order details from cart items
                foreach (var item in cartItems)
                {
                    orderDetails.Add(new OrderDetail
                    {
                        CarID = item.CarID,
                        PartID = item.PartID,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                int customerId = new Customers().GetCustomerIdByUserId(userId);

                // Insert the order and order details
                int orderId = orders.InsertOrder(customerId, orderDetails);

                if (orderId > 0)
                {
                    MessageBox.Show("Your order has been placed successfully!", "Order Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the cart after successful checkout
                    cart.ClearCart(customerId);

                    // Refresh the cart items
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
                else
                {
                    MessageBox.Show("An error occurred while placing your order. Please try again.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnproceedtocheckout_Click(object sender, EventArgs e)
        {

        }
        /*
         * 
         * The Cart List Displaying and funtoning code 
         * End
         * 
         * */


        /*
         * 
         * The Order List Displaying and funtoning code 
         * Start
         * 
         * */
        private void Customer_Orders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            Orders orders = new Orders();
            int userId = SessionManager.LoggedInUserId;
            int customerId = new Customers().GetCustomerIdByUserId(userId);

            List<Order> customerOrders = orders.GetOrdersByCustomerId(customerId);

            flporderlist.Controls.Clear();
            foreach (Order order in customerOrders)
            {
                OrdersCard orderCard = new OrdersCard();
                orderCard.OrderID = order.OrderID.ToString();
                orderCard.OrderDate = order.OrderDate.ToString("dd/MM/yyyy");
                orderCard.TotalAmount = $"${order.TotalAmount}";
                orderCard.OrderStatus = order.Status;

                // Attach event handler for canceling order
                orderCard.CancelOrderButton.Click += (s, e) => CancelOrder(order.OrderID);

                flporderlist.Controls.Add(orderCard);
            }

            if (customerOrders.Count == 0)
            {
                MessageBox.Show("You have no orders.", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CancelOrder(int orderId)
        {
            Orders orders = new Orders();
            bool success = orders.DeleteOrder(orderId);

            if (success)
            {
                MessageBox.Show("Order has been canceled successfully.", "Order Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders(); // Refresh orders list
            }
            else
            {
                MessageBox.Show("An error occurred while canceling the order. Please try again.", "Order Cancel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * 
         * The Order List Displaying and funtoning code 
         * End
         * 
         * */


        // Fetch Order Status Data
        private void LoadOrderStatusChart()
        {
            Orders orders = new Orders();
            int userId = SessionManager.LoggedInUserId;
            int customerId = new Customers().GetCustomerIdByUserId(userId);

            List<Order> customerOrders = orders.GetOrdersByCustomerId(customerId);

            // Dictionary to hold the count of orders per status
            Dictionary<string, int> orderStatusCounts = new Dictionary<string, int>
            {
                { "Pending", 0 },
                { "Completed", 0 },
                { "Cancelled", 0 }
            };

            // Populate the dictionary with counts
            foreach (Order order in customerOrders)
            {
                if (orderStatusCounts.ContainsKey(order.Status))
                {
                    orderStatusCounts[order.Status]++;
                }
            }

            // Clear the chart
            charTotOrders.Series.Clear();

            // Create a series for the chart
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Orders")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };

            // Add data points to the series
            foreach (var status in orderStatusCounts)
            {
                series.Points.AddXY(status.Key, status.Value);
            }

            // Add the series to the chart
            charTotOrders.Series.Add(series);

            // Customize chart appearance if needed
            charTotOrders.Titles.Clear();
            charTotOrders.Titles.Add("Order Status Distribution");
        }


        // Load user information in to the labels 
        private void LoadUserInfo()
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId > 0)
            {
                Users user = new Users(); 
                var userInfo = user.GetUserInfoById(userId); // Fetch the user information from the database

                if (userInfo != null)
                {
                    lbluid.Text = userInfo.UserID.ToString();
                    lblfname.Text = userInfo.FirstName;
                    lbllname.Text = userInfo.LastName;
                    lblemail.Text = userInfo.Email;
                    lblphone.Text = userInfo.Phone;
                    lblusername.Text = userInfo.Username;
                    lblpwd.Text = userInfo.Password; 
                }
                else
                {
                    MessageBox.Show("Unable to retrieve user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /*
         * 
         * Edit now button implimentation 
         * Start 
         * 
         */

        private bool isEditMode = false;

        private void btneditnow_Click_1(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                // Switch to Edit Mode
                isEditMode = true;
                btneditnow.Text = "Save";

                // Hide Labels
                lblfname.Visible = false;
                lbllname.Visible = false;
                lblemail.Visible = false;
                lblphone.Visible = false;
                lblusername.Visible = false;
                lblpwd.Visible = false;

                // Show Textboxes with current label values
                txtFname.Text = lblfname.Text;
                txtLname.Text = lbllname.Text;
                txtEmail.Text = lblemail.Text;
                txtPhone.Text = lblphone.Text;
                txtUsername.Text = lblusername.Text;
                txtPwd.Text = lblpwd.Text;

                txtFname.Visible = true;
                txtLname.Visible = true;
                txtEmail.Visible = true;
                txtPhone.Visible = true;
                txtUsername.Visible = true;
                txtPwd.Visible = true;
            }
            else
            {
                // Save the updated information
                int userId = SessionManager.LoggedInUserId;
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;
                string username = txtUsername.Text;
                string password = txtPwd.Text;

                Users user = new Users();
                bool isUpdated = user.UpdateUser(userId, firstName, lastName, email, phone, username, password, "Customer");

                if (isUpdated)
                {
                    MessageBox.Show("User information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Switch back to View Mode
                    isEditMode = false;
                    btneditnow.Text = "Edit";

                    // Hide Textboxes
                    txtFname.Visible = false;
                    txtLname.Visible = false;
                    txtEmail.Visible = false;
                    txtPhone.Visible = false;
                    txtUsername.Visible = false;
                    txtPwd.Visible = false;

                    // Update Labels with new values
                    lblfname.Text = firstName;
                    lbllname.Text = lastName;
                    lblemail.Text = email;
                    lblphone.Text = phone;
                    lblusername.Text = username;
                    lblpwd.Text = password; // Again, consider hiding or masking this

                    // Show Labels
                    lblfname.Visible = true;
                    lbllname.Visible = true;
                    lblemail.Visible = true;
                    lblphone.Visible = true;
                    lblusername.Visible = true;
                    lblpwd.Visible = true;
                }
                else
                {
                    MessageBox.Show("An error occurred while updating the information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*
         * 
         * Edit now button implimentation 
         * End
         * 
         */

        private void btneditnow_Click(object sender, EventArgs e)
        {

        }
    }
}
