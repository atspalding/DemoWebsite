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
    public partial class NewsSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string newsKeys = System.Configuration.ConfigurationManager.AppSettings["newsKey"];
            var url = "https://newsapi.org/v2/top-headlines?" +
          "sources=usa-today&" +
          newsKeys;
            string[] newsarray = new string[50];

            var json = new WebClient().DownloadString(url);
            
            Console.WriteLine(json);
            var news= JsonConvert.DeserializeObject<JSONEWS>(json);
            JObject jObject = JObject.Parse(json);



            // Response.Write(" number of articles " + jObject["articles"].Count());

            ////////////////////////////////
            ///

            Label newLabel8 = new Label();
            newLabel8.Text = " Number of articles " + jObject["articles"].Count().ToString();

            Panel1.ContentTemplateContainer.Controls.Add(newLabel8);

            Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

            int t = 0;
        
            while (t < jObject["articles"].Count()){

               
                string titleName2 = "";

                Label newLabel = new Label();
                Label newLabel2 = new Label();
                Label newLabel3 = new Label();
                Label newLabel4 = new Label();
                Label newLabel5 = new Label();
                Label newLabel6 = new Label();
                Label newLabel7 = new Label();




                newLabel7.Text = "New News Artcles";
                Panel1.ContentTemplateContainer.Controls.Add(newLabel7);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

               // Label newLabel8 = new Label();
                //newLabel8.Text = " Number of articles " + jObject["articles"].Count().ToString();

                //Panel1.ContentTemplateContainer.Controls.Add(newLabel8);

                //Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));



                newLabel.Text = jObject["articles"][t]["title"].ToString();
                Panel1.ContentTemplateContainer.Controls.Add(newLabel);
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                Image weatherImage2 = new Image();
                weatherImage2.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();
                weatherImage2.Width = 600;
                weatherImage2.Height = 400;

                Panel1.ContentTemplateContainer.Controls.Add(weatherImage2);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
               

                newLabel2.Text =jObject["articles"][t]["description"].ToString();

                Panel1.ContentTemplateContainer.Controls.Add(newLabel2);
               

                newLabel3.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " class='link hvr-float' >" + jObject["articles"][t]["url"].ToString() + "</a>";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel3);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel4.Text = jObject["articles"][t]["publishedAt"].ToString();
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel4);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel5.Text= jObject["articles"][t]["content"].ToString();
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel5);

                Uri uriLink = new Uri(jObject["articles"][t]["url"].ToString());
            
                Image weatherImage1 = new Image();
                weatherImage1.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();

                
                t++;
               
                newLabel6.Text = "powered by newsapi.org";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel6);
                
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
              
                //ether add more white space or add a div with a color so it looks like a line

            }
            
            //////newslabel.Text = titleNames;
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
           


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            string newsKeys = System.Configuration.ConfigurationManager.AppSettings["newsKey"];
            TextBox2.Visible = false;
            Button4.Visible = false;
            var url = "https://newsapi.org/v2/top-headlines?" +
         "sources=usa-today&" +
         newsKeys; 
            string[] newsarray = new string[50];

            var json = new WebClient().DownloadString(url);

            Console.WriteLine(json);
            var news = JsonConvert.DeserializeObject<JSONEWS>(json);
            JObject jObject = JObject.Parse(json);



            //Response.Write(" number of articles " + jObject["articles"].Count());
            

            ////////////////////////////////
            int t = 0;
            while (t < jObject["articles"].Count())
            {

               
                string titleName2 = "";

                Label newLabel = new Label();
                Label newLabel2 = new Label();
                Label newLabel3 = new Label();
                Label newLabel4 = new Label();
                Label newLabel5 = new Label();
                Label newLabel6 = new Label();


                newLabel.Text = jObject["articles"][t]["title"].ToString();
                Panel1.ContentTemplateContainer.Controls.Add(newLabel);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
              
                Image weatherImage2 = new Image();
                weatherImage2.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();
                weatherImage2.Width = 600;
                weatherImage2.Height = 400;

                Panel1.ContentTemplateContainer.Controls.Add(weatherImage2);
                
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
              

                newLabel2.Text = jObject["articles"][t]["description"].ToString();

                Panel1.ContentTemplateContainer.Controls.Add(newLabel2);
                

                newLabel3.Text = "<a href=" + jObject["articles"][t]["url"].ToString() + " class='link hvr-float' >" + jObject["articles"][t]["url"].ToString() + "</a>";
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel3);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel4.Text = jObject["articles"][t]["publishedAt"].ToString();
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel4);
               
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                newLabel5.Text = jObject["articles"][t]["content"].ToString();
                
                Panel1.ContentTemplateContainer.Controls.Add(newLabel5);

                Uri uriLink = new Uri(jObject["articles"][t]["url"].ToString());

                Image weatherImage1 = new Image();
                weatherImage1.ImageUrl = jObject["articles"][t]["urlToImage"].ToString();


                t++;
                
                newLabel6.Text = "powered by newsapi.org";

                
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
               
                Panel1.ContentTemplateContainer.Controls.Add(newLabel6);
                
                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                // Panel1.Controls.Add(new LiteralControl("<br />"));
                //ether add more white space or add a div with a color so it looks like a line




            }



            }

        protected void Button3_Click(object sender, EventArgs e)
        {
             
          
            Panel1.ContentTemplateContainer.Controls.Clear();
            TextBox2.Visible = true;
            Button4.Visible = true;
            


            //////////////////////https://www.c-sharpcorner.com/uploadfile/mahesh/creating-a-button-at-run-time-in-C-Sharp/
          



            /////////////////https://stackoverflow.com/questions/6803073/get-local-ip-address

            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                string ipKey = System.Configuration.ConfigurationManager.AppSettings["ipKey"];
                int ipKey2 = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ipKey2"]);
                socket.Connect(ipKey, ipKey2);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();

            }



            //////////////////////https://www.c-sharpcorner.com/UploadFile/167ad2/get-ip-address-using-C-Sharp-code/

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string urlKey = System.Configuration.ConfigurationManager.AppSettings["urlKey"]+"&format=1";
            var url2 =urlKey;
           

            string weatherKey2 = System.Configuration.ConfigurationManager.AppSettings["weatherKey2"];
            var json2= new WebClient().DownloadString(url2);
            JObject jObject2 = JObject.Parse(json2);
            string locationString = jObject2["city"].ToString();
            ///https://www.c-sharpcorner.com/UploadFile/167ad2/get-ip-address-using-C-Sharp-code/

            var url = "https://api.openweathermap.org/data/2.5/weather?q="+locationString+"&appid="+weatherKey2;
            var json = new WebClient().DownloadString(url);
            Console.WriteLine(json);
            JObject jObject = JObject.Parse(json);
            Label newLabel = new Label();
            ////Response.Write(" number of weather " + jObject["coord"].Count());
            Response.Write("Input a zipcode and then click the button");


        }


        /////////////////////////////////////////////////////
        protected void ButtonZip_Click(object sender, EventArgs e)
        {

            //Button dynamicButton = sender as Button;
            Response.Write("zip code entered");
            Panel1.ContentTemplateContainer.Controls.Clear();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            try
            {
                string weatherKey2 = System.Configuration.ConfigurationManager.AppSettings["weatherKey2"];
                var zipCode = TextBox2.Text.ToString();
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

                string filePath ="Images/";

                Image IconImage = new Image();
                //IconImage.ImageUrl ="Images/09d.png";
                IconImage.ImageUrl =filePath+ jObject["weather"][0]["icon"].ToString()+".png";
                // IconImage.Width = 600;
                //IconImage.Height = 400;

                Panel1.ContentTemplateContainer.Controls.Add(IconImage);

                Panel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));



                newslabel.Text = "<p class='f'> The weather info for " + zipCode + "</p>";
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
                decimal maxTemp3T = (maxTemp2-Convert.ToDecimal(273.15));
                // double maxTemp3I = (maxTemp2I * (1.8));
                decimal maxTemp4 = maxTemp3 - Convert.ToDecimal(459.67);
                decimal maxTemp4T = (maxTemp3T*(9/5));
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
                //newLabel5.Text = jObject["weather"][0]["icon"].ToString();
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.AddHeader("refresh", "0; url=SortingPage.aspx");
        }



        /////////////////////////////////////////////////
    }
}