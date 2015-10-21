using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Part5 : System.Web.UI.Page
    {
        static decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            decimal price;
            int quantity;

            try
            {
                price = Convert.ToDecimal(itemsDDL.SelectedItem.Value);
                quantity = Convert.ToInt16(quantityTextBox.Text);
                if (quantity == 0)
                {
                    throw new FormatException();
                }
                warnLabel.Text = "";
                total += price * quantity;
                if (quantity == 1)
                {
                    resultLabel.Text = quantity + " copy of " + itemsDDL.SelectedItem.Text + " was added to the cart";
                }
                else
                {
                    resultLabel.Text = quantity + " copies of " + itemsDDL.SelectedItem.Text + " were added to the cart";
                }
            }
            catch(FormatException)
            {
                warnLabel.Text = "Quantity must be filled with an integer greater than 0";
                resultLabel.Text = "";
            }
        }

        protected void checkOutButton_Click(object sender, EventArgs e)
        {
            total = Math.Round(total, 2);
            resultLabel.Text = "Your total is: $" + total;
        }
    }
}