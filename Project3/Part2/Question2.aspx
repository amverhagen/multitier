﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Part2.Specializations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlSpecials" runat="server"></asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" text="Search" OnClick="btnSearch_Click" />
        <asp:GridView runat="server" ID="gvDisplay"></asp:GridView>
    </div>
    </form>
</body>
</html>
