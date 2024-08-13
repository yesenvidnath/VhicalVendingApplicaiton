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
using static WindowsFormsApp1.MainUserControls.NavBar;
using WindowsFormsApp1.Funtions.Customer;
using WindowsFormsApp1.MainUserControls;
using WindowsFormsApp1.GUI.MainUserControls;

namespace WindowsFormsApp1.Customer
{
    public partial class Customer_Orders : Form
    {
        private int userId;
        private int customerId;
        private Cart cart;

        public Customer_Orders()
        {
            InitializeComponent();
            LoadOrders();

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

        private void Customer_Orders_Load(object sender, EventArgs e)
        {
            LoadOrders();
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

    }
}
