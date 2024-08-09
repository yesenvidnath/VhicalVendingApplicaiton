using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Funtions.HomeFuntions;

namespace WindowsFormsApp1.GUI.MainUserControls
{
    public partial class PartsCard : UserControl
    {
        public PartsCard()
        {
            InitializeComponent();
        }

        // Assuming you have labels or other controls to display these properties
        public void SetPartInfo(string partName, decimal price, int quantityAvailable, string imagePath)
        {
            try
            {
                lblPartName.Text = partName;
                lblPrice.Text = $"${price}";
                lblQuantityAvailable.Text = quantityAvailable.ToString();
                imgPart.ImageLocation = imagePath;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"An error occurred while setting part info: {ex.Message}");
            }
        }


        private void btnorder_Click(object sender, EventArgs e)
        {

        }

        private void btnseemore_Click(object sender, EventArgs e)
        {

        }

        private void btnaddlist_Click(object sender, EventArgs e)
        {

        }
    }
}
