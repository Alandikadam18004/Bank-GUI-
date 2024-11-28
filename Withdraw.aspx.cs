using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bank
{
    using System;

    public partial class Withdraw : System.Web.UI.Page
    {
        BankDAL bankDAL = new BankDAL(); // Assuming BankDAL is the class managing database operations

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty; // Clear any existing messages on page load
            }
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            string accountNumber = txtAccountNumber.Text.Trim();
            decimal amount;

            // Validate withdrawal amount input
            if (!decimal.TryParse(txtWithdrawAmount.Text.Trim(), out amount) || amount <= 0)
            {
                lblMessage.Text = "Please enter a valid withdrawal amount.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Perform the withdrawal operation
            string message;
            decimal remainingBalance;

            bool success = bankDAL.WithdrawMoney(accountNumber, amount, out message, out remainingBalance);

            if (success)
            {
                lblMessage.Text = $"{message}<br />Remaining Balance: {remainingBalance:C}";
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