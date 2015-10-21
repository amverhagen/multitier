<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProtoFinal.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Font-Size="XX-Large">Registration</asp:Label>
        <br />
        <asp:Label runat="server">New username: </asp:Label>
        <asp:TextBox runat="server" ID="username_tb"></asp:TextBox>
        <br />
        <asp:Label runat="server">New password</asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="password_tb"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="submit_btn" Text="Submit" OnClick="submit_btn_Click"/>
        <asp:Label runat="server" ID="info_lbl"></asp:Label>
        <br />
        <a href="Login.aspx">Return to login</a>
    </div>
    </form>
</body>
</html>
