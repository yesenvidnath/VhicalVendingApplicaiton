using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace WindowsFormsApp1.Funtions
{
    public class Cart
    {
        private dbconnect dbconnect;

        public Cart()
        {
            dbconnect = new dbconnect();
        }

        /*
        public bool UpdateCartQuantity(int userId, int? carId, int? partId, int newQuantity)
        {
            try
            {
                dbconnect.OpenConnection();

                //Get cusromer ID usinf the userID 
                int customerId = GetCustomerIdByUserId(userId);


            }
        }*/

    }

  
}
