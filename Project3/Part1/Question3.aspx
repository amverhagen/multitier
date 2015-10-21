<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question3.aspx.cs" Inherits="Part1.majors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="ddlMajors"></asp:DropDownList>
        <asp:Button runat="server" ID="btnDisplay" text="Show Students" OnClick="btnDisplay_Click"/>
        <asp:GridView runat="server" ID="gvDisplay"></asp:GridView>
    </div>
    </form>
</body>
</html>
