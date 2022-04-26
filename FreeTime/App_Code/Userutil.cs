using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FreeTimeWebsite.App_Code
{



    public class Userutil
    {

        public string userName { get; set; }
       
        public string password { get; set; }
        

        public Userutil(string username, string password)
        {
            this.userName = username;
            this.password = password;
        }
        public Userutil()
        {

        }
        public void insertUser()
        {

            /////////////
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            ///
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@userName", this.userName);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                conn.Close();
                
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
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(this.password));
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
                comd2.Parameters.AddWithValue("@Username", this.userName);
                
                comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
               
                comd2.ExecuteNonQuery();
                conn2.Close();
          
  

            }
        }
        public bool checkUserExist()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@UserName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@UserName", this.userName);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                conn.Close();
                return true;
            }
            dr.Close();
            conn.Close();

            return false;
        }
        public bool checkPassword()
        {
            EncryptPassword Encrypt = new EncryptPassword();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@userName", this.userName);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                //
                dr.Read();
                if (dr["Password"].ToString().Equals(Encrypt.encryptString(password)))//changed password to 123456
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
            }
            dr.Close();
            conn.Close();

            return false;
        }//close last method
        //start of get new user and email
        /////////////////////////
        ///
        public Userutil getUser(string userName)
        {
            Userutil customer = new Userutil();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where Username=@UserName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@userName", userName);
            SqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                customer.userName = dr[0].ToString();
                customer.password = dr[4].ToString();
                
            }
            dr.Close();
            conn.Close();
            return customer;
        }


        //////////////////////
        ///
        public void resetPassword(string newpwd)
        {
            EncryptPassword Encrypt = new EncryptPassword();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["pizzaDB"].ConnectionString);
            conn.Open();
            string checkUser = "update Users set Users.Password = @password where Users.Username = @userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@userName", userName);
            comd.Parameters.AddWithValue("@password", Encrypt.encryptString(newpwd));
            comd.ExecuteNonQuery();
            conn.Close();
        }



    }
}