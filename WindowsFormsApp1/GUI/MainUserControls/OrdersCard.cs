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
    public partial class OrdersCard : UserControl
    {
        public Button CancelOrderButton
        {
            get { return btncancelorder; }
        }


        public OrdersCard()
        {
            InitializeComponent();
        }
        public string OrderID
        {
            get { return lblorderid.Text; }
            set { lblorderid.Text = value; }
        }

        public string OrderDate
        {
            get { return lblorderdate.Text; }
            set { lblorderdate.Text = value; }
        }

        public string TotalAmount
        {
            get { return lbltotamount.Text; }
            set { lbltotamount.Text = value; }
        }

        public string OrderStatus
        {
            get { return lblorderstatus.Text; }
            set { lblorderstatus.Text = value; }
        }

        private void OrdersCard_Load(object sender, EventArgs e)
        {

        }
    }
}
