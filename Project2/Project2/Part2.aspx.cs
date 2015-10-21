using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Part2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calcButton_Click(Object sender, EventArgs e)
        {
            String rawDays;
            int days;
            decimal rate;
            decimal total;

            rawDays = daysTextBox.Text;
            warnLabel.Text = rawDays;
            try
            {
                days = Convert.ToInt32(rawDays);
                rate = Convert.ToDecimal(ddlType.SelectedValue);
                total = days * rate;
                totalLabel.Text = Convert.ToString(total);
                warnLabel.Text = "";
            }
            catch(FormatException){
                warnLabel.Text = "Must enter an integer";
                totalLabel.Text = "";
            }
            catch (OverflowException)
            {
                warnLabel.Text = "Must enter an integer less than 32 bits";
                totalLabel.Text = "";
            }

        }
    }
}