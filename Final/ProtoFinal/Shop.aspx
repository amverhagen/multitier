<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="ProtoFinal.Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="logout_btn" Text="Logout" OnClick="logout_btn_Click" />
        <br />
        <asp:Label runat="server" Font-Size="XX-Large">My Cart:</asp:Label>
        <asp:Table runat="server" ID="cart_tbl"></asp:Table>
        <asp:Button runat="server" ID="checkout_btn" Text="Checkout" OnClick="checkout_btn_Click"/>
        <br />
        <asp:Label runat="server" ID="purchase_lbl"></asp:Label>
        <br />
        <asp:Label runat ="server" ID="fail_lbl"></asp:Label>
        <br />
        <asp:Label runat="server" Font-Size="XX-Large">Available Books:</asp:Label>
        <asp:Table runat="server" ID="books_tbl"></asp:Table>
        <asp:Button runat="server" ID="add_btn" Text="Add to Cart" OnClick="add_btn_Click" />
        <br />
        <asp:Label runat="server" ID="info_lbl"></asp:Label>
    </div>
    </form>
</body>
</html>
