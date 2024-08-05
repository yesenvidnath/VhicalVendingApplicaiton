using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.Funtions;
using static WindowsFormsApp1.MainUserControls.NavBar;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        //calling the connection methode
        //private dbconnect dbconnect;

        private loginRegistration loginRegistration;

        public login()
        {
            InitializeComponent();
            //dbconnect = new dbconnect();
            loginRegistration = new loginRegistration();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        //Login Button
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Login Button confiiguration
            string username = txtusername.Text;
            string password = txtpwd.Text;

            var loginResult = loginRegistration.LoginUser(username, password);

            if (loginResult.isAuthenticated)
            {
                // Store the logged-in user's ID and role in SessionManager
                SessionManager.LoggedInUserId = loginResult.userId;
                SessionManager.UserRole = loginResult.role;

                var result = MessageBox.Show("El usuario es correcto, ¡hola amigo!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {

                    if (loginResult.role == "Admin")
                    {
                        Admin.Dashboard adminDashboard = new Admin.Dashboard();
                        this.Hide();
                        adminDashboard.Show();
                        adminDashboard.FormClosed += (s, args) => this.Close();
                    }
                    else if (loginResult.role == "Customer")
                    {
                        Home home = new Home(loginResult.userId); // Pass the userId to Home
                        this.Hide();
                        home.Show();
                        home.FormClosed += (s, args) => this.Close(); // Ensure the form is closed when Home is closed
                    }
                }
            }
            else
            {
                MessageBox.Show("El usuario no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Register Button
        private void btnregister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            this.Hide();

            registerForm.Show();

            registerForm.FormClosed += (s, args) => this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
