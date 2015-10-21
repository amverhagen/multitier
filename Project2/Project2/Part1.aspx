<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part1.aspx.cs" Inherits="Project2.Part1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div />
    <asp:Label ID="ageLabel" runat="server">Enter Age:</asp:Label>
    <div />
    <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
    <div />
    <asp:Label ID="rateLabel" runat="server">Enter Resting Heart Rate:</asp:Label>
    <div />
    <asp:TextBox ID="rateTextBox" runat="server"></asp:TextBox>
    <div />
    <asp:Label ID="warnLabel" runat="server" ForeColor="Red"></asp:Label>
    <div />
    <asp:Button ID="calcButton" runat="server" text="Calculate THR" OnClick="calcButton_Click"/>
    <div />
    <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
