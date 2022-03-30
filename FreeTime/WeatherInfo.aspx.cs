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

namespace FreeTime
{
    public partial class WeatherInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {

                Response.Redirect("Login.aspx");

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string weatherKey2 = System.Configuration.ConfigurationManager.AppSettings["weatherKey2"];
                var zipCode = TextBox1.Text.ToString();
                Panel1.ContentTemplateContainer.Controls.Clear();
                //Response.Write(zipCode);
                var url = "https://samples.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + weatherKey2;
                //var url = "https://samples.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&units=imperial";
                //https://openweathermap.org/current#data
                var json = new WebClient().DownloadString(url);
                //https://www.thoughtco.com/convert-kelvin-to-fahrenheit-609234
                // temputure conercance
                Console.WriteLine(json);
                var news = JsonConvert.DeserializeObject<JSONEWS>(json);
                JObject jObject = JObject.Parse(json);
                Label newLabel = new Label();

                Label newLabel2 = new Label();
                Label newLabel3 = new Label();
                Label newLabel4 = new Label();
                Label newLabel5 = new Label();
                Label newLabel6 = new Label();

                string filePath = "Images/";

                Image IconImage = new Image();
                //IconImage.ImageUrl ="Images/09d.png";
                IconImage.ImageUrl = filePath + jObject["weather"][0]["icon"].ToString() + ".png";
                // IconImage.Width = 600;
                //IconImage.Height = 400;

                Panel1.ContentTemplateContainer.Controls.Add(IconImage);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));


                newLabel.Text = "<p class='f'> The weather info for " + zipCode + "</p>";
                newLabel2.Text = "<p class='f'> The weather forcast is " + jObject["weather"][0]["main"].ToString() + "</p>";

                Panel1.ContentTemplateContainer.Controls.Add(newLabel2);
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                //newLabel3.Text = "The weather forcast is " + jObject["weather"][0]["description"].ToString();
                newLabel3.Text = "<p class='f'>The weather will be  " + jObject["weather"][0]["description"].ToString() + "</p>";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel3);
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                decimal maxTemp = (System.Convert.ToDecimal(jObject["main"]["temp_max"].ToString()) * (9 / 5)) - Convert.ToDecimal(459.67);

                decimal maxTemp2 = System.Convert.ToDecimal(jObject["main"]["temp_max"].ToString());
                //int maxTemp2I = System.Convert.ToInt32(jObject["main"]["temp_max"].ToString());
                //decimal maxTemp3 = (maxTemp2 * Convert.ToDecimal(9 / 5));
                decimal maxTemp3 = (maxTemp2 * Convert.ToDecimal(1.8));
                decimal maxTemp3T = (maxTemp2 - Convert.ToDecimal(273.15));
                // double maxTemp3I = (maxTemp2I * (1.8));
                decimal maxTemp4 = maxTemp3 - Convert.ToDecimal(459.67);
                decimal maxTemp4T = (maxTemp3T * (9 / 5));
                maxTemp4T = maxTemp4T + 32;
                //int maxTemp4I = Convert.ToInt32(maxTemp3I -460);
                maxTemp = maxTemp4;
                decimal minTemp = Convert.ToDecimal(jObject["main"]["temp_min"].ToString());
                decimal minTemp2 = (minTemp * Convert.ToDecimal(1.8));
                decimal minTemp2T = (minTemp - Convert.ToDecimal(273.15));
                decimal minTemp3 = minTemp2 - Convert.ToDecimal(459.67);
                decimal minTemp3T = (minTemp2T * (9 / 5));
                minTemp3T = minTemp3T + 32;
                newLabel4.Text = "<p class='f'>The high is " + maxTemp4T.ToString() + " degrees Fahrenheit</p>";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel4);
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel5.Text = "<p class='f'>The low is " + minTemp3T.ToString() + " degrees Fahrenheit</p>";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel5);
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                HyperLink weatherLink = new HyperLink();
                weatherLink.NavigateUrl = "https://openweathermap.org/";
                weatherLink.Text = "Using API from open weather maps";
                Panel1.ContentTemplateContainer.Controls.Add(weatherLink);

            }
            catch
            {
                Label newLabel2 = new Label();

                newLabel2.Text = "<p class='f'> Try another zip code </p>";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel2);
            }


        }
    }
}