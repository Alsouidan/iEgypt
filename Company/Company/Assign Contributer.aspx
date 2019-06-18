<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assign Contributer.aspx.cs" Inherits="Company.Assign_Contributer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Assign a contributer to a new request:</h3>
            <asp:DropDownList ID="RequestDropdown" runat="server" DataSourceID="RequestIEGYPT" DataTextField="Info" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="RequestIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select [user].email + ' information: ' + new_request.information AS Info, new_request.id from new_request inner join [user] on [user].id=new_request.viewer_id where specified = 0 and contributer_id is null"></asp:SqlDataSource>
            
            <asp:DropDownList ID="ContributerDropdown" runat="server" DataSourceID="ContributerIEGYPT" DataTextField="Info" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ContributerIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select [user].email + ' ' + [user].first_name + ' ' + [user].middle_name + ' ' + [user].last_name AS Info, [user].id from contributor inner join [user] on [user].id=contributor.id"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="B1" runat="server" Text="Assign" OnClick="button1Clicked" />
            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
