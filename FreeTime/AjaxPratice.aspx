<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPratice.aspx.cs" Inherits="FreeTime.AjaxPratice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajax</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Hi"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="False"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click here" />
    </form>
</body>
</html>
