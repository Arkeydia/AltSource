using System;
using System.Collections.Generic;
using System.Text;

namespace BankLedger_AltSource
{
    public class Account
    {
        //Getters / Setters for Bank Accounts
        private int AccountNumber { get; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private decimal Balance { get; set; }
        private int transNo { get; set; }

        private List<string> transaction = new List<string>();

            //    {
            //    decimal balance = 0;
            //    foreach (var item in allTransactions)
            //    {
            //        balance += item.Amount;
            //    }

            //    return balance;
            //}
       

        //Shell Constructor
        public Account() {
            //Gives random number to Acct
            Random rnd = new Random();
            this.AccountNumber = rnd.Next(1,999999);
            this.transNo = 1;
        }

        //Basic Constructor
        public Account(string username, string password, string firstname, string lastname)
        {
            //Gives random number to Acct
            Random rnd = new Random();
            this.AccountNumber = rnd.Next(1, 999999);

            //Assigns passed values
            this.Username = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.transNo = 1;
        }

        ////Constructor w/ Initial Deposit
        //public Account(string username, string password, string firstname, string lastname, decimal initialBalance)
        //{
        //    this.Username = username;
        //    this.Password = password;
        //    this.FirstName = firstname;
        //    this.LastName = lastname;
        //    this.Balance = initialBalance;
        //}

        public void Deposit(decimal deposit, DateTime date)
        {
            if (deposit <= 10000)
            {
                this.Balance += deposit;
                this.transaction.Add("AccountNumber|" + this.AccountNumber + "|TransactionNumber|" + this.transNo + "|Time|" + date + "|Amount|+" + deposit + "|BalanceSnapshot|" + this.Balance + "|");
                this.transNo++;
            }
            else
            {
                Console.WriteLine("This terminal can only handle transactions lower than $10,000. Please contact Customer Service if there is an error.\n");
            }
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public void Withdrawal(decimal withdrawal, DateTime date)
        {
            if (this.Balance > withdrawal)
            {
                if (withdrawal <= 10000)
                {
                    this.Balance -= withdrawal;
                    this.transaction.Add("AccountNumber|" + this.AccountNumber + "|TransactionNumber|" + this.transNo + "|Time|" + date + "|Amount|-" + withdrawal + "|BalanceSnapshot|" + this.Balance + "|");
                    this.transNo++;
                }
                else
                {
                    Console.WriteLine("This terminal can only handle transactions lower than $10,000. Please contact Customer Service if there is an error.\n");
                }
            }
            else
            {
                Console.WriteLine("Insufficient Funds! No action was taken. If there is an error, please call the customer service number on the back of your card.\n");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine(this.Balance);
        }

        public void GeneralInquiry()
        {
            Console.WriteLine("\n********************************************************************************************");
            Console.WriteLine("\n\tYou've been assigned the following Account Number: " + this.AccountNumber);
            Console.WriteLine("\tUsername: " + this.Username + " for " + this.FirstName + " " + this.LastName);
            Console.WriteLine("\tCurrent Balance for Acct# " + this.AccountNumber + ": " + this.Balance);
            Console.WriteLine("\n********************************************************************************************");
            Console.WriteLine("\nWarning! Do not lose this information!");

        }

        public void GetTransactionHistory()
        {
            foreach (var trans in this.transaction)
            {
                Console.WriteLine(trans);
            }
        }

        //public class AllAccounts
        //{
        //    private static AllAccounts _accts = new AllAccounts();

        //    private static AllAccounts Account
        //    {
        //        get { return _accts; }
        //    }
        //    private List<string> _allAccts = new List<string>();
        //    private AllAccounts()
        //    {
        //        // Initialize here
        //    }

        //    public string GetAccounts()
        //    {
        //        return this._allAccts;

        //    }
        //}
    }
}
