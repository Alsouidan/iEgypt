<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contributer.aspx.cs" Inherits="Company.Contributer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button OnClick="button1Clicked" Text="Upload Original Content" runat="server"/>
            <asp:Button OnClick="button2Clicked" Text="New Requests" runat="server" />
            <asp:Button OnClick="button3Clicked" Text="Messages" runat="server" />
            <asp:Button OnClick="button4Clicked" Text="Upload New Content" runat="server" />
            <asp:Button OnClick="button5Clicked" Text="Delete Content" runat="server" />
            <asp:Button OnClick="button6Clicked" Text="Notifications" runat="server" />
            <asp:Button OnClick="button7Clicked" Text="Events" runat="server" />
            <asp:Button OnClick="button8Clicked" Text="Ads" runat="server" />
            <br />
            <br />
            <asp:Button OnClick="button9Clicked" Text="Back" runat="server" />
        </div>
    </form>
</body>
</html>
