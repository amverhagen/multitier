<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question5.aspx.cs" Inherits="Part2.Question5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
        <asp:Label ID="lbMessage" runat="server"></asp:Label>
        <asp:GridView ID="gvDisplay" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
