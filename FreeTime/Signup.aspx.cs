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
using FreeTimeWebsite.App_Code;

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
         
            var passwordValue = PasswordTextBox.Text;
           

            Userutil myUser = new Userutil(UsernameValue,passwordValue);

            if (!myUser.checkUserExist())
            {
                myUser.insertUser();
                

                WarningLabel.Text = "user has been created";
            
                Response.Redirect("Login.aspx");

            }
            else
            {
                WarningLabel.Text = "That user already exist try again";
               
            }

           

        }
    }
}