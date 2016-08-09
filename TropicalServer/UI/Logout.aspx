<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="TropicalServer.UI.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="welcomelbl"></asp:Label>
        <asp:Button runat="server" ID="logout" Text="Log-out" OnClick="logout_Click"/>
    </div>
    </form>
</body>
</html>
