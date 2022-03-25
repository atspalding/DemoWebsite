<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdventureGame.aspx.cs" Inherits="FreeTime.AdventureGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--<meta property="og:locale" content="en" />-->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <title>Adventure game</title>
    <link rel="stylesheet" href="css/AdventureGame.css" />
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



    <style type="text/css">
        .auto-style2 {
            width: 196px;
            text-align: left;
            padding-bottom: 10px;
            padding-top: 10px;
        }
        .auto-style3 {
            width: 196px;
            padding-bottom:10px;
            padding-top:10px;
        }
    </style>



</head>

<body  class="has-drawer container" >

    <!--<iframe src="Banner.html"  scrolling="no"style="width: 100%; height: 100%; border: 0"></iframe>-->
    <?php
        include('Banner.php');
        ?>

    <div id="nav-placeholder">


    </div>
    <script>
        $(function () {
            $("#nav-placeholder").load("Banner.html");


        });

    </script>

    <form id="form1" runat="server">
       
        <asp:Panel ID="gamePanel" runat="server" Height="400px">
            <!--<asp:Label ID="newslabel" runat="server" Text="newslabel"></asp:Label>-->
            <div  style='float:left; vertical-align: top; width: 900px;' >
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <!--<asp:Panel ID="Panel3" runat="server" Width="900px">
            </asp:Panel>-->
                <!--changed panel1 id to panel 3 for now-->
                <!--https://ajax.net-tutorials.com/controls/updatepanel-control/-->
                <!--https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.updatepanel.updatemode?view=netframework-4.7.2-->
             <asp:UpdatePanel runat="server" id="Panel1" updatemode="Conditional" Width="900px"  >

                 
                
                 <ContentTemplate>
                     <asp:Label ID="Label1" runat="server" Text="Begin game"></asp:Label>
                     <br>
                     </br>
                     <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                     <br>
                     </br>
                     <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                 </ContentTemplate>

                 
             
             </asp:UpdatePanel>

            </div>
            </asp:Panel>
        <ContentTemplate>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     
                    </br>
                     <asp:Button ID="Button1" runat="server" Text="Action" OnClick="Button1_Click" UseSubmitBehavior="False" />
                 </ContentTemplate>

        <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>
        </br>

    </form>

        <table class="dw-xs-6">
            <tr>
                <td class="auto-style2"><strong>n</strong></td>
                <td class="text-left"><strong>Move north </strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>e</strong></td>
                <td class="text-left"><strong>Move East</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>s</strong></td>
                <td class="text-left"><strong>Move South</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>w</strong></td>
                <td class="text-left"><strong>Move West</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>Info</strong></td>
                <td class="text-left"><strong>Get info for the current room</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>ri</strong></td>
                <td class="text-left"><strong>Check the current room for items</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>pi</strong></td>
                <td class="text-left"><strong>Check player inventory </strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>ti</strong></td>
                <td class="text-left"><strong>Take item from current room</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2"><strong>pd</strong></td>
                <td class="text-left"><strong>Have player drop item from inventory into room</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style3"><strong>Save</strong></td>
                <td><strong>Save the game</strong></td>
                
            </tr>
            <tr>
                <td class="auto-style3"><strong>load</strong></td>
                <td><strong>Load the game</strong></td>
                
            </tr>
    </table>

        </body>
</html>
