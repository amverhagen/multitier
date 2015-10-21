<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part5.aspx.cs" Inherits="Project2.Part5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:DropDownList runat="server" id="itemsDDL">
            <asp:ListItem Value="19.99">Lean In</asp:ListItem>
            <asp:ListItem Value="15.99">Happy, Happy, Happy</asp:ListItem>
            <asp:ListItem Value="17.99">Eleven Rings</asp:ListItem>
            <asp:ListItem Value="12.99">Lets Explore Diatbetes with Owls</asp:ListItem>
            <asp:ListItem Value="16.99">The Guns at Last Light</asp:ListItem>
        </asp:DropDownList>
        <asp:Label runat="server">Quantity:</asp:Label>
        <asp:TextBox ID="quantityTextBox" runat="server" MaxLength="2" Width="15px"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="addButton" text="Add to Cart" OnClick="addButton_Click"/>
        <asp:Label runat="server" ID="warnLabel" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button runat="server" ID="checkOutButton" Text="Checkout" OnClick="checkOutButton_Click" />
        <br />
        <asp:Label runat="server" ID="resultLabel"></asp:Label>
    </div>
    </form>
</body>
</html>
