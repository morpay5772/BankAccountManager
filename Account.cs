/*
Name: Moriah Payne
Date: 5/25/2025
Description: Week 2 - Bank Account Management Application
*/
public class Account : ITransaction
{
    public string AccountId { get; set; }
    public User AccountHolder { get; set; } //demonstrates composition because accounts have a user
    public double Balance { get; protected set; }
    public Account(string accountId, User accountHolder, double balance)
    {
        AccountId = accountId;
        AccountHolder = accountHolder;
        Balance = balance;
    }
    public virtual void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited ${amount:F2} into {AccountId}. New balance: ${Balance:F2}");
    }
    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine($"Insufficient funds in {AccountId}.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2} from {AccountId}. New balance: ${Balance:F2}");
        }
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Account ID: {AccountId}");
        Console.WriteLine($"User Name: {AccountHolder.Name}");
        Console.WriteLine($"Balance: ${Balance:F2}");
        Console.WriteLine();
    }
}