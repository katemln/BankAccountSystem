using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Account
    {
        readonly protected decimal transactionLimit = 250; // set by the bank
        protected string firstName;
        protected string lastName;
        protected string accountType;
        protected decimal balance = 0;
        protected int iban;
        protected List<Record> ledger = new List<Record>();

        public Account(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.iban = this.IbanGenerator();
        }

        public void PrintStatementTransaction()
        {
            Console.WriteLine("IBAN" + this.iban);
            Console.WriteLine("Name:" + this.firstName + " " + this.lastName);
            Console.WriteLine("Type:" + this.accountType);
            Console.WriteLine("       DATE         |   REASON    |   AMOUNT   |   BALANCE   ");
            Console.WriteLine("--------------------|-------------|------------|-------------");
            foreach (var record in this.ledger)
            {
                Console.WriteLine(record.datetime.ToString("dd/MM/yyyy HH:mm:ss") + " |  " + record.reason + "  |  " + record.amount + "  |" + record.balance);
            }
        }

        protected int IbanGenerator()
        {
            Random rand = new Random();
            return rand.Next(100000, 1000000);
        }
    }
}
