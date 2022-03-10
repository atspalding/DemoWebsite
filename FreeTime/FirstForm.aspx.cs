using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTime
{
    public partial class FirstForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var textValue = TextBox1.Text;
            string textInput = "you inputed "+textValue+" into the text box";
            textValueLabel.Text = textInput;


    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("SecondPage.aspx", true);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.AddHeader("refresh", "0; url=Login.aspx");
        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            Response.AddHeader("refresh", "0; url=SecondPage.aspx");
        }
    }
} 