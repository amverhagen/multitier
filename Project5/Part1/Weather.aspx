<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="Part1.Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Enter zip codes:</asp:Label>
        <asp:TextBox runat="server" ID="zipBox"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="submitButton" OnClick="submitButton_Click" Text="Find Weather"/>
        <asp:Label ID="infoLabel" runat="server"></asp:Label>
        <asp:Table runat="server" ID="weatherTable" BorderWidth="4" BorderStyle="Double"></asp:Table>
    </div>
    </form>
</body>
</html>
