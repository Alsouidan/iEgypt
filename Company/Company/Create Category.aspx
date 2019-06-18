<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create Category.aspx.cs" Inherits="Company.Create_Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Category:</p>
            <asp:TextBox ID="T1" runat="server" />
            <br />
            <p>Subcategory:</p>
            <asp:TextBox ID="T2" runat="server" />
            <br />
            <br />
            <asp:Button ID="B1" runat="server" Text="Create" OnClick="button1Clicked" />
            <br />
            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
