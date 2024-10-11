using System;

public class Account
{
    private static Random random = new Random();

    public int AccountNumber { get; private set; }

    public string OwnerName { get; private set; }

    public double Balance { get; private set; }


    public const double MinimumInitialBalance = 100.0;

    public Account(string ownerName, double initialBalance)

    {
        AccountNumber = random.Next(1, int.MaxValue);
        OwnerName = ownerName;
        Balance = initialBalance;

    }

    public void Deposit(double amount)

    {
        if (amount > 0)
        {
            Balance += amount;
            
        }

    }

    public void Withdraw(double amount)

    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;

        }

    }
    
}

