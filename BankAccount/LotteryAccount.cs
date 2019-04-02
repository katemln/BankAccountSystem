using System;

namespace BankAccount
{
    class LotteryAccount : SavingsAccount
    {
        readonly private decimal winPercentage = 2;
        readonly private decimal winAmount = 5;

        public LotteryAccount(string firstName, string lastName) : base(firstName, lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.accountType = "Lottery";
            this.iban = this.IbanGenerator();
        }

        public new void Deposit(decimal amount)
        {
            this.balance += amount;
            Record record = new Record("DEPOSIT", amount, this.balance);
            this.ledger.Add(record);
            Random rand = new Random();
            if (rand.Next(0, 101) <= this.winPercentage) {
                this.balance += this.winAmount;
                record = new Record("WIN", this.winAmount, this.balance);
                this.ledger.Add(record);
            }
            Console.WriteLine("Balance:" + this.balance);
        }

        public new void Withdraw(decimal amount)
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
            Random rand = new Random();
            if (rand.Next(0, 101) <= this.winPercentage)
            {
                this.balance += this.winAmount;
                record = new Record("WIN", this.winAmount, this.balance);
                this.ledger.Add(record);
            }
            Console.WriteLine("Balance:" + this.balance);
        }
    }
}
