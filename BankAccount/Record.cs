using System;

namespace BankAccount
{
    class Record
    {
        public DateTime datetime;
        public string reason;
        public decimal amount;
        public decimal balance;
        public bool calculatedInInterest;

        public Record(string reason, decimal amount, decimal balance)
        {
            this.datetime = DateTime.Now;
            this.reason = reason;
            this.amount = amount;
            this.balance = balance;
            this.calculatedInInterest = false;
        }
    }
}
