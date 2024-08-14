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

namespace WindowsFormsApp1.Admin
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
    }
}
