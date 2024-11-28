<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="bank.CreateAccount" %>



<!DOCTYPE html>
<html >
<head runat="server">
    <title>Create Account</title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            text-align: center;
        }
        .form-control {}
        .btn-primary {}
    </style>
</head>
<body>
    <header class="auto-style2" style="font-family: Gadugi">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1"><strong style="font-family: Gadugi">Welcome to the Bank Management System
        <br />
        <br />
        </strong></span>
    </header>
    <form id="form1" runat="server">
        <div style="width: 50%; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px; box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); text-align: center; font-family: Gadugi;">
            <h2 style="text-align: center;">Create Account</h2>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name:" AssociatedControlID="txtFirstName"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter First Name" CssClass="form-control" Height="27px" Width="152px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:" AssociatedControlID="txtLastName"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name" CssClass="form-control" Height="23px" Width="141px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAge" runat="server" Text="Age:" AssociatedControlID="txtAge"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAge" runat="server" placeholder="Enter Age" CssClass="form-control" Height="26px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control" Height="22px" Width="180px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address:" AssociatedControlID="txtAddress"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control" Height="44px" Width="170px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblBranch" runat="server" Text="Select Branch:" AssociatedControlID="ddlBranch"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" Height="31px" Width="133px">
                <asp:ListItem Text="Select Branch" Value="" />
                <asp:ListItem Text="Shivdi" Value="Shivdi" />
                <asp:ListItem Text="Cotton" Value="Cotton" />
                <asp:ListItem Text="Wadala" Value="Wadala" />
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblInitialDeposit" runat="server" Text="Initial Deposit Amount:" AssociatedControlID="txtInitialDeposit"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtInitialDeposit" runat="server" placeholder="Enter Deposit Amount" CssClass="form-control" Height="30px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" CssClass="btn btn-primary" OnClick="btnCreateAccount_Click" BackColor="Black" ForeColor="#FFCC00" Height="43px" Width="150px" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
