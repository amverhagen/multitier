using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Part1
{
    public partial class gender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Students"].ConnectionString);
                string query = "select distinct gender from students";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "gender");
                ddlGender.DataSource = ds.Tables["gender"];
                ddlGender.DataTextField = "gender";
                ddlGender.DataValueField = "gender";
                ddlGender.DataBind();
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Students"].ConnectionString);
            string query = "select * from students where gender=@gender";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDisplay.DataSource = ds;
            gvDisplay.DataBind();
        }
    }
}