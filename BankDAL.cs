using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class BankDAL
    {
        private readonly string connectionString;

        public BankDAL()
        {
            // Fetch connection string from Web.config
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString;
        }

        public int CreateAccount(string firstName, string lastName, string email, string address, string branch, int age, decimal initialDeposit, out string accountNumber)
        {
            // Generate a unique account number
            accountNumber = "ACC" + DateTime.Now.Ticks.ToString().Substring(10);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Insert query with additional fields
                string query = @"
            INSERT INTO Accounts 
                (AccountNumber, FirstName, LastName, Email, Address, Branch, Age, Balance) 
            OUTPUT INSERTED.AccountID 
            VALUES 
                (@AccountNumber, @FirstName, @LastName, @Email, @Address, @Branch, @Age, @Balance)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Branch", branch);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Balance", initialDeposit);

                conn.Open();
                int accountId = (int)cmd.ExecuteScalar(); // Returns the primary key of the newly inserted account
                conn.Close();

                return accountId;
            }
        }


        public bool GetAccountBalance(string accountNumber, out decimal balance, out string message)
        {
            balance = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to retrieve balance
                string query = "SELECT Balance FROM Accounts WHERE AccountNumber = @AccountNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    message = "Account number not found.";
                    return false;
                }

                balance = Convert.ToDecimal(result);
                message = "Balance retrieved successfully.";
                return true;
            }
        }


        public bool DepositMoney(string accountNumber, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Update the balance for the specified account
                string query = @"
            UPDATE Accounts 
            SET Balance = Balance + @Amount 
            WHERE AccountNumber = @AccountNumber";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // Check if the update was successful
                conn.Close();

                return rowsAffected > 0; // Return true if at least one row was updated
            }
        }


        public bool WithdrawMoney(string accountNumber, decimal amount, out string message, out decimal remainingBalance)
        {
            remainingBalance = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Retrieve current balance
                string selectQuery = "SELECT Balance FROM Accounts WHERE AccountNumber = @AccountNumber";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                object result = selectCmd.ExecuteScalar();
                if (result == null)
                {
                    message = "Account number not found.";
                    return false;
                }

                decimal currentBalance = Convert.ToDecimal(result);

                // Check if sufficient funds are available
                if (currentBalance < amount)
                {
                    message = "Insufficient funds.";
                    return false;
                }

                // Deduct the amount
                string updateQuery = "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountNumber = @AccountNumber";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@Amount", amount);
                updateCmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                updateCmd.ExecuteNonQuery();

                // Fetch updated balance
                remainingBalance = currentBalance - amount;
                message = "Withdrawal successful.";
                return true;
            }
        }


    }

}