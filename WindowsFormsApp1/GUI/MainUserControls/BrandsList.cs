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
    public partial class BrandsList : UserControl
    {

        //Brand section handle Event
        public event EventHandler<string> BrandSelected;

        public BrandsList()
        {
            InitializeComponent();
            //Create the click event for the lable 
            lblbrandname.Click += LblBrandName_Click;
        }

        private void LblBrandName_Click(object sender, EventArgs e)
        {
            // Trigger the event with the brand name
            BrandSelected?.Invoke(this, lblbrandname.Text);
        }


        private void BrandsList_Load(object sender, EventArgs e)
        {

        }

        public void SetBrandInfo(string brandName, string imagePath)
        {
            lblbrandname.Text = brandName;
            imgbrand.ImageLocation = imagePath;
        }
    }
}
