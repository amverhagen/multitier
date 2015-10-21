using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ProtoFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        protected void AttemptLogin()
        {
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);
            conn.Open();
            string query = "select user_password,user_id from users where user_name=@username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username_tb.Text);
            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                SHA1Managed sha1 = new SHA1Managed();
                sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password_tb.Text));
                byte[] result = sha1.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }

                if (reader["user_password"].ToString().Equals(strBuilder.ToString()))
                {
                    Session["userid"] = reader["user_id"].ToString();
                    Response.Redirect("Shop.aspx");
                }
                else
                {
                    info_lbl.Text = "Incorrect username or password";
                }
            }
            else
            {
                info_lbl.Text = "Incorrect username or password";
            }
            reader.Close();
            conn.Close();
        }
    }
}