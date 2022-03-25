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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            var UsernameValue = UsernameTextBox.Text;
            //var ageValue = Convert.ToInt32(DropDownListAge.SelectedValue);
            //var jobValue = TextBoxJob.Text;
            var passwordValue = PasswordTextBox.Text;
            //var nameValue = NameTextBox.Text;
            //var emailValue = TextBoxEmail.Text;



            /////////////
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            ///
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@userName", UsernameValue);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                conn.Close();
                // return true;
                WarningLabel.Text = "That user already exist try again";
            }
            else
            {

                dr.Close();
                conn.Close();

                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);


                conn2.Open();





                //////////////////////

                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordValue));
                byte[] result = md5.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }






                //////////////////////////
                //string insertString = "insert into Customer (UserName, Name, Password,Age) values (@userName,@Name,@Password,@Age,)";
                string insertString = "insert into Users (Username,Password) values (@UserName,@Password)";
                SqlCommand comd2 = new SqlCommand(insertString, conn2);
                comd2.Parameters.AddWithValue("@Username", UsernameValue);
                //comd2.Parameters.AddWithValue("@Name", nameValue);
                //comd.Parameters.AddWithValue("@Email", email);
                //comd.Parameters.AddWithValue("@Country", country);
                //comd.Parameters.AddWithValue("@Password", EncryptPassword.encryptString(password));
                //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                //comd2.Parameters.AddWithValue("@Age", ageValue);
                //comd2.Parameters.AddWithValue("@Job", jobValue);
                //comd2.Parameters.AddWithValue("@Email", emailValue);
                comd2.ExecuteNonQuery();
                conn2.Close();
                WarningLabel.Text = "user has been created";
                //Response.AddHeader("refresh", "4; url=Login.aspx");
                //Server.Transfer("Login.aspx", true);
                Response.Redirect("Login.aspx");

            }


        }
    }
}