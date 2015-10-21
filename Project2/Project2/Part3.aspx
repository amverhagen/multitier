<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part3.aspx.cs" Inherits="Project2.Part3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Quiz score:</asp:Label>
        <asp:TextBox runat="server" ID="quizTextBox"></asp:TextBox>
        <br />
        <asp:Label runat="server">Assignment score:</asp:Label>
        <asp:TextBox runat="server" ID="assignTextBox"></asp:TextBox>
        <br />
        <asp:Label runat="server">Midterm score:</asp:Label>
        <asp:TextBox runat="server" ID="midTextBox"></asp:TextBox>
        <br />
        <asp:Label runat="server">Final Exam score:</asp:Label>
        <asp:TextBox runat="server" ID="finalTextBox"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="calcButton" Text="Calculate Score" OnClick="calcButton_Click" />
        <asp:Label runat="server" ID="warnLabel" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label runat="server" ID="resultLabel"></asp:Label>
    </div>
    </form>
</body>
</html>
