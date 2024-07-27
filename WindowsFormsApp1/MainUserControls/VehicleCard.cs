using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MainUserControls
{
    public partial class VehicleCard : UserControl
    {
        public VehicleCard()
        {
            InitializeComponent();


        }
        public void SetCarInfo(string carName, string brand, int year, decimal price, string imagePath)
        {
            lblcarname.Text = carName;
            lblbrand.Text = brand;
            lblyear.Text = year.ToString();
            lblprice.Text = $"${price}";
            imgbox.ImageLocation = imagePath;
        }

        private void VehicleCard_Load(object sender, EventArgs e)
        {

        }

        private void imgbox_Click(object sender, EventArgs e)
        {

        }

        private void btnaddlist_Click(object sender, EventArgs e)
        {
            
        }

        private void btnseemore_Click(object sender, EventArgs e)
        {
            
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            
        }

        private void imgbox_Click_1(object sender, EventArgs e)
        {

        }
    }
}
