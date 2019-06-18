<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff Member.aspx.cs" Inherits="Company.Staff_Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="B1" />
            <asp:Button runat="server" ID="B2" OnClick="button2Clicked" Text="Create Category/Subcategory"/>
            <asp:Button runat="server" ID="B3" OnClick="button3Clicked" Text="Create Type" />
            <asp:Button runat="server" ID="B4" OnClick="button4Clicked" Text="Most Requested Content" />
            <asp:Button runat="server" ID="B5" OnClick="button5Clicked" Text="Number of requests/Category/Working place type" />
            <asp:Button runat="server" ID="B6" OnClick="button6Clicked" Text="Notifications" />
            <asp:Button runat="server" ID="B7" OnClick="button7Clicked" Text="Delete Comments" />
            <asp:Button runat="server" ID="B8" OnClick="button8Clicked" Text="Delete Content" />
            <asp:Button runat="server" ID="B9" OnClick="button9Clicked" Text="Order Contributers" />
            <asp:Button runat="server" ID="B10" OnClick="button10Clicked" Text="Assign Contributer" />
            <br />
            <br />
            <asp:Button runat="server" ID="B11" OnClick="button11Clicked" Text="Back" />
        </div>
    </form>
</body>
</html>
