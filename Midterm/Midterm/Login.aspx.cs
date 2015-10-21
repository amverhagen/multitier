using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Midterm
{
    public partial class Login : System.Web.UI.Page
    {
        string username;
        string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 30;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        protected void AttemptLogin()
        {
            username = tbUsername.Text;
            password = tbPassword.Text;
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["QA"].ConnectionString);
            string qry = "select password,type,employeeid from employee where login=@username";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@username", username);
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }
                if (reader.GetString(0).Equals(strBuilder.ToString()))
                {
                    Session["user"] = username;
                    Session["type"] = reader.GetString(1);
                    Session["id"] = reader.GetValue(2);
                    lblMessage.Text = "Successful";
                    if (Session["type"].Equals("Tester"))
                    {
                        Response.Redirect("Tester.aspx");
                    }
                    else if(Session["type"].Equals("Developer")){
                        Response.Redirect("Developer.aspx");
                    }
                    else if (Session["type"].Equals("Manager"))
                    {
                        Response.Redirect("Manager.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "User is not assigned an access level";
                    }
                }
                else
                {
                    lblMessage.Text = "Incorrect username and password";
                }
            }
            else
            {
                lblMessage.Text = "Incorrect username and password";
            }
            reader.Close();
            conn.Close();
        }
    }
}