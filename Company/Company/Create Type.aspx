<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create Type.aspx.cs" Inherits="Company.Create_Type" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Type:</p>
            <asp:TextBox ID="T1" runat="server" />
            <br />
            <br />
            <asp:Button ID="B1" runat="server" OnClick="button1Clicked" Text="Create" />
            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
