<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part4.aspx.cs" Inherits="Project2.Part4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server" CellPadding="10" BorderWidth="10" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Taxable Income Range ($)</asp:TableHeaderCell>
                <asp:TableHeaderCell>Tax Rate (%)</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>> 450,000</asp:TableCell>
                <asp:TableCell>39.6</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>> 378,000 and <= 450,000</asp:TableCell>
                <asp:TableCell>33</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>>192,000 and <= 378,000</asp:TableCell>
                <asp:TableCell>28</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>> 71,000 and <= 192,000</asp:TableCell>
                <asp:TableCell>25</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>> 15,000 and <= 71,000</asp:TableCell>
                <asp:TableCell>15</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><= 15,000</asp:TableCell>
                <asp:TableCell>10</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label runat="server">Annual Income:</asp:Label>
        <asp:TextBox runat="server" ID="incomeTextBox"></asp:TextBox>
        <br />
        <asp:Label runat="server">Number of Dependents:</asp:Label>
        <asp:TextBox runat="server" ID="dependTextBox"></asp:TextBox>
        <br />
        <asp:Label ID="warnLabel" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="calcButton" runat="server" Text="Find Income Tax" OnClick="calcButton_Click" />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
