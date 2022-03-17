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


            string newsKeys = System.Configuration.ConfigurationManager.AppSettings["newsKey"];
            var url = "https://newsapi.org/v2/top-headlines?" +
          "sources=usa-today&" +
          newsKeys;
            string[] newsarray = new string[50];

            //Temp added 
            WebClient client = new WebClient();
            // Optionally specify an encoding for uploading and downloading strings.
            client.Encoding = System.Text.Encoding.UTF8;

            //https://stackoverflow.com/questions/22974169/json-net-deserializeobject-text-encoding
            //https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.encoding?view=net-6.0
            //var json = new WebClient().DownloadString(url);//temp removed

            var json = client.DownloadString(url);
            //Console.WriteLine(json);
            var news = JsonConvert.DeserializeObject<JSONEWS>(json);
            JObject jObject = JObject.Parse(json);



            // Response.Write(" number of articles " + jObject["articles"].Count());

            ////////////////////////////////
            ///

            //string praticeString = "hi";
            Label newLabel8 = new Label();
            newLabel8.Text = " Number of articles " + jObject["articles"].Count().ToString();

            Panel1.ContentTemplateContainer.Controls.Add(newLabel8);

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
            //tried this
            //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl(praticeString));


            Label newLabel7 = new Label();




            newLabel7.Text = "New News Artcles";
            Panel1.ContentTemplateContainer.Controls.Add(newLabel7);

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
            Label newLabel6 = new Label();

            int t = 0;
            //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            while (t < jObject["articles"].Count())
            {

                ///////////////////////////////////
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='background'  style='background-color:white; border-radius:15px'>"));


                string titleName2 = "";

                Label newLabel = new Label();
                Label newLabel2 = new Label();
                Label newLabel3 = new Label();
                Label newLabel4 = new Label();
                Label newLabel5 = new Label();
                //Label newLabel6 = new Label();
                //Label newLabel7 = new Label();

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));


                //newLabel7.Text = "New News Artcles";
                //Panel1.ContentTemplateContainer.Controls.Add(newLabel7);

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                //Label newLabel8 = new Label();
                //newLabel8.Text = " Number of articles " + jObject["articles"].Count().ToString();

                //Panel1.ContentTemplateContainer.Controls.Add(newLabel8);

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));



                /////newLabel.Text = jObject["articles"][t]["title"].ToString();
                //newLabel.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " class='link hvr-float' width='100%' max-width='100%' word-wrap='break-word'  color='black' >" + "<p text-decoration-line='underline'>" + jObject["articles"][t]["title"].ToString() + "</p>"+"</a>";
                //newLabel.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " class='link hvr-float' width='100%' max-width='650px' word-wrap='break-word'  color='black' >" + "<p style='text-decoration-line:underline;'>" + jObject["articles"][t]["title"].ToString() + "</p>" + "</a>";

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='hvr-float' width='100%' max-width='650px' style='background-color:purple" + "; >"));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div style='background-color:purple; border-style:solid; border-width:15px; border-color: purple;' " + " >"));
                newLabel.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " width='100%' max-width='650px' word-wrap='break-word' >" + "<p style='text-decoration-line:underline; color:white; background-color:purple; border-style:solid; border: 15px purple;text-align:center; font-size:20px' class='hvr-float'   >" + jObject["articles"][t]["title"].ToString() + "</p>" + "</a>";
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));
                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                Image weatherImage2 = new Image();
                if (jObject["articles"][t]["urlToImage"].ToString() != "")
                {

                    weatherImage2.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();
                    weatherImage2.AlternateText = "Image not available ";
                    //weatherImage2.AlternateText = jObject["articles"][t]["urlToImage"].ToString();

                }
                else
                {
                    weatherImage2.ImageUrl = "images/no-image-icon-23489.png";
                    weatherImage2.AlternateText = "Image not available ";
                }
                //weatherImage2.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();
                //weatherImage2.Width = 300;
                //weatherImage2.Height = 200;
                //weatherImage2.CssClass = "picture";
                //weatherImage2.CssClass = "img-fluid";
                weatherImage2.CssClass = "img-responsive";


                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
         
                Panel1.ContentTemplateContainer.Controls.Add(weatherImage2);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));


                newLabel2.Text =jObject["articles"][t]["description"].ToString();
                //newLabel2.Text = "<ul> <ul>" + newLabel2.Text;

                int listOpen2 = Regex.Matches(newLabel2.Text, "<li>").Count;
                int listClose2 = Regex.Matches(newLabel2.Text, "</li>").Count;

                while (listClose2 < listOpen2)
                {
                    string closeingString = newLabel2.Text.ToString();
                    closeingString = closeingString + "</li>";
                    listClose2++;
                    newLabel2.Text = closeingString;
                }


                //string newsString = "<p>" + jObject["articles"][t]["description"].ToString() + "<p>";
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

                // Panel1.ContentTemplateContainer.Controls.Add(newsString);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

                //https://stackoverflow.com/questions/18157620/responsive-solution-for-long-urls-that-exceed-the-device-width
                //newLabel3.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " width='100%'>" + jObject["articles"][t]["url"].ToString() + "</a>";
                //newLabel3.Text = "<div style='word-wrap: break-word; max-width:100p% '   ><a href=" + jObject["articles"][t]["url"].ToString() + " class='link hvr-float' width='100%' max-width='100%' word-wrap='break-word'>" + jObject["articles"][t]["url"].ToString() + "</a></div>";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

               /////// Panel1.ContentTemplateContainer.Controls.Add(newLabel3);

                /////Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                //////Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                newLabel4.Text = jObject["articles"][t]["publishedAt"].ToString();


                Panel1.ContentTemplateContainer.Controls.Add(newLabel4);

               // Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel5.Text = jObject["articles"][t]["content"].ToString();



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

                Uri uriLink = new Uri(jObject["articles"][t]["url"].ToString());

                //Image weatherImage1 = new Image();
                //weatherImage1.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();


                t++;

                //newLabel6.Text = "powered by newsapi.org";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                //Panel1.ContentTemplateContainer.Controls.Add(newLabel6);

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                //ether add more white space or add a div with a color so it looks like a line
                ////////////////////////////////////////////////
                ///

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

            }

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
            newLabel6.Text = "powered by newsapi.org";
                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

                Panel1.ContentTemplateContainer.Controls.Add(newLabel6);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));

            //////newslabel.Text = titleNames;





        }
    }
}