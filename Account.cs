/*
Name: Moriah Payne
Date: 6/8/2025
Assignment: Week 4 - Bank Account Management Application
Description: abstract base class for bank accounts. Demonstrates abstraction, constructors, and access specifiers
*/
public abstract class Account
{
    public string AccountId { get; set; }
    public User? AccountHolder { get; set; } //demonstrates composition because accounts have a user
    public double Balance { get; protected set; }
    //default constructor
    protected Account()
    {
        AccountId = "000000";
        Balance = 0.00;
    }
    public Account(string accountId, User accountHolder, double balance)
    {
        AccountId = accountId;
        AccountHolder = accountHolder;
        Balance = balance;
    }
    public virtual void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount:F2} into {AccountId}. New balance: ${Balance:F2}");
        }
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
    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine($"Account ID: {AccountId}");
    if (AccountHolder != null)
    {
        Console.WriteLine($"User Name: {AccountHolder.Name}");
    }
    else
    {
        Console.WriteLine("User Name: Unknown (AccountHolder is null)");
    }
    Console.WriteLine($"Balance: ${Balance:F2}");
    Console.WriteLine();
    }
}