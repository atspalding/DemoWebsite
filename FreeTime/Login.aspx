<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FreeTimeWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    

     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <title>Login</title>
    <link rel="stylesheet" href="css/Login.css" />
    <link href="css/hover.css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="css/frontStyle.css" />


    <link rel="stylesheet" href="css/bootstrap-drawer.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/introjs.css" />
     <link rel="stylesheet" href="css/liquid-slider.css" />
    <link rel="stylesheet" href="css/frontStyle.css" />
    <link rel="stylesheet" href="css/LogoLayout.css" />
    <link rel="stylesheet" href="css/NewsSite.css" />
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.touchswipe/1.6.4/jquery.touchSwipe.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!--<script src="js/bsuPizza.js"></script>temp added-->
    <script src="js/ckeditor_4.5.7_standard/ckeditor/ckeditor.js"></script>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>


</head>
<body class="has-drawer container"  >

    <div id="nav-placeholder">


    </div>
    <script>
        $(function () {
            $("#nav-placeholder").load("Banner.html");


        });

    </script>


    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <p>
            <asp:TextBox ID="UsernameTextBox" runat="server" ></asp:TextBox>
        </p>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <p>
            <asp:TextBox ID="PasswordTextBox" runat="server" ></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        <p>
            <asp:Label ID="LoginLabel" runat="server"></asp:Label>
        </p>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/AdventureGame.aspx" OnAuthenticate="Login1_Authenticate" Visible="False" VisibleWhenLoggedIn="False">
        </asp:Login>
    </form>

     <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>

</body>
</html>
