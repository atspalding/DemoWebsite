<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SortingPage.aspx.cs" Inherits="FreeTime.SortingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sorting page</title>
    <link rel="stylesheet" href="css/sortingStyle.css" />

    <link rel="stylesheet" href="css/frontStyle.css" />

    <link href="http://netdna.bootstrap.min.css" rel="stylesheet" />


     <link rel="stylesheet" href="css/bootstrap-drawer.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/introjs.css" />
    <link rel="stylesheet" href="css/liquid-slider.css" />
    <link rel="stylesheet" href="css/frontStyle.css" />
    <link rel="stylesheet" href="css/LogoLayout.css" />
    <link rel="stylesheet" href="css/sortingStyle.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.touchswipe/1.6.4/jquery.touchSwipe.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!--<script src="js/bsuPizza.js"></script>temp added-->
    <script src="js/ckeditor_4.5.7_standard/ckeditor/ckeditor.js"></script>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <!--<script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>

    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>-->

    
    
    


    <!--<meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />-->




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
        
        </div>
        
        <asp:Label ID="SortingLabel" runat="server" Text="Select a sorting style"></asp:Label>
        <p></p>
        <asp:DropDownList ID="SortingDropDownList" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="1">Bubble Sort</asp:ListItem>
            <asp:ListItem Value="2">Selection sort</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Label ID="Label6" runat="server" Text="(High to low) or (low to high)"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="sortingDirectionList" runat="server">
                <asp:ListItem Value="1">low to high </asp:ListItem>
                <asp:ListItem Value="2">high to low</asp:ListItem>
            </asp:DropDownList>
        </p>

        <p>
            <asp:Label ID="Label1" runat="server" Text="First number"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox1" runat="server"  TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter number" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Second number"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter number" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="Label3" runat="server" Text="Third number"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter number" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="Label4" runat="server" Text="fourth number"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter number" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="Label5" runat="server" Text="Fifth number"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox5" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter number" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>

        <p>
            <asp:Button ID="SortButton" runat="server" OnClick="SortButton_Click" Text="Sort" />
        </p>
        <asp:Panel ID="sortingPanel" runat="server" ScrollBars="Auto">
        </asp:Panel>
    </form>

     <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>

</body>
</html>
