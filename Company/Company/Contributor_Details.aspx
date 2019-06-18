<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contributor_Details.aspx.cs" Inherits="Company.Contributor_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div text-allign:"Center">
            <asp:Label ID="Label1" runat="server" Text="Contributor Information"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="button1Clicked" Text="Go Back to My Profile" />
        </div>
    </form>
</body>
</html>
