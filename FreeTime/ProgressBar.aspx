<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBar.aspx.cs" Inherits="FreeTime.ProgressBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>progress bar</title>

      <link rel="stylesheet" href="css/sortingStyle.css" />

    <link rel="stylesheet" href="css/frontStyle.css" />

    <link href="http://netdna.bootstrap.min.css" rel="stylesheet" />
    
    


    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />

</head>
<body>

    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>

    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

    <form id="form1" runat="server">
        <div>

        </div>

       <%-- https://stackoverflow.com/questions/14169313/what-does-script-manager-control-actually-do--%>

        <asp:ScriptManager ID="ScriptManager1" runat="server">


        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        </asp:UpdateProgress>--%>

         </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server"></asp:UpdateProgress>
    </form>
</body>
</html>
