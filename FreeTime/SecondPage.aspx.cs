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
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            Response.AddHeader("refresh", "1; url=FirstForm.aspx");
             //Server.Transfer("FirstForm.aspx", true);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var UsernameValue = UserTextBox.Text;
            var ageValue = Convert.ToInt32(DropDownListAge.SelectedValue);
            var jobValue = TextBoxJob.Text;
            var passwordValue = PasswordTextBox.Text;
            var nameValue = NameTextBox.Text;
            var emailValue = TextBoxEmail.Text;



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
                string insertString = "insert into Users (Username, Name, Age,job,Password, Email) values (@UserName,@Name,@Age,@Job,@Password,@Email)";
                SqlCommand comd2 = new SqlCommand(insertString, conn2);
                comd2.Parameters.AddWithValue("@Username", UsernameValue);
                comd2.Parameters.AddWithValue("@Name", nameValue);
                //comd.Parameters.AddWithValue("@Email", email);
                //comd.Parameters.AddWithValue("@Country", country);
                //comd.Parameters.AddWithValue("@Password", EncryptPassword.encryptString(password));
                //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                comd2.Parameters.AddWithValue("@Age", ageValue);
                comd2.Parameters.AddWithValue("@Job", jobValue);
                comd2.Parameters.AddWithValue("@Email", emailValue);
                comd2.ExecuteNonQuery();
                conn2.Close();
                WarningLabel.Text = "user has been created";
                //Response.AddHeader("refresh", "4; url=Login.aspx");
                Server.Transfer("Login.aspx", true);

            }
            //dr.Close();
            //conn.Close();

            //return false;





            /////////////

            ////////SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);


            ///////conn.Open();
            //string insertString = "insert into Customer (UserName, Name, Password,Age) values (@userName,@Name,@Password,@Age,)";
            ////////string insertString = "insert into Users (UserName, Name, Age,job,Password) values (@UserName,@Name,@Age,@Job,@Password)";
            ///////SqlCommand comd = new SqlCommand(insertString, conn);
            ///////comd.Parameters.AddWithValue("@UserName", UsernameValue);
           ///////// comd.Parameters.AddWithValue("@Name", nameValue);
            //comd.Parameters.AddWithValue("@Email", email);
            //comd.Parameters.AddWithValue("@Country", country);
            //comd.Parameters.AddWithValue("@Password", EncryptPassword.encryptString(password));
            /////////comd.Parameters.AddWithValue("@Password", passwordValue);
            //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
          /// // comd.Parameters.AddWithValue("@Age", ageValue);
           ////// comd.Parameters.AddWithValue("@Job", jobValue);
           /////// comd.ExecuteNonQuery();
            ///////conn.Close();
        }
    }
}