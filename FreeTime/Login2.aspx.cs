using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTime
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            var UsernameValue = UsernameTextBox.Text;
            
            var passwordValue = PasswordTextBox.Text;



            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordValue));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }


            comd.Parameters.AddWithValue("@userName", UsernameValue);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                //
                dr.Read();
                if (dr["Password"].ToString().Equals(strBuilder.ToString()))
                {
                    dr.Close();
                    conn.Close();
                    LoginLabel.Text = "user in database";
                    Session["user"] = UsernameValue;
                    Response.AddHeader("refresh", "4; url=Userpage.aspx");
                }
                else
                {
                    LoginLabel.Text = "Wrong password or username";
                }
            }
            else
            {
                LoginLabel.Text = "try another username";
            }
            dr.Close();
            conn.Close();

        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            //Response.AddHeader("refresh", "4; url=SecondPage.aspx");

            Server.Transfer("SecondPage.aspx", true);
        }
    }
}