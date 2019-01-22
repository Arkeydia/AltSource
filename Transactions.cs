using System;
using System.Collections.Generic;
using System.Text;

namespace BankLedger_AltSource
{
    namespace classes
    {
        public class Transaction
        {
            public decimal Amount { get; }
            public DateTime Date { get; }
            public string Notes { get; }
            private List<Transaction> allTransactions = new List<Transaction>();

            public Transaction(decimal amount, DateTime date, string note)
            {
                this.Amount = amount;
                this.Date = date;
                this.Notes = note;
            }
        }
    }
}
