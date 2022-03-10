using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTime
{
    public partial class Userpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (Session["user"] == null)
            {
                // Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first') Windows.location='Login.aspx';</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                var username = Session["user"].ToString();
            }
            
        }
    }
}