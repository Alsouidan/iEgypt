<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order Contributers.aspx.cs" Inherits="Company.Order_Contributers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Contributers ordered according to effeciency and number of handled requests:</h3>
            <asp:Label ID="L1" runat="server" />
        </div>
        <br />
        <br />
        <asp:Button ID="B1" runat="server" Text="Back" OnClick="backClicked" />
    </form>
</body>
</html>
