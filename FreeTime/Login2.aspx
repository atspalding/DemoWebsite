<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="FreeTime.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
        <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
        <p>
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
        <p>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Log in" />
        <p>
            <asp:Label ID="LoginLabel" runat="server" Text=" "></asp:Label>
        </p>
        <asp:Button ID="SignupButton" runat="server" OnClick="SignupButton_Click" Text="SignUp" />
    </form>
</body>
</html>
