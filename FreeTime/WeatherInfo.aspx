<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeatherInfo.aspx.cs" Inherits="FreeTime.WeatherInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Weather Info</title>
    
    <!--<link rel="stylesheet" href="css/frontStyle.css" />-->
     <link rel="stylesheet" href="css/bootstrap-drawer.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/introjs.css" />
     <link rel="stylesheet" href="css/liquid-slider.css" />
    <link rel="stylesheet" href="css/frontStyle.css" />
    <link rel="stylesheet" href="css/LogoLayout.css" />
    <link rel="stylesheet" href="css/WeatherInfoStyle.css" />
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.touchswipe/1.6.4/jquery.touchSwipe.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!--<script src="js/bsuPizza.js"></script>temp added-->
    <script src="js/ckeditor_4.5.7_standard/ckeditor/ckeditor.js"></script>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>


</head>
<body class="has-drawer container">
   
    <div id="nav-placeholder">


    </div>
    
    <script>
        $(function () {
            $("#nav-placeholder").load("Banner.html");


        });

    </script>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter a zip code to get weather info"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br/>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
      
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="Panel1" runat="server">
        </asp:UpdatePanel>
        
    </form>

     <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>

</body>
</html>
