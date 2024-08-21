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
using WindowsFormsApp1.Funtions.Admin;
using WindowsFormsApp1.GUI.MainUserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Data.SqlClient;
using WindowsFormsApp1.MainUserControls;

namespace WindowsFormsApp1.Admin
{
    public partial class Profile : Form
    {

        private int userId;

        public int CarID { get; set; }  // Property to hold the CarID
        public int? PartId { get; set; } // Property to hold the PartID (nullable)


        public Profile()
        {
            InitializeComponent();
            LoadUserInfo();
            LoadOrderSummaryChart();
            LoadEarningsChart();
            LoadItemsByBrandChart();
            LoadDashboardData();

            // Hide text boxes initially
            txtFname.Visible = false;
            txtLname.Visible = false;
            txtEmail.Visible = false;
            txtPhone.Visible = false;
            txtUsername.Visible = false;
            txtPwd.Visible = false;

            // Get the logged in user ID
            userId = SessionManager.LoggedInUserId;
            string userRole = SessionManager.UserRole;

            AdminNavBar adminNavBar = new AdminNavBar();
            adminNavBar.Dock = DockStyle.Top;
            this.Controls.Add(adminNavBar);
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

        /*/
         * 
         * Edit now button implimentation 
         * Start 
         * 
         /*/

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



        /*
         * Start the Chart 'charTotOrders' chart
         * Start 
         * 
         */

        private void LoadOrderSummaryChart()
        {
            Orders orders = new Orders();
            List<OrderSummary> orderSummaries = orders.GetOrderSummaryByDate();

            // Reset the appearance before adding data
            ResetChartAppearance(charTotOrders);

            // Clear any existing series in the chart
            charTotOrders.Series.Clear();

            // Create series for Parts and Vehicles
            var seriesParts = new System.Windows.Forms.DataVisualization.Charting.Series("Parts")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.MediumSeaGreen, // Custom color for Parts line
                BorderWidth = 3 // Make the line thicker for better visibility
            };

            var seriesVehicles = new System.Windows.Forms.DataVisualization.Charting.Series("Vehicles")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.CornflowerBlue, // Custom color for Vehicles line
                BorderWidth = 3 // Make the line thicker for better visibility
            };

            // Add data points to the series
            foreach (var summary in orderSummaries)
            {
                seriesParts.Points.AddXY(summary.OrderDate, summary.TotalPartsAmount);
                seriesVehicles.Points.AddXY(summary.OrderDate, summary.TotalVehiclesAmount);
            }

            // Add series to the chart
            charTotOrders.Series.Add(seriesParts);
            charTotOrders.Series.Add(seriesVehicles);

            // Set chart titles and axis labels if needed
            charTotOrders.Titles.Clear();
            charTotOrders.Titles.Add("Total Orders Over Time");
            charTotOrders.ChartAreas[0].AxisX.Title = "Order Date";
            charTotOrders.ChartAreas[0].AxisY.Title = "Total Amount";
        }


        /*
         * Start the Chart 'charTotOrders' chart
         * End 
         * 
         */


        /*
         * Start the Chart 'charTotearnings' chart
         * Start
         * 
         */

        private void LoadEarningsChart()
        {
            Orders orders = new Orders();
            List<OrderSummary> earningsSummaries = orders.GetEarningsByDate();

            // Reset the appearance before adding data
            ResetChartAppearance(charTotearnings);

            // Clear any existing series in the chart
            charTotearnings.Series.Clear();

            // Create series for Parts and Vehicles earnings
            var seriesParts = new System.Windows.Forms.DataVisualization.Charting.Series("Parts Earnings")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.FromArgb(128, 60, 179, 113), // Custom semi-transparent color for Parts area
                BorderColor = System.Drawing.Color.SeaGreen, // Border color for the area
                BorderWidth = 2
            };

