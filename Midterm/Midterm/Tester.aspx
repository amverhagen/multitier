<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="Midterm.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Subject:</asp:Label>
        <asp:TextBox runat="server" ID="tbSubject" MaxLength="17"></asp:TextBox>
        <br />
        <asp:Label runat="server">Priority:</asp:Label>
        <asp:DropDownList runat="server" ID="ddlPriority">
            <asp:ListItem Value="Low"></asp:ListItem>
            <asp:ListItem Value="Med"></asp:ListItem>
            <asp:ListItem Value="High"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server">Description:</asp:Label>
        <br />
        <asp:TextBox runat="server" TextMode="MultiLine" ID="tbDescrip" Rows="2"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click"/>
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
        <br />
        <asp:Button ID="btnReturn" Text="Home" runat="server" OnClick="btnReturn_Click"/>
    </div>
    </form>
</body>
</html>
