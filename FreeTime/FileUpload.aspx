<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="FreeTime.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
    <link rel="stylesheet" href="css/FileUpload.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Choose file to upload"></asp:Label>
        <br />

        <asp:FileUpload ID="FileUploader" runat="server" />
        <br />

        <asp:Button ID="uploadButton" runat="server" OnClick="uploadButton_Click" Text="Upload" />

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download" />

        <p>
            <asp:Label ID="uploadLabel" runat="server" Text="Please upload a file"></asp:Label>
        </p>
        <asp:Panel ID="OutputPanel" runat="server">
        </asp:Panel>

    </form>
</body>
</html>
