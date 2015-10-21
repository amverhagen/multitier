<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scheduler.aspx.cs" Inherits="Project4.Scheduler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <div style="height:150px">
            <div style="float:left;width:50%;text-align:center">
                <asp:Label runat="server">Available Courses:</asp:Label>
                <br />
                <asp:ListBox ID="lbCourses" runat="server" Width="66%" >
                </asp:ListBox>
                <br />
                <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click"/>
            </div>
            <div style="float:right;width:49%;text-align:center">
                <asp:Label runat="server">Added Courses:</asp:Label>
                <br />
                <asp:ListBox runat="server" ID="lbAdded" Width="66%">
                </asp:ListBox>
                <br />
                <asp:Button runat="server" ID="btnRemove" Text="Remove" OnClick="btnRemove_Click"/>
            </div>
        </div>
        <div style="text-align:center">
            <asp:Label runat="server" ID="lblInfo"></asp:Label>
            <br />
            <br />
            <asp:Button runat="server" ID="btnSchedule" Text="Get Schedule" OnClick="btnSchedule_Click"/>
            <asp:GridView runat="server" ID="gvSchedule" HorizontalAlign="Center"></asp:GridView>
        </div>
    </form>
</body>
</html>
