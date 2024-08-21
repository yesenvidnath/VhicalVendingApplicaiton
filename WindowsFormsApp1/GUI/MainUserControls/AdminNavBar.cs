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
using WindowsFormsApp1.Funtions;
using WindowsFormsApp1.Admin;
using WindowsFormsApp1.GUI.Admin;

namespace WindowsFormsApp1.GUI.MainUserControls
{
    public partial class AdminNavBar : UserControl
    {

        public AdminNavBar()
        {
            InitializeComponent();
            LoadAdminInfo();
            btnLogout.Click += BtnLogout_Click;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }


        private void LoadAdminInfo()
        {
            int adminId = SessionManager.LoggedInUserId;

            if (adminId > 0)
            {
                Users users = new Users();
                var adminInfo = users.GetUserInfoById(adminId);

                if (adminInfo != null)
                {
                    lblAdminUsername.Text = adminInfo.Username;
                    lblAdminRole.Text = adminInfo.Role;
                }
                else
                {
                    MessageBox.Show("Admin info could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblAdminUsername.Text = "Not logged in";
                lblAdminRole.Text = "";
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LogOutAdminUser();
            }
        }

        private void LogOutAdminUser()
        {
            // Clear any session or user-specific data
            SessionManager.LoggedInUserId = -1;
            SessionManager.UserRole = string.Empty;

            // Show the login form after logout
            this.ParentForm.Hide();
            login loginForm = new login(); 
            loginForm.Show();
        }

        private void lblmanageproducts_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            ManageProducts MP = new ManageProducts();
            MP.Show();
        }

        private void lblmanageusers_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            ManageUsers MU = new ManageUsers();
            MU.Show();
        }

        private void lblmanageorders_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            ManageOrders MO = new ManageOrders();
            MO.Show();
        }

        private void lblmanagebrands_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            ManageBrands MB = new ManageBrands();
            MB.Show();
        }

        private void lblreports_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            ManageReports MR = new ManageReports();
            MR.Show();
        }
    }
}
