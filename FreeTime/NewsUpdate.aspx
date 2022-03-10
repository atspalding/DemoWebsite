<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsUpdate.aspx.cs" Inherits="FreeTime.NewsUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" >
    
<head runat="server">
    <!--<meta property="og:locale" content="en" />-->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <title>News Update</title>
    <link rel="stylesheet" href="css/NewsUpdate.css" />
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
<body class="has-drawer container">

    
    
    <div id="nav-placeholder">


    </div>
    
    <script>
        $(function () {
            $("#nav-placeholder").load("Banner.html");


        });

    </script>
    <!-- start of removed code navebar-->
     
    
   <!-- end of added code nav bar-->

    <form id="form1" runat="server">
        <!-https://ianlunn.co.uk/articlej7/hover-css-tutorial-introduction/->
        
        <asp:Panel ID="NewsPanel" runat="server" max-height="400px">
            <!--<asp:Label ID="newslabel" runat="server" Text="newslabel"></asp:Label>-->
            <div  style='float:left; vertical-align: top; max-width: 900px;' >
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <!--<asp:Panel ID="Panel3" runat="server" Width="900px">
            </asp:Panel>-->
                <!--changed panel1 id to panel 3 for now-->
                <!--https://ajax.net-tutorials.com/controls/updatepanel-control/-->
                <!--https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.updatepanel.updatemode?view=netframework-4.7.2-->
             <asp:UpdatePanel runat="server" id="Panel1" updatemode="Conditional" max-width="900px" >

             </asp:UpdatePanel>

            </div>
            </asp:Panel>
        <!--<asp:Label ID="Label2" runat="server" Text="powered by newsapi.org"></asp:Label>-->
    </form>

        <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>

</body>
</html>
