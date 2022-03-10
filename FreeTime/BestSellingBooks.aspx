<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BestSellingBooks.aspx.cs" Inherits="FreeTime.BestSellingBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Best Selling Books</title>

    <link rel="stylesheet" href="css/BestSellingBooksStyle.css" />
    <link href="css/hover.css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="css/frontStyle.css" />

     <link rel="stylesheet" href="css/bootstrap-drawer.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/introjs.css" />
     <link rel="stylesheet" href="css/liquid-slider.css" />
    <link rel="stylesheet" href="css/frontStyle.css" />
    <link rel="stylesheet" href="css/LogoLayout.css" />
    <link rel="stylesheet" href="css/BestSellingBooksStyle.css" />
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
            <asp:Label ID="Label1" runat="server" Text="Choose A Year"></asp:Label>
            <br/>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem>2021</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Isbn" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Isbn" HeaderText="Isbn" ReadOnly="True" SortExpression="Isbn" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                <asp:BoundField DataField="AmountSold" HeaderText="AmountSold" SortExpression="AmountSold" />
                <asp:BoundField DataField="BestYear" HeaderText="BestYear" SortExpression="BestYear" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FreeTime_dbConnectionString %>" SelectCommand="SELECT * FROM [PopularBooks] WHERE ([BestYear] = @BestYear)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="BestYear" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>

     <script src="js/drawer.js"></script>
    <script>
        $("#drawerMenu").drawer({ toggle: false });

    </script>


</body>
</html>