            var seriesVehicles = new System.Windows.Forms.DataVisualization.Charting.Series("Vehicles Earnings")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.FromArgb(128, 65, 105, 225), // Custom semi-transparent color for Vehicles area
                BorderColor = System.Drawing.Color.RoyalBlue, // Border color for the area
                BorderWidth = 2
            };

            // Add data points to the series
            foreach (var summary in earningsSummaries)
            {
                seriesParts.Points.AddXY(summary.OrderDate, summary.TotalPartsAmount);
                seriesVehicles.Points.AddXY(summary.OrderDate, summary.TotalVehiclesAmount);
            }

            // Add series to the chart
            charTotearnings.Series.Add(seriesParts);
            charTotearnings.Series.Add(seriesVehicles);

            // Set chart titles and axis labels if needed
            charTotearnings.Titles.Clear();
            charTotearnings.Titles.Add("Total Earnings Over Time");
            charTotearnings.ChartAreas[0].AxisX.Title = "Order Date";
            charTotearnings.ChartAreas[0].AxisY.Title = "Total Earnings";
        }

        /*
         * Start the Chart 'charTotearnings' chart
         * End
         * 
         */


        /*
         * Start the Chart 'chartotitemsbybrands' chart
         * Start
         * 
         */
        private void LoadItemsByBrandChart()
        {
            Orders orders = new Orders();
            List<ItemSummaryByBrand> itemSummaries = orders.GetTotalItemsByBrand();

            // Clear any existing series in the chart
            chartotitemsbybrands.Series.Clear();
            chartotitemsbybrands.ChartAreas.Clear();
            chartotitemsbybrands.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea"));

            // Create series for Parts and Vehicles
            var seriesParts = new System.Windows.Forms.DataVisualization.Charting.Series("Parts")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar,
                Color = System.Drawing.Color.MediumSeaGreen
            };

            var seriesVehicles = new System.Windows.Forms.DataVisualization.Charting.Series("Vehicles")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar,
                Color = System.Drawing.Color.CornflowerBlue
            };

            // Add dynamic data points to the series
            foreach (var summary in itemSummaries)
            {
                seriesParts.Points.AddXY(summary.BrandName, summary.TotalParts);
                seriesVehicles.Points.AddXY(summary.BrandName, summary.TotalVehicles);
            }

            // Add series to the chart
            chartotitemsbybrands.Series.Add(seriesParts);
            chartotitemsbybrands.Series.Add(seriesVehicles);

            // Set chart titles and axis labels
            chartotitemsbybrands.Titles.Clear();
            chartotitemsbybrands.Titles.Add("Total Items by Brand");
            chartotitemsbybrands.ChartAreas[0].AxisX.Title = "Brand";
            chartotitemsbybrands.ChartAreas[0].AxisY.Title = "Total Items";
        }


        /*
         * Start the Chart 'chartotitemsbybrands' chart
         * End
         * 
         */


        /* 
         * reset some of the properties of the ChartArea 
         * 
         */
        private void ResetChartAppearance(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            var chartArea = chart.ChartAreas[0];

            // Reset chart area background
            chartArea.BackColor = System.Drawing.Color.White;

            // Reset X and Y axis lines and grids
            chartArea.AxisX.LineColor = System.Drawing.Color.Black;
            chartArea.AxisY.LineColor = System.Drawing.Color.Black;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            // Reset the area of the chart
            chart.BackColor = System.Drawing.Color.White;
            chartArea.BackSecondaryColor = System.Drawing.Color.White;
            chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.None;
        }

        /*
         * Display Data in Labels
         * Start
         *
         */

        private void LoadDashboardData()
        {
            // Get the total customers
            Customers customers = new Customers();
            int totalCustomers = customers.GetTotalCustomers();
            lbltotcustomers.Text = totalCustomers.ToString();

            // Get the total earnings
            Orders orders = new Orders();
            decimal totalEarnings = orders.GetTotalEarnings();
            lbltotalearnings.Text = $"${totalEarnings:F2}";

            // Get the total parts
            CarParts carParts = new CarParts();
            int totalParts = carParts.GetTotalParts();
            lbltotparts.Text = totalParts.ToString();

            WindowsFormsApp1.Funtions.Cars cars = new WindowsFormsApp1.Funtions.Cars();
            int totalCars = cars.GetTotalCars();
            lbltotcars.Text = totalCars.ToString();
        }

        /*
         * Display Data in Labels
         * Start
         *
         */


    }
}
