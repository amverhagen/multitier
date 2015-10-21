using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Part2
{
    public partial class Question5 : System.Web.UI.Page
    {
        string rawInput;
        decimal input;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rawInput = tbSearch.Text;
            try
            {
                input = Convert.ToDecimal(rawInput);
                DisplayInfo();
                lbMessage.Text = "";
            }
            catch (FormatException)
            {
                lbMessage.Text = "Input must be a number";
            }
            catch (OverflowException){
                lbMessage.Text = "Input must be smaller";
            }
        }

        public void DisplayInfo()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
            string query = "select * from volunteers where cholesterol > @value";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@value", input);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDisplay.DataSource = ds;
            gvDisplay.DataBind();
        }
    }
}