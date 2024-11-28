using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bank
{
    

    public partial class CheckBalance : System.Web.UI.Page
    {
        BankDAL bankDAL = new BankDAL(); // Assuming BankDAL is the class managing database operations

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty; // Clear any existing messages on page load
            }
        }

        protected void btnCheckBalance_Click(object sender, EventArgs e)
        {
            string accountNumber = txtAccountNumber.Text.Trim();

            if (string.IsNullOrEmpty(accountNumber))
            {
                lblMessage.Text = "Please enter a valid account number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            decimal balance;
            string message;

            bool success = bankDAL.GetAccountBalance(accountNumber, out balance, out message);

            if (success)
            {
                lblMessage.Text = $"Account Balance: {balance:C}";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

}