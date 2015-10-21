<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Midterm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Username:</asp:Label>
        <asp:TextBox runat="server" ID="tbUsername"></asp:TextBox>
        <br />
        <asp:Label runat="server">Password:</asp:Label>
        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
        <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
