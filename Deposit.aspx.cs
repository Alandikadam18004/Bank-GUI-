using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bank
{
    

    public partial class Deposit : System.Web.UI.Page
    {
        BankDAL bankDAL = new BankDAL(); // Assuming this is the data access layer class

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            string accountNumber = txtAccountNumber.Text.Trim();
            decimal amount;

            // Validate input
            if (string.IsNullOrEmpty(accountNumber))
            {
                lblMessage.Text = "Account Number is required.";
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount) || amount <= 0)
            {
                lblMessage.Text = "Enter a valid deposit amount.";
                return;
            }

            // Call the DepositMoney method from BankDAL
            bool success = bankDAL.DepositMoney(accountNumber, amount);

            if (success)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Deposit successful!";
            }
            else
            {
                lblMessage.Text = "Deposit failed. Please check the account number and try again.";
            }
        }
    }

}