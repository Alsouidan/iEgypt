<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Event.aspx.cs" Inherits="Company.New_Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Create a New Event"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server"></asp:Label>
        </div>
        <table style="width: 100%; height: 245px;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="City:"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Date and Time (MM/DD/YYYY HH/MM/SS AM/PM)"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Video Link"></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Photo Link"></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Entertainer"></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Location"></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Create an Advertisement for the New Event" />
                    <br />
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="Create!" OnClick="button1Clicked"  />
        </div>
    </form>
</body>
</html>
