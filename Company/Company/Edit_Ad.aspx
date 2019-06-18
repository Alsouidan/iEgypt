<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_Ad.aspx.cs" Inherits="Company.Edit_Ad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="My Advertisements"></asp:Label>
            <asp:DropDownList ID="DropDownList8" runat="server" AppendDataBoundItems=True  Height="19px" OnSelectedIndexChanged="fillFields" AutoPostBack="true" Width="126px">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label27" runat="server" Text="New Description"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:Label ID="Label28" runat="server" Text="New Location"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button10" runat="server" OnClick="button10Clicked" Text="Edit!" />
        </div>
    </form>
</body>
</html>
