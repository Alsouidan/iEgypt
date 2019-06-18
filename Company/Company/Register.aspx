<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Company.Register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Register New"></asp:Label>
        &nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>Choose a User Type</asp:ListItem>
                <asp:ListItem>Viewer</asp:ListItem>
                <asp:ListItem>Contributor</asp:ListItem>
                <asp:ListItem>Authorized Reviewer</asp:ListItem>
                <asp:ListItem>Content Manager</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;
            <asp:Label ID="Label24" runat="server"></asp:Label>
        </div>
        <table style="width: 100%; height: 256px;">
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="First Name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Middle Name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Last Name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Birth Date (YYYY-MM-DD)"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Working Place Name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox7" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Working Place Type"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox8" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="Working Place Description"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox9" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Specialization"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox10" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="Portofolio Link"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox11" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="Years Experience"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox12" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="Hire Date (YYYY-MM-DD)"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox13" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Working Hours"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox14" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" Text="Payment Rate"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="Manager Type"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox15" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox16" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div align="center">
      <asp:Button ID="MyButton"  runat="server" OnClick="MyButton_Click" Text="Register!" />
    </div>
    </form>
</body>
</html>
