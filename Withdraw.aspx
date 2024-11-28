<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="bank.Withdraw" %>



<!DOCTYPE html>
<html>
<head runat="server">
    <title>Withdraw Money</title>
</head>
<body style="text-align: center">
        <header class="auto-style2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1"><strong style="font-family: Gadugi; font-size: xx-large;">Welcome to the Bank Management System<br />
&nbsp;<br />
</strong></span>
</header>
    <form id="form1" runat="server">
             <div style="width: 50%; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); text-align: center; font-family: Gadugi;">

            <h2>Withdraw Money</h2>

            <label for="txtAccountNumber">Account Number:</label>
            <asp:TextBox ID="txtAccountNumber" runat="server" Height="34px" Width="165px" />
            <br />
            <br /><br />

            <label for="txtWithdrawAmount">Withdraw Amount:</label>
            <asp:TextBox ID="txtWithdrawAmount" runat="server" Height="37px" />
            <br />
            <br /><br />

            <asp:Button ID="btnWithdraw" Text="Withdraw" runat="server" OnClick="btnWithdraw_Click" BackColor="Black" ForeColor="#FFCC00" Height="44px" Width="115px" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </form>
</body>
</html>
