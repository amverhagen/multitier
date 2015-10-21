<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="Midterm.Developer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="gvBugs"></asp:GridView>
        <asp:Label runat="server">Current Bugs:</asp:Label>
        <asp:DropDownList ID="ddlbugs" runat="server"></asp:DropDownList>
        <br />
        <asp:Label runat="server">Change Log:</asp:Label>
        <br />
        <asp:TextBox ID="tbChanges" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnReport" runat="server" Text="Report Fix" OnClick="btnReport_Click" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnHome" runat="server" text="Home" OnClick="btnHome_Click" />
    </div>
    </form>
</body>
</html>
