using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace Midterm
{
    public partial class Developer : System.Web.UI.Page
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["QA"].ConnectionString);
            if (!IsPostBack)
            {
                PopulateBugs();
            }
        }

        protected void PopulateBugs()
        {
            string qry = "select * from bugs where assignedto=@id AND status=@assign";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@id", Session["id"]);
            cmd.Parameters.AddWithValue("@assign","Assigned");
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvBugs.DataSource = ds;
            gvBugs.DataBind();
            da.Fill(ds, "bugid");
            ddlbugs.DataSource = ds.Tables["bugid"];
            ddlbugs.DataTextField = "bugid";
            ddlbugs.DataValueField = "bugid";
            ddlbugs.DataBind();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlbugs.SelectedValue))
            {
                if(tbChanges.Text.Length>60)
                {
                    lblMessage.Text = "Change log to long";
                }
                else
                {
                    SHA1Managed sha1 = new SHA1Managed();
                    sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    byte[] result = sha1.Hash;

                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < result.Length; i++)
                    {
                        strBuilder.Append(result[i].ToString("x2"));
                    }

                    string qry = "UPDATE bugs SET status = @comp, changes =@changes where bugid=@bugid";
                    OleDbCommand cmd = new OleDbCommand(qry, conn);
                    cmd.Parameters.AddWithValue("@comp", "Completed");
                    cmd.Parameters.AddWithValue("@changes", tbChanges.Text);
                    cmd.Parameters.AddWithValue("@bugid", ddlbugs.SelectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    PopulateBugs();
                }
            }
            else
            {
                lblMessage.Text = "No bugs to Fix";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}