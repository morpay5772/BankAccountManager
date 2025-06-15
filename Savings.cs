/*
Name: Moriah Payne
Date: 6/1/2025
Assignment: Week 3 - Bank Account Management Application
Description: derived class demonstrating inheritance, overriding abstract methods, and constructors
*/
public class Savings : Account, ITransaction
//class demonstrates inheritance because the Savings class is derived from the Account class
{
    public string AccountType { get; set; }
    public Savings(string accountId, User accountHolder, double balance)
        : base(accountId, accountHolder, balance)
    {
        AccountType = "Savings";
    }
    public override void Withdraw(double amount)
    {
        if (amount > 1000)
        {
            Console.WriteLine("Withdrawal limit exceeded for Savings Account.");
        }
        else
        {
            base.Withdraw(amount);
        }
    }
    public override void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Type: {AccountType}");
        base.DisplayAccountInfo();
    }
}