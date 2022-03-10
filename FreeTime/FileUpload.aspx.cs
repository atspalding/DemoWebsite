using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dropbox.Api;
using System.Threading.Tasks;

namespace FreeTime
{

    public partial class FileUpload : System.Web.UI.Page
    {


        //
        public static string dropboxString;

        //
        protected async Task Page_LoadAsync(object sender, EventArgs e)
        {
            // top used to be 
            //protected void Page_Load(object sender, EventArgs e)

            //////////////
            

            //var task = Task.Run((Func<Task>)Program.Run);
            //task.Wait();
            await Run();

            /////////////

            string[] fileArray = System.IO.Directory.GetFiles(@"C:\Users\adamt\source\repos\FreeTime\FreeTime\fileFolder\");
            int i = 0;
            String lengthOfString= @"C:\Users\adamt\source\repos\FreeTime\FreeTime\fileFolder\";
            int StringLength = lengthOfString.Length;

            WebClient Client = new WebClient();
            while (i < fileArray.Length)
            {
                Button linkButton = new Button();
                Label label = new Label();
                String subString = fileArray[i].Substring(StringLength);
                //label.Text = fileArray[i];
                label.Text = subString;
                linkButton.Text = subString;
                 String downloadString = "@" + fileArray[i];
                /////////////////////String downloadString = "file:///c:/path/to/the%20file.txt;
                //String downloadString = "file:///"+fileArray[i];


                //linkButton.OnClientClick = Client.DownloadFile(downloadString, subString);
                


                OutputPanel.Controls.Add(label);
                OutputPanel.Controls.Add(linkButton);
                i++;
            }
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            String savePath = @"C:\Users\adamt\source\repos\FreeTime\FreeTime\fileFolder\";
            if (FileUploader.HasFile)
            {
                String fileName = FileUploader.FileName;
                savePath += fileName;
                FileUploader.SaveAs(savePath);
                uploadLabel.Text = "File has been uploaded";
                //uploadLabel.Text = dropboxString;
            }
            else
            {
                uploadLabel.Text = "No file selected";
            }
        }


        //https://www.dropbox.com/developers/documentation/dotnet#tutorial

        static async Task Run()
        {
            using (var dbx = new DropboxClient("ns3b37hrllz2so7"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);

                Console.WriteLine(full.Name.DisplayName);
                // FileUpload.uploadLabel.Text = "hi";
                dropboxString = full.Name.DisplayName;
                dropboxString=full.Email;
                //this site might help set up dropbox
                //https://temboo.com/csharp/upload-to-dropbox
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }



        ////////////////




        ///////////
    }
}