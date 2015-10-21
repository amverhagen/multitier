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
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbDescrip.Text.Length >= 45)
            {
                lblMessage.Text = "Description must be shorter";
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["QA"].ConnectionString);
                string qry = "INSERT INTO Bugs(EnteredBy,subject,priority,description,status) VALUES(@id,@subject,@prior,@descrip,@status);";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@id", Session["id"]);
                cmd.Parameters.AddWithValue("@subject", tbSubject.Text);
                cmd.Parameters.AddWithValue("@prior", ddlPriority.SelectedValue);
                cmd.Parameters.AddWithValue("@descrip", tbDescrip.Text);
                cmd.Parameters.AddWithValue("@status", "Open");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Text = "Added " + tbSubject.Text + " to database";
                ClearTextBoxes();
            }
            
        }

        protected void ClearTextBoxes()
        {
            tbSubject.Text = "";
            tbDescrip.Text = "";
            ddlPriority.SelectedValue = "Low";
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}