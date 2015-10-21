<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part2.aspx.cs" Inherits="Project2.Part2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server" BorderColor="Black" GridLines="Both" CellPadding="7">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Vehical Type</asp:TableHeaderCell>
                <asp:TableHeaderCell>Daily Rate</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>Economy</asp:TableCell>
                <asp:TableCell>24.99</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Compact</asp:TableCell>
                <asp:TableCell>29.99</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Intermediate</asp:TableCell>
                <asp:TableCell>39.99</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Standard</asp:TableCell>
                <asp:TableCell>44.99</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Full Size</asp:TableCell>
                <asp:TableCell>49.99</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label runat="server">Choose Type:</asp:Label>
        <asp:DropDownList runat="server" ID="ddlType">
            <asp:ListItem Value="24.99">Economy</asp:ListItem>
            <asp:ListItem Value="29.99">Compact</asp:ListItem>
            <asp:ListItem Value="39.99">Intermediate</asp:ListItem>
            <asp:ListItem Value="44.99">Standard</asp:ListItem>
            <asp:ListItem Value="49.99">Full Size</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server">Days:</asp:Label>
        <asp:TextBox runat="server" ID="daysTextBox"></asp:TextBox>
        <br />
        <asp:Button  runat="server" ID="calcButton" OnClick="calcButton_Click" Text="Get Total"/>
        <asp:Label runat="server" ID="warnLabel" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label runat="server" ID="totalLabel"></asp:Label>
    </div>
    </form>
</body>
</html>
