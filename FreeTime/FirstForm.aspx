<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstForm.aspx.cs" Inherits="FreeTime.FirstForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>First Form</title>
    <link rel="stylesheet" href="css/firstFormStyle.css" />
     
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
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="First Page"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Type somthing into textbox"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />
        </p>
        <asp:Label ID="textValueLabel" runat="server" Text="Text value appears here"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="To Second Page" />
        </p>
        <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Log in" />
        <asp:Button ID="SignupButton" runat="server" OnClick="SignupButton_Click" Text="Sign up" />
    </form>
</body>
</html>
