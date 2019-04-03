using System;

namespace BankAccount
{
    class SavingsAccount : Account
    {
        readonly private decimal interestRate = 0.08m;

        public SavingsAccount(string firstName, string lastName) : base(firstName, lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.accountType = "Savings";
            this.iban = this.IbanGenerator();
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
            Record record = new Record("DEPOSIT", amount, this.balance);
            this.ledger.Add(record);
            Console.WriteLine("Balance:" + this.balance);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.balance)
            {
                Console.WriteLine("Amount is greater than balance");
                return;
            }
            if (amount > this.transactionLimit)
            {
                Console.WriteLine("Amount is greater than transaction limit");
                return;
            }
            this.balance -= amount;
            Record record = new Record("WITHDRAW", amount * (-1), this.balance);
            this.ledger.Add(record);
            Console.WriteLine("Balance:" + this.balance);
        }

        public void AddInterest()
        {
            var interest = this.balance * this.interestRate;
            this.balance += interest;
            Record record = new Record("INTEREST", interest, this.balance);
            this.ledger.Add(record);
            Console.WriteLine("Balance: " + this.balance);
        }
    }
}
