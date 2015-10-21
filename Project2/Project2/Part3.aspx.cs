using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Part3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calcButton_Click(object sender, EventArgs e)
        {
            String rawQuizScore;
            String rawAssignmentScore;
            String rawMidtermScore;
            String rawFinalExamScore;
            double quizScore;
            double assignmentScore;
            double midtermScore;
            double finalExamScore;
            double averageScore;

            rawQuizScore = quizTextBox.Text;
            rawAssignmentScore = assignTextBox.Text;
            rawMidtermScore = midTextBox.Text;
            rawFinalExamScore = finalTextBox.Text;

            try
            {
                quizScore = Convert.ToDouble(rawQuizScore);
                assignmentScore = Convert.ToDouble(rawAssignmentScore);
                midtermScore = Convert.ToDouble(rawMidtermScore);
                finalExamScore = Convert.ToDouble(rawFinalExamScore);
                warnLabel.Text = "";
                averageScore = quizScore * .15;
                averageScore += assignmentScore * .40;
                averageScore += midtermScore * .20;
                averageScore += finalExamScore * .25;
                resultLabel.Text = Convert.ToString(averageScore);
                if (averageScore < 60)
                {
                    resultLabel.Text = Convert.ToString(averageScore) + ", F";
                }
                else if (averageScore < 70)
                {
                    resultLabel.Text = Convert.ToString(averageScore) + ", D";
                }
                else if (averageScore < 80)
                {
                    resultLabel.Text = Convert.ToString(averageScore) + ", C";
                }
                else if (averageScore < 90)
                {
                    resultLabel.Text = Convert.ToString(averageScore) + ", B";
                }
                else
                {
                    resultLabel.Text = Convert.ToString(averageScore) + ", A";
                }
            }
            catch(FormatException){
                warnLabel.Text = "Must fill all fields with numbers";
            }
            catch (OverflowException)
            {
                warnLabel.Text = "Numbers can't exceed 32 bits";
            }
        }
    }
}