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
    public partial class Specializations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
                string query = "select distinct specialization from physicians";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "specialization");
                ddlSpecials.DataSource = ds.Tables["specialization"];
                ddlSpecials.DataTextField = "specialization";
                ddlSpecials.DataValueField = "specialization";
                ddlSpecials.DataBind();
            }
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
            string query = "select firstname,lastname,phonenumber from physicians where specialization=@special";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@special", ddlSpecials.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDisplay.DataSource = ds;
            gvDisplay.DataBind();
        }
    }
}