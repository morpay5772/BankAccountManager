/*
Name: Moriah Payne
Date: 5/25/2025
Description: Week 2 - Bank Account Management Application
*/
public class Savings : Account
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
    public override void DisplayInfo()
    {
        Console.WriteLine($"Account Type: {AccountType}");
        base.DisplayInfo();
    }
}