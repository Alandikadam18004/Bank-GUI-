<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBalance.aspx.cs" Inherits="bank.CheckBalance" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>Check Balance</title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
            <header class="auto-style2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <span class="auto-style1"><strong style="font-family: Gadugi; font-size: xx-large;">&nbsp;Welcome to the Bank Management System<br />
                <br />
</strong></span>
</header>
    <form id="form1" runat="server">
            <div style="width: 50%; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); text-align: center; font-family: Gadugi;">
            <h2>&nbsp; Check Account Balance</h2>
        
        
            <p>&nbsp;</p>

            <label for="txtAccountNumber">Account Number:</label>
            <asp:TextBox ID="txtAccountNumber" runat="server" Height="30px" Width="167px" />
            <br />
            <br /><br />

            <asp:Button ID="btnCheckBalance" Text="Check Balance" runat="server" OnClick="btnCheckBalance_Click" BackColor="Black" ForeColor="#FFCC00" Height="47px" Width="141px" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </form>
</body>
</html>
