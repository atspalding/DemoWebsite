using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace FreeTime
{
    public partial class NewsUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {
                
                Response.Redirect("Login.aspx");

            }


            string newsKeys = System.Configuration.ConfigurationManager.AppSettings["newsKey"];
            //var url ="https://newsapi.org/v2/top-headlines?sources=usa-today&apiKey="+newsKeys;
            //string url = "https://newsapi.org/v2/top-headlines?sources=usa-today&apiKey=" + newsKeys;
            var url = "https://api.nytimes.com/svc/topstories/v2/home.json?api-key=" +newsKeys;

            //string url2 = "https://newsapi.org/v2/top-headlines?" +
         // "sources=usa-today&" +
         // newsKeys;

            string[] newsarray = new string[50];

            //Temp added 
            WebClient client = new WebClient();
            // Optionally specify an encoding for uploading and downloading strings.
            client.Encoding = System.Text.Encoding.UTF8;

            //https://stackoverflow.com/questions/22974169/json-net-deserializeobject-text-encoding
            //https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.encoding?view=net-6.0
     

            var json = client.DownloadString(url);
            // var json = new WebClient().DownloadString(url);
            // var json2 = client.DownloadFile(url);
            
            //var news = JsonConvert.DeserializeObject<JSONEWS>(json);
            JObject jObject = JObject.Parse(json);



           
            Label newLabel8 = new Label();
            //newLabel8.Text = " Number of articles " + jObject["articles"].Count().ToString();
            newLabel8.Text = " Number of articles " + jObject["num_results"].ToString();

            Panel1.ContentTemplateContainer.Controls.Add(newLabel8);

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
            
            Label newLabel7 = new Label();

            newLabel7.Text = "New News Artcles";
            Panel1.ContentTemplateContainer.Controls.Add(newLabel7);

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
          
            Label newLabel6 = new Label();

            int t = 0;
            //while (t < jObject["articles"].Count())
            while (t < Convert.ToInt64(jObject["num_results"]))
            {

      
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='background'  style='background-color:white; border-radius:15px'>"));

                Label newLabel = new Label();
                Label newLabel2 = new Label();
                Label newLabel3 = new Label();
                Label newLabel4 = new Label();
                Label newLabel5 = new Label();
                Label newLabel9 = new Label();

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div style='background-color:purple; border-style:solid; border-width:15px; border-color: purple;' " + " >"));
                newLabel.Text = "<a href=" + jObject["results"][t]["url"].ToString() + " width='100%' max-width='650px' word-wrap='break-word' >" + "<p style='text-decoration-line:underline; color:white; background-color:purple; border-style:solid; border: 15px purple;text-align:center; font-size:20px' class='hvr-float'   >" + jObject["results"][t]["title"].ToString() + "</p>" + "</a>";
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                /////////////////////
                newLabel9.Text = jObject["results"][t]["byline"].ToString();

                Panel1.ContentTemplateContainer.Controls.Add(newLabel9);

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //////////////////
                Image weatherImage2 = new Image();
                if (jObject["results"][t]["multimedia"][0]["url"].ToString() != "")
                {

                    weatherImage2.ImageUrl = jObject["results"][t]["multimedia"][0]["url"].ToString();
                    //weatherImage2.AlternateText = "Image not available ";
                    weatherImage2.AlternateText = jObject["results"][t]["multimedia"][0]["caption"].ToString();

                }
                else
                {
                    weatherImage2.ImageUrl = "images/no-image-icon-23489.png";
                    weatherImage2.AlternateText = "Image not available ";
                }
                
                weatherImage2.CssClass = "img-responsive";


                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
         
                Panel1.ContentTemplateContainer.Controls.Add(weatherImage2);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //newLabel2.Text =jObject["results"][t]["title"].ToString();
                newLabel2.Text= jObject["results"][t]["multimedia"][0]["copyright"].ToString();

                int listOpen2 = Regex.Matches(newLabel2.Text, "<li>").Count;
                int listClose2 = Regex.Matches(newLabel2.Text, "</li>").Count;

                while (listClose2 < listOpen2)
                {
                    string closeingString = newLabel2.Text.ToString();
                    closeingString = closeingString + "</li>";
                    listClose2++;
                    newLabel2.Text = closeingString;
                }


              
                int listOpen=Regex.Matches(newLabel2.Text,"<ul>").Count;
                int listClose=Regex.Matches(newLabel2.Text,"</ul>").Count;
                while(listClose < listOpen)
                {
                    string closeingString = newLabel2.Text.ToString();
                    closeingString = closeingString + "</ul>";
                    listClose++;
                    newLabel2.Text = closeingString;
                }


                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel2);


                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //https://stackoverflow.com/questions/18157620/responsive-solution-for-long-urls-that-exceed-the-device-width
            
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                newLabel4.Text = "Published date <br/>"+jObject["results"][t]["published_date"].ToString();


                Panel1.ContentTemplateContainer.Controls.Add(newLabel4);

                newLabel5.Text = jObject["results"][t]["abstract"].ToString();
                
                //newLabel5.Text = jObject["results"][t]["multimedia"][0]["copyright"].ToString();



                int listOpen6 = Regex.Matches(newLabel5.Text, "<li>").Count;
                int listClose6 = Regex.Matches(newLabel5.Text, "</li>").Count;

                while (listClose6 < listOpen6)
                {
                    string closeingString = newLabel5.Text.ToString();
                    closeingString = closeingString + "</li>";
                    listClose6++;
                    newLabel5.Text = closeingString;
                }

                int listOpen5 = Regex.Matches(newLabel5.Text, "<ul>").Count;
                int listClose5 = Regex.Matches(newLabel5.Text, "</ul>").Count;
                while (listClose5 < listOpen5)
                {
                    string closeingString = newLabel5.Text.ToString();
                    closeingString = closeingString + "</ul>";
                    listClose5++;
                    newLabel5.Text = closeingString;
                }


                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                //start of added
                string divString = "<div style='height:4px;width:100%;background-color:black;'>";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl(divString));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));


                //end of added code
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                Panel1.ContentTemplateContainer.Controls.Add(newLabel5);

                // Uri uriLink = new Uri(jObject["articles"][t]["url"].ToString());
                //Uri uriLink = new Uri(jObject["results"][t]["url"].ToString());



                t++;

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
               

            }

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
            newLabel6.Text = "powered by New York Times api";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel6);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

            
        }
    }
}