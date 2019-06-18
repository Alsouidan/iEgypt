<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="Company.Viewer" MaintainScrollPositionOnPostback="true" %>

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
            <asp:Label ID="Label1" runat="server" Text="Your Info:"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button13" runat="server" OnClick="button13Clicked" Text="HomePage" />
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="button1Clicked" Text="Create New Event" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Apply for an Existing Request"></asp:Label>
&nbsp;&nbsp;
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label4" runat="server" Text="Content Details"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="422px">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" OnClick="button2Clicked" Text="Apply Request!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label6" runat="server" Text="Apply for a New Request"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label7" runat="server" Text="Information"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Contributor"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="18px" Width="142px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="button3Clicked" Text="Apply Request!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label9" runat="server" Text="Delete Request"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label10" runat="server" Text="Request Information"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="160px">
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="button4Clicked" Text="Delete" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label11" runat="server" Text="Review Original Content"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label12" runat="server" Text="Original Content"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="113px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label13" runat="server" Text="Rating out of 5"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="button5Clicked" Text="Rate!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label14" runat="server" Text="Comment on Original Content"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label15" runat="server" Text="Original Content"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server" Height="16px" Width="113px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label16" runat="server" Text="Comment"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="button6Clicked" Text="Comment!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label17" runat="server" Text="Edit Comment"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label18" runat="server" Text="My Comments"></asp:Label>
            <asp:DropDownList ID="DropDownList6" runat="server" Height="18px" Width="121px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label19" runat="server" Text="New Comment"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Edit!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label20" runat="server" Text="Delete Comment"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label21" runat="server" Text="My Comments"></asp:Label>
            <asp:DropDownList ID="DropDownList7" runat="server" Height="18px" Width="121px">
            </asp:DropDownList>
&nbsp;<asp:Button ID="Button8" runat="server" OnClick="button8Clicked" Text="Delete!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label22" runat="server" Text="Create an Advertisement"></asp:Label>
&nbsp;&nbsp;&nbsp;
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label23" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label24" runat="server" Text="Location"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button9" runat="server" OnClick="button9Clicked" Text="Create!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label25" runat="server" Text="Edit Advertisement"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button12" runat="server" OnClick="button12Clicked" Text="Edit" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label29" runat="server" Text="Delete Advertisement"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label30" runat="server" Text="My Advertisements"></asp:Label>
            <asp:DropDownList ID="DropDownList9" runat="server" Height="32px" Width="130px">
            </asp:DropDownList>
            <asp:Button ID="Button11" runat="server" OnClick="button11Clicked" Text="Delete!" />
        </p>
        <p style="margin-left: 200px">
            <asp:Label ID="Label31" runat="server" Text="New Content I Ordered"></asp:Label>
        </p>
        <p style="margin-left: 200px">
            <asp:ListBox ID="ListBox1" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="setLink" Width="684px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="ViewProfile"></asp:LinkButton>
        </p>
        <p style="margin-left: 200px">
            &nbsp;</p>
        <p style="margin-left: 200px">
            &nbsp;</p>
        <p style="margin-left: 200px">
            &nbsp;</p>
    </form>
</body>
</html>
