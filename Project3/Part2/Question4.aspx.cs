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
    public partial class Question4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
                string query = "select distinct title,studyid from studies";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "title");
                ddlStudies.DataSource = ds.Tables["title"];
                ddlStudies.DataTextField = "title";
                ddlStudies.DataValueField = "studyid";
                ddlStudies.DataBind();
            }
            
        }

        protected void ddlStudies_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
            string query = "select physicianid from [study-physician] where studyid=@studyid";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@studyid", ddlStudies.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "physicianid");
            ddlPhysicians.DataSource = ds.Tables["physicianid"];
            ddlPhysicians.DataTextField = "physicianid";
            ddlPhysicians.DataValueField = "physicianid";
            ddlPhysicians.DataBind();
            PopulateTable();
        }

        protected void ddlPhysicians_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTable();
        }

        public void PopulateTable()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Research"].ConnectionString);
            string query = "select firstname,lastname from physicians where physicianid=@id";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", ddlPhysicians.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDisplay.DataSource = ds;
            gvDisplay.DataBind();
        }
    }
}