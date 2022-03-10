using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTime
{
    public partial class ProgressBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProgressBar pBar = new ProgressBar();
            //pBar.Location = new System.Drawing.Point(20, 20);
            //pBar.Name = "progressBar1";
            //pBar.Width = 200;
            //pBar.Height = 30;

            Controls.Add(pBar);
        }
    }
}