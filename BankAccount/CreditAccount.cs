using System;

namespace BankAccount
{
    class CreditAccount : Account
    {
        readonly protected decimal creditLimit = 3000;
        readonly private decimal fee = 0.01m;
        readonly private decimal interestRate = 0.05m;

        public CreditAccount(string firstName, string lastName) : base(firstName, lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.accountType = "Credit";
            this.iban = this.IbanGenerator();
        }

        public void Deposit(decimal amount)
        {
            if (this.balance + amount > 0)
            {
                Console.WriteLine("Amount is too big for current balance");
                return;
            }
            this.balance += amount;
            Record record = new Record("DEPOSIT", amount, this.balance);
            this.ledger.Add(record);
            Console.WriteLine("Balance:" + this.balance);
        }

        public void Charge(decimal amount)
        {
            var chargingAmount = amount + amount * this.fee;
            if (chargingAmount > this.transactionLimit) {
                Console.WriteLine("Amount is greater than transaction limit");
                return;
            }
            if (this.balance - chargingAmount < this.creditLimit * (-1)) {
                Console.WriteLine("Amount is too big for current credit limit");
                return;
            }

            this.balance -= chargingAmount;
            Record record = new Record("CHARGE", chargingAmount, this.balance);
            this.ledger.Add(record);
            Console.WriteLine("Balance:" + this.balance);
        }

        public void AddPayment(decimal amount)
        {
            Console.WriteLine("Adding payment of " + amount);
        }

    }
}
