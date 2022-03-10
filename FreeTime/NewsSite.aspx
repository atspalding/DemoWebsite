 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSite.aspx.cs" Inherits="FreeTime.NewsSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News</title>
    <link rel="stylesheet" href="css/NewsSite.css" />
    <link href="css/hover.css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="css/frontStyle.css" />
</head>
<body>
     <div id="google_translate_element"></div>
    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script> 
     <script type="text/javascript">
function googleTranslateElementInit() {
new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
}
</script> 

    <form id="form1" runat="server">
        <!-https://ianlunn.co.uk/articlej7/hover-css-tutorial-introduction/->
        <div>
            <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
            &nbsp;</div>
        <div>
        <asp:Button ID="Button4" runat="server" Text="Forcast" OnClick="Button4_Click" Visible="False" />
            &nbsp;</div>
        <asp:Panel ID="NewsPanel" runat="server" Height="400px">
            <!--<asp:Label ID="newslabel" runat="server" Text="newslabel"></asp:Label>-->
            <div  style='float:left; vertical-align: top; width: 900px;' >
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <!--<asp:Panel ID="Panel3" runat="server" Width="900px">
            </asp:Panel>-->
                <!--changed panel1 id to panel 3 for now-->
                <!--https://ajax.net-tutorials.com/controls/updatepanel-control/-->
                <!--https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.updatepanel.updatemode?view=netframework-4.7.2-->
             <asp:UpdatePanel runat="server" id="Panel1" updatemode="Conditional" Width="900px" >

             </asp:UpdatePanel>

            </div>
            <div  style='float:right; vertical-align: top; width: 200px; height: 259px;' >
                <asp:Panel ID="Panel2" runat="server" BackColor="Black" Height="400px" Width="200px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="200px" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="News" Width="200px" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Weather" Width="200px" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Sorting page" Width="200px" />
                </asp:Panel>
            </div>
        </asp:Panel>
        <!--<asp:Label ID="Label2" runat="server" Text="powered by newsapi.org"></asp:Label>-->
    </form>
</body>
</html>
