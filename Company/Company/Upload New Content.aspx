<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload New Content.aspx.cs" Inherits="Company.Upload_New_Content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Type:</p>
            <asp:DropDownList ID="TypeDropdown" runat="server" DataSourceID="TypeIEGYPT" DataTextField="type" DataValueField="type">
            </asp:DropDownList>
            <asp:SqlDataSource ID="TypeIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="Select [type] from Content_type"></asp:SqlDataSource>
            <br/>

            <p>Category:</p>
            <asp:DropDownList ID="CategoryDropdown" runat="server" DataSourceID="CategoryIEGYPT" DataTextField="type" DataValueField="type" AutoPostBack="true">
            </asp:DropDownList>
            <asp:SqlDataSource ID="CategoryIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="Select [type] from Category"></asp:SqlDataSource>
            <br/>

            <p>Subcategory:</p>
            <asp:DropDownList ID="SubcategoryDropdown" runat="server" DataSourceID="SubcategoryIEGYPT" DataTextField="name" DataValueField="name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SubcategoryIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CategoryDropdown" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br/>

            <p>Link:</p>
            <asp:TextBox ID="linkTB" runat="server" />
            <br />

            <p>Corresponding New Request:</p>
            <asp:DropDownList ID="RequestDropdown" runat="server" DataSourceID="requestIEGYPT" DataTextField="info" DataValueField="id" AutoPostBack="true">
            </asp:DropDownList>
            <asp:SqlDataSource ID="requestIEGYPT" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand=""></asp:SqlDataSource>
            <br />

            <asp:Button onClick="button1Clicked" Text="Upload" runat="server" />

            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
