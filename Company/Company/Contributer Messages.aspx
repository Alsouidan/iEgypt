<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contributer Messages.aspx.cs" Inherits="Company.Contributer_Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ViewersDropdown" runat="server" DataSourceID="ViewersIEGYPT" DataTextField="email" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ViewersIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [User].id, [User].email FROM [User] INNER JOIN Viewer ON [User].id = Viewer.id"></asp:SqlDataSource>
            <asp:Button Text="Show Messages" runat="server" OnClick="button1Clicked" />
            <br/>
            <asp:Label ID="L1" runat="server" />
            <br/>
            <asp:TextBox ID="T1" runat="server" TextMode="MultiLine" Visible="false"/>
            <asp:Button Text="Send Message" runat="server" OnClick="button2Clicked" ID="B1" Visible="false"/>
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
