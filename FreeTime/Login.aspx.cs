using FreeTimeWebsite.App_Code;
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

namespace FreeTimeWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            var UsernameValue = UsernameTextBox.Text;

            var passwordValue = PasswordTextBox.Text;


            Userutil myUser = new Userutil(UsernameValue, passwordValue);

            if (myUser.checkPassword())
            {
                Session["user"] = UsernameTextBox.Text;
                
                LoginLabel.Text = "user in database";
                Response.Redirect("AdventureGame.aspx");
            }
            else
            {
               
                LoginLabel.Text = "username or password is not correct !";
                
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            var UsernameValue = UsernameTextBox.Text;

            var passwordValue = PasswordTextBox.Text;


            Session["User"] = UsernameValue;
            //Response.AddHeader("refresh", "1; url=AdventureGame.aspx");
            //   Server.Transfer("AdventureGame.aspx", true);
            Response.Redirect("AdventureGame.aspx");

        }



            protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {


            var UsernameValue = Login1.UserName;

            var passwordValue = Login1.Password;



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
                    Session["User"] = UsernameValue;
                    //Response.AddHeader("refresh", "1; url=AdventureGame.aspx");
                    //Server.Transfer("AdventureGame.aspx", true);
                    Response.Redirect("AdventureGame.aspx");
                    e.Authenticated = true;
                }
                else
                {
                    LoginLabel.Text = "Wrong password or username";
                }
            }
            else
            {
                LoginLabel.Text = "Wrong password or username";
            }
            dr.Close();
            conn.Close();


        }
    }
}