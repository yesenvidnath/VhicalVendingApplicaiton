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

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        private loginRegistration loginRegistration;


        public Register()
        {
            InitializeComponent();
            loginRegistration = new loginRegistration();
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            string firstName = txtfname.Text;
            string lastName = txtlname.Text;
            string email = txtemail.Text;   
            string phone = txtphone.Text;   
            string username = txtusername.Text; 
            string password = txtpwd.Text;
            string role = comboBox1.SelectedItem.ToString();    

            bool success = loginRegistration.RegisterUser(firstName, lastName, email, phone, username, password, role);

            if (success)
            {
                MessageBox.Show("usuario registro fue exitoso", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ay ay ay usuario registro no fue exitoso","Registration Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
