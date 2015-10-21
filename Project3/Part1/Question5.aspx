<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question5.aspx.cs" Inherits="Part1.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="tbSearch"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" text="Search" OnClick="btnSearch_Click"/>
        <asp:GridView runat="server" ID="gvDisplay"></asp:GridView>
    </div>
    </form>
</body>
</html>
