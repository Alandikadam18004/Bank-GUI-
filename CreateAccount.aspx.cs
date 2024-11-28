using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bank
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string branch = ddlBranch.SelectedValue;
            decimal initialDeposit;
            int age;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) ||
                branch == "" || !int.TryParse(txtAge.Text.Trim(), out age) ||
                !decimal.TryParse(txtInitialDeposit.Text.Trim(), out initialDeposit) ||
                initialDeposit < 0)
            {
                lblMessage.Text = "Please fill in all fields correctly.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (age < 18)
            {
                lblMessage.Text = "You must be at least 18 years old to open an account.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Validate email format
                if (!IsValidEmail(email))
                {
                    lblMessage.Text = "Invalid email format.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Create the account in the database using the BankDAL class
                BankDAL bankDAL = new BankDAL();
                string accountNumber;
                int accountId = bankDAL.CreateAccount(firstName, lastName, email, address, branch, age, initialDeposit, out accountNumber);

                lblMessage.Text = $"Account created successfully! Account Number: {accountNumber}";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                // Clear input fields
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtInitialDeposit.Text = string.Empty;
                ddlBranch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Helper function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}



