using System;
using System.Linq;

namespace BankAccount
{
    class BankAccountSystem
    {
        readonly static string[] accountTypes = { "savings", "credit", "lottery" };
        readonly static string[] savingsLotteryAccountActions = { "deposit", "withdraw", "addinterest", "print", "quit" };
        readonly static string[] creditAccountActions = { "deposit", "charge", "addpayment", "print", "quit" };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our bank!\nDo you want to register an account?\n(Yes, No)");
            var customerChoice = Console.ReadLine();
            do
            {
                if (customerChoice == "No" || customerChoice == "NO" || customerChoice == "no")
                {
                    ExitMessage();
                    break;
                }
                else if (customerChoice == "Yes" || customerChoice == "YES" || customerChoice == "yes")
                {
                    Console.WriteLine("Please enter your first name:");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Please enter your last name:");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Please enter your account type to proceed (savings, credit, lottery):");
                    var accountType = Console.ReadLine();
                    while (!accountTypes.Contains(accountType))
                    {
                        Console.WriteLine("Valid account types are savings, credit and lottery.");
                        Console.WriteLine("Please enter your account type to proceed:");
                        accountType = Console.ReadLine();
                    }
                    CreateAccount(firstName, lastName, accountType);
                    ExitMessage();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Do you want to register an account?\n(Yes, No)");
                    customerChoice = Console.ReadLine();
                }

            } while (true);
        }

        static void CreateAccount(string firstName, string lastName, string accountType)
        {
            if (accountType == "savings")
            {
                SavingsAccount account = new SavingsAccount(firstName, lastName);
                ManageSavingsLotteryAccount(account);
            }
            else if (accountType == "credit")
            {
                CreditAccount account = new CreditAccount(firstName, lastName);
                ManageCreditAccount(account);
            }
            else
            {
                LotteryAccount account = new LotteryAccount(firstName, lastName);
                ManageSavingsLotteryAccount(account);
            }
        }

        static void ManageSavingsLotteryAccount(SavingsAccount account)
        {
            while (true)
            {
                Console.WriteLine("Please enter your action (deposit, withdraw, addinterest, print, quit):");
                var action = Console.ReadLine();
                while (!savingsLotteryAccountActions.Contains(action))
                {
                    Console.WriteLine("Valid account actions are deposit, withdraw, addinterest, print and quit.");
                    Console.WriteLine("Please enter your action to proceed:");
                    action = Console.ReadLine();
                }
                if (action == "quit")
                {
                    break;
                }
                else if (action == "print")
                {
                    account.PrintStatementTransaction();
                }
                else if (action == "addinterest")
                {
                    account.AddInterest();
                }
                else if (action == "deposit" || action == "withdraw")
                {
                    Console.WriteLine("Please enter the amount that you want to process");
                    var amount = Decimal.TryParse(Console.ReadLine(), out decimal decimalAmount);
                    while (!amount)
                    {
                        Console.WriteLine("Please enter a valid amount that you want to process (decimal)");
                        amount = Decimal.TryParse(Console.ReadLine(), out decimalAmount);
                    }
                    if (action == "deposit")
                    {
                        account.Deposit(decimalAmount);
                    }
                    else
                    {
                        account.Withdraw(decimalAmount);
                    }
                }

            }
        }

        static void ManageCreditAccount(CreditAccount account)
        {
            while (true)
            {
                Console.WriteLine("Please enter your action (deposit, charge, addpayment, print, quit):");
                var action = Console.ReadLine();
                while (!creditAccountActions.Contains(action))
                {
                    Console.WriteLine("Valid account actions are deposit, charge, addpayment, print and quit.");
                    Console.WriteLine("Please enter your action to proceed:");
                    action = Console.ReadLine();
                }
                if (action == "quit")
                {
                    break;
                }
                else if (action == "print")
                {
                    account.PrintStatementTransaction();
                }
                else if (action == "deposit" || action == "charge" || action == "addpayment")
                {
                    Console.WriteLine("Please enter the amount that you want to process");
                    var amount = Decimal.TryParse(Console.ReadLine(), out decimal decimalAmount);
                    while (!amount)
                    {
                        Console.WriteLine("Please enter a valid amount that you want to process (decimal)");
                        amount = Decimal.TryParse(Console.ReadLine(), out decimalAmount);
                    }
                    if (action == "deposit")
                    {
                        account.Deposit(decimalAmount);
                    }
                    else if (action == "charge")
                    {
                        account.Charge(decimalAmount);
                    }
                    else
                    {
                        account.AddPayment(decimalAmount);
                    }
                }

            }
        }

        static void ExitMessage()
        {
            Console.WriteLine("Thank you for stopping by, have a nice day!");
            Console.ReadKey();
        }
    }
}
