<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question4.aspx.cs" Inherits="Part2.Question4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlStudies" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudies_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddlPhysicians" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPhysicians_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="gvDisplay" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
