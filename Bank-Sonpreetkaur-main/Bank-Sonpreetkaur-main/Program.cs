using System;
using System.Collections.Generic;

class Program

{
    static List<Account> accounts = new List<Account>();

    static void Main(string[] args)

    {
        while (true)


        {
            Console.WriteLine("Choose an operation:");

            Console.WriteLine("1. View accounts");

            Console.WriteLine("2. Create an account");

            Console.WriteLine("3. Deposit");

            Console.WriteLine("4. Withdraw");

            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            
            switch (choice)


            {
                case "1":
                    ViewAccounts();
                    break;

                case "2":
                    CreateAccount();
                    break;

                case "3":
                    Deposit();
                    break;

                case "4":
                    Withdraw();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }

        }

    }

    static void ViewAccounts()

    {
        if (accounts.Count == 0)

        {
            Console.WriteLine("No accounts found.");

        }

        else

        {
            foreach (var account in accounts)

            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Owner: {account.OwnerName}, Balance: {account.Balance}");

            }

        }

    }

    static void CreateAccount()

    {
        Console.Write("Enter the account owner's name: ");

        string ownerName = Console.ReadLine();


        if (string.IsNullOrEmpty(ownerName))

        {
            
            Console.WriteLine("Name cannot be empty.");
            return;

        }


        Console.Write("Enter the initial account balance: ");

        if (double.TryParse(Console.ReadLine(), out double initialBalance) && initialBalance >= Account.MinimumInitialBalance)

        {
            var newAccount = new Account(ownerName, initialBalance);
            accounts.Add(newAccount);
            Console.WriteLine($"Account created successfully. Account Number: {newAccount.AccountNumber}, Owner: {newAccount.OwnerName}, Balance: {newAccount.Balance}");

        }

        else

        {
            Console.WriteLine($"Initial balance must be a number and at least {Account.MinimumInitialBalance}.");

        }

    }


    static void Deposit()

    {
        Console.Write("Enter the account number: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber))

        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)

            {
                Console.WriteLine("Account not found.");
                return;

            }

            Console.Write("Enter the deposit amount: ");

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)

            {
                account.Deposit(amount);
                Console.WriteLine($"Deposit successful. New Balance: {account.Balance}");
            }


            else

            {
                Console.WriteLine("Invalid deposit amount.");
                

            }

        }

        else

        {
            Console.WriteLine("Invalid account number.");

        }

    }

    static void Withdraw()

    {
        Console.Write("Enter the account number: ");

        if (int.TryParse(Console.ReadLine(), out int accountNumber))

        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)

            {
                Console.WriteLine("Account not found.");
                return;

            }

            Console.Write("Enter the withdrawal amount: ");

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0 && amount <= account.Balance)

            {
                account.Withdraw(amount);
                Console.WriteLine($"Withdrawal successful. New Balance: {account.Balance}");

            }

            else

            {
                Console.WriteLine("Invalid withdrawal amount.");

            }

        }

        else

        {
            Console.WriteLine("Invalid account number.");

        }

    }

}
