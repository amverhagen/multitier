<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="Midterm.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rblStatus" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged">
            <asp:ListItem Value="Open">Open</asp:ListItem>
            <asp:ListItem Value="Assigned">Assigned</asp:ListItem>
            <asp:ListItem Value="Completed">Completed</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label runat="server">Choose bug:</asp:Label>
        <asp:DropDownList ID="ddlBugs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBugs_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:DetailsView ID="dvBugs" runat="server"></asp:DetailsView>
        <asp:Label runat="server">Choose Dev:</asp:Label>
        <asp:DropDownList ID="ddlDev" runat="server"></asp:DropDownList>
        <br />
        <asp:Button id="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" />
    </div>
    </form>
</body>
</html>
