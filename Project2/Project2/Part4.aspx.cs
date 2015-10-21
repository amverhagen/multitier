using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Part4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calcButton_Click(object sender, EventArgs e)
        {
            String rawIncome;
            String rawDependents;
            Decimal income;
            Decimal rate;
            Decimal taxable;
            int dependents;

            rawIncome = incomeTextBox.Text;
            rawDependents = dependTextBox.Text;

            try {
                income = Convert.ToDecimal(rawIncome);
                dependents = Convert.ToInt16(rawDependents);
                warnLabel.Text = "";
                if (income < 0)
                {
                    throw new FormatException();
                }
                if(income > 450000){
                    rate = .396m;
                }
                else if(income > 378000){
                    rate = .33m;
                }
                else if (income > 192000)
                {
                    rate = .28m;
                }
                else if (income > 71000)
                {
                    rate = .25m;
                }
                else if (income > 15000)
                {
                    rate = .15m;
                }
                else
                {
                    rate = .10m;
                }
                taxable = income - (1000 * dependents);
                taxable = taxable * rate;
                taxable = Math.Round(taxable, 2);
                if (taxable < 0)
                {
                    resultLabel.Text = "Taxable Income: $0"; 
                }
                else
                {
                    resultLabel.Text = "Taxable Income: $" + taxable; 
                }
            }
            catch(FormatException){
                warnLabel.Text = "Income must be a number greater than one and dependents must be an integer";
                resultLabel.Text = "";
            }
            catch (OverflowException)
            {
                warnLabel.Text = "Numbers cannot exceed 32 bits";
                resultLabel.Text = "";
            }
        }
    }
}