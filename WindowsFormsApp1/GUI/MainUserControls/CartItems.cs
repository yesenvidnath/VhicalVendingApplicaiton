using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.GUI.MainUserControls
{
    public partial class CartItems : UserControl
    {

        public CartItems()
        {
            InitializeComponent();
        }

        public string ItemName
        {
            get { return lblitemname.Text; }
            set { lblitemname.Text = value; }
        }

        public string Price
        {
            get { return lblprice.Text; }
            set { lblprice.Text = value; }
        }

        public string Quantity
        {
            get { return lblquntitty.Text; }
            set { lblquntitty.Text = value; }
        }

        public string ImagePath
        {
            get { return itemimg.ImageLocation; }
            set { itemimg.ImageLocation = value; }
        }

        public Button RemoveButton
        {
            get { return btnremoveitem; }
        }

        private void btnremoveitem_Click(object sender, System.EventArgs e)
        {
    
        }

    }
}
