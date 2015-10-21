using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ProtoFinal
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            AttemptAccountCreation();
        }

        protected void AttemptAccountCreation()
        {
            string username;
            string password;

            username = username_tb.Text;
            password = password_tb.Text;

            if (username.Equals("") || password.Equals(""))
            {
                info_lbl.Text = "Must enter a username and password";
            }
            else
            {
                info_lbl.Text = "";
                SqlDataReader reader = null;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);
                conn.Open();
                string query = "select user_name from users where user_name=@username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    info_lbl.Text = "Username already taken please try a new one";
                    reader.Close();
                    conn.Close();
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
                    reader.Close();
                    query = "INSERT INTO users (user_name, user_password) VALUES (@username, @password)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", strBuilder.ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    info_lbl.Text = "Created account " + username;
                }
            }
        }
    }
}