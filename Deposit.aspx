<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="bank.Deposit" %>


<!DOCTYPE html>
<html>
<head>
    <title>Deposit Money</title>
</head>
<body style="text-align: center">
     <header class="auto-style2">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1"><strong style="font-family: Gadugi; font-size: xx-large;">Welcome to the Bank Management System
         <br />
         <br />
 </strong></span>
 </header>
    <form id="form1" runat="server">
     <div style="width: 50%; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); text-align: center; font-family: Gadugi;">

        <h2>Deposit Money</h2>
        <p>&nbsp;</p>
       
            <label for="txtAccountNumber">Account Number:</label>
            <asp:TextBox ID="txtAccountNumber" runat="server" Height="26px" Width="173px"></asp:TextBox>
            <br />
            <br />
       
            <label for="txtAmount">Deposit Amount:</label>
            <asp:TextBox ID="txtAmount" runat="server" Height="31px" Width="135px"></asp:TextBox>
            <br />
            <br />
        
            <asp:Button ID="btnDeposit" runat="server" Text="Deposit" OnClick="btnDeposit_Click" BackColor="Black" ForeColor="#FF9900" Height="38px" Width="132px" />
            <br />
            <br />
       
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
