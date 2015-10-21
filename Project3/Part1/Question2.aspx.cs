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
    public partial class states : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Students"].ConnectionString);
                string query = "select distinct state from students";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "state");
                ddlStates.DataSource = ds.Tables["state"];
                ddlStates.DataTextField = "state";
                ddlStates.DataValueField = "state";
                ddlStates.DataBind();
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Students"].ConnectionString);
            string query = "select FirstName,LastName,State from students where State=@state";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@state", ddlStates.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDisplay.DataSource = ds;
            gvDisplay.DataBind();
        }
    }
}