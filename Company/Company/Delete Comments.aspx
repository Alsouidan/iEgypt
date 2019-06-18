<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete Comments.aspx.cs" Inherits="Company.Delete_Comments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Choose Original Content:</p>
            <asp:DropDownList ID="ContentDropdown" runat="server" DataSourceID="ContentIEGYPT" DataTextField="Info" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ContentIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="Select original_content.id, content.link + ' ' + [user].email AS Info from original_content inner join content on original_content.id=content.id inner join [user] on [user].id=content.contributer_id"></asp:SqlDataSource>
            <asp:Button ID="B1" Text="Show Comments" runat="server" OnClick="button1Clicked" />
            <br />
            <br />
            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
