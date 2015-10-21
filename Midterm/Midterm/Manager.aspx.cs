using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Midterm
{
    public partial class Manager : System.Web.UI.Page
    {
        OleDbConnection conn;
        string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["QA"].ConnectionString);
            if (!IsPostBack)
            {
                FillDevs();
                status = rblStatus.SelectedValue;
            }
        }

        protected void FillDevs()
        {
            string qry = "select name,employeeid from employee where type=@dev";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@dev", "developer");
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "name");
            ddlDev.DataSource = ds.Tables["name"];
            ddlDev.DataTextField = "name";
            ddlDev.DataValueField = "employeeid";
            ddlDev.DataBind();
        }

        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOptions();
            PopulateTable();
        }

        protected void FillOptions()
        {
            status = rblStatus.SelectedValue;
            string qry = "select bugid from bugs where status=@status";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@status",status);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds,"bugid");
            ddlBugs.DataSource = ds.Tables["bugid"];
            ddlBugs.DataTextField = "bugid";
            ddlBugs.DataValueField = "bugid";
            ddlBugs.DataBind();
        }

        protected void PopulateTable()
        {
            string bugid = ddlBugs.SelectedValue;
            string qry = "select * from bugs where bugid=@bugid";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("bugid", bugid);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dvBugs.DataSource = ds;
            dvBugs.DataBind();
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string bugid = ddlBugs.SelectedValue;
            string empid = ddlDev.SelectedValue;
            if (String.IsNullOrEmpty(bugid) || rblStatus.SelectedValue.Equals("Completed") || rblStatus.SelectedValue.Equals("Assigned"))
            {
                lblMessage.Text = "Must have an Open bug selected";
            }
            else
            {
                string qry = "UPDATE bugs SET assignedto = @empid, status =@assigned where bugid=@bugid";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@assigned", "Assigned");
                cmd.Parameters.AddWithValue("@bugid", bugid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Text = "Assigned Bug# " + bugid + " to Employee# " + empid;
                FillOptions();
                PopulateTable();
            }
        }

        protected void ddlBugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTable();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}