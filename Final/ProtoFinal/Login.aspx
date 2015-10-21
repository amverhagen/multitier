<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProtoFinal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Font-Size="XX-Large">Login</asp:Label>
        <br />
        <asp:Label runat="server">Username:</asp:Label>
        <asp:TextBox runat="server" id="username_tb"></asp:TextBox>
        <br />
        <asp:Label runat="server">Password:</asp:Label>
        <asp:TextBox runat="server" ID="password_tb" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button runat="server" Text="Login" ID="login_btn" OnClick="login_btn_Click" />
        <asp:Label runat="server" ID="info_lbl"></asp:Label>
        <br />
        <a href="Register.aspx">New user? Register here</a>
    </div>
    </form>
</body>
</html>
