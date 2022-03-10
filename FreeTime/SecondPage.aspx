<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="FreeTime.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Second Page</title>
    <link rel="stylesheet" href="css/secondPageStyle.css" />
</head>
<body>
      <div id="google_translate_element"></div>
    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script> 
     <script type="text/javascript">
         function googleTranslateElementInit() {
             new google.translate.TranslateElement({ pageLanguage: 'en' }, 'google_translate_element');
         }
</script> 
    <div>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Welcome to the second page"></asp:Label>
        </div>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="FirstForm.aspx">Go back</asp:HyperLink>
        <br />
        <p>
            <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
        </p>
        <asp:TextBox ID="NameTextBox" runat="server" Text="Name"  ></asp:TextBox>
        <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter name" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="AgeLabel" runat="server" Text="Age"></asp:Label>
        </p>
        <asp:DropDownList ID="DropDownListAge" runat="server">
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Label ID="JobLabel" runat="server" Text="Job"></asp:Label>
        </p>
        <asp:TextBox ID="TextBoxJob" runat="server" Text="Job"   ></asp:TextBox>
        <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter job" ControlToValidate="TextBoxJob"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
        </p>
        <asp:TextBox ID="UserTextBox" runat="server" Text="Username"  ></asp:TextBox>
        <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter username" ControlToValidate="UserTextBox"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password" ></asp:Label>
        </p>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Text="Password"></asp:TextBox>
        <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter password" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>

        <p>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Text="Email@email.com" ></asp:TextBox>
            <asp:RequiredFieldValidator forcolor="red" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter email" ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>

         </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:freeTimeConnection %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        <p>
            <asp:Label ID="WarningLabel" runat="server"></asp:Label>
        </p>
    </form>
        </div>
</body>
</html>
