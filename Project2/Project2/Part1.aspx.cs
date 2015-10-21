using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Part1 : System.Web.UI.Page
    {
        static String rawAge;
        static String rawHeartRate;
        static int age;
        static double restHeartRate;
        static double targetHeartRate;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calcButton_Click(object sender, EventArgs e)
        {
            rawAge = ageTextBox.Text;
            rawHeartRate = rateTextBox.Text;

            try
            {
                age = Convert.ToInt32(rawAge);
                restHeartRate = Convert.ToDouble(rawHeartRate);
                targetHeartRate = 220 - age;
                targetHeartRate = targetHeartRate - restHeartRate;
                targetHeartRate = targetHeartRate * .6;
                targetHeartRate = targetHeartRate + restHeartRate;
                resultLabel.Text = "THR: " + targetHeartRate;
                warnLabel.Text = "";
            }
            catch (FormatException)
            {
                warnLabel.Text = "Age must be an integer and Resting Heart Rate must be any number";
                resultLabel.Text = "";
            }
            catch (OverflowException)
            {
                warnLabel.Text = "Values cannot exceed 32 bits";
                resultLabel.Text = "";
            }
        }
    }
}