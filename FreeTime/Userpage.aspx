<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Userpage.aspx.cs" Inherits="FreeTime.Userpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User page</title>
      <link rel="stylesheet" href="css/sortingStyle.css" />

    <link rel="stylesheet" href="css/frontStyle.css" />

    <link href="http://netdna.bootstrap.min.css" rel="stylesheet" />
    
    


    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    
      <div id="google_translate_element"></div>
    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script> 
     <script type="text/javascript">
function googleTranslateElementInit() {
new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
}
</script> 
     <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>

    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Job" HeaderText="Job" SortExpression="Job" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:freeTimeConnection %>" SelectCommand="SELECT [Name], [Username], [Age], [Job], [Email] FROM [Users] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:SessionParameter Name="Username" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    <!-- 1. The <iframe> (and video player) will replace this <div> tag. -->
    <div id="player"></div>
    <!-- added youtube api-->
    <script>
        // 2. This code loads the IFrame Player API code asynchronously.
        var tag = document.createElement('script');

        tag.src = "https://www.youtube.com/iframe_api";
        var firstScriptTag = document.getElementsByTagName('script')[0];
        firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

        // 3. This function creates an <iframe> (and YouTube player)
        //    after the API code downloads.
        var player;
        function onYouTubeIframeAPIReady() {
            player = new YT.Player('player', {
                height: '390',
                width: '640',
                videoId: 'M7lc1UVf-VE',
                events: {
                    'onReady': onPlayerReady,
                    'onStateChange': onPlayerStateChange
                }
            });
        }

        // 4. The API will call this function when the video player is ready.
        function onPlayerReady(event) {
            event.target.playVideo();
        }

        // 5. The API calls this function when the player's state changes.
        //    The function indicates that when playing a video (state=1),
        //    the player should play for six seconds and then stop.
        var done = false;
        function onPlayerStateChange(event) {
            if (event.data == YT.PlayerState.PLAYING && !done) {
                //setTimeout(stopVideo, 6000);
                done = true;
            }
        }
        function stopVideo() {
            player.stopVideo();
        }



        // Sample js code for videos.list

        // See full sample for buildApiRequest() code, which is not 
        // specific to a particular API or API method.
        ////below code might not work
        buildApiRequest('GET',
            '/youtube/v3/videos',
            {
                'id': 'Ks-_Mh1QhMc',
                'part': 'snippet,contentDetails,statistics'
            });
    </script>
    <p></p>
    <button onclick="getLocation()">Try It</button>

    <p id="demo"></p>

<script>
        var x = document.getElementById("demo");

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            x.innerHTML = "Latitude: " + position.coords.latitude +
                "<br>Longitude: " + position.coords.longitude;
        }
        this.geolocation();
</script>

        <asp:LinkButton ID="LinkButton1" runat="server">sortingPage</asp:LinkButton>
    </form>

    </body>
</html>
