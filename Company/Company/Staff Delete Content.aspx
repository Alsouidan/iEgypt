<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff Delete Content.aspx.cs" Inherits="Company.Staff_Delete_Content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Original Content</h1>
            <asp:Label ID="L1" runat="server" />
            <h1>New Content</h1>
            <asp:Label ID="L2" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="B1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
