<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanelPratice.aspx.cs" Inherits="FreeTime.UpdatePanelPratice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateButton2" Eventname="Click" />


        </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" ID="DateTimeLabel1" />
                <asp:Button runat="server" ID="UpdateButton1" OnClick="UpdateButton_Click" Text="Update" />

            </ContentTemplate>


        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label runat="server" ID="DateTimeLabel2" />
                <asp:Button runat="server" ID="UpdateButton2" OnClick="UpdateButton_Click" Text="Update" />

            </ContentTemplate>




        </asp:UpdatePanel>


        <div>
        </div>
    </form>
</body>
</html>
<!----ajax.net-tutorials.com/controls/updatepanel-control/>
