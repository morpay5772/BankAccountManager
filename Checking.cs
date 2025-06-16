/*
Name: Moriah Payne
Date: 6/8/2025
Assignment: Week 4 - Bank Account Management Application
Description: derived class demonstrates inheritance, overriding abstract methods, and constructors
*/
public class Checking : Account, ITransaction
//class demonstrates inheritance because the Checking class is derived from the Account class
{
    public string AccountType { get; set; }
    public Checking(string accountId, User accountHolder, double balance)
        : base(accountId, accountHolder, balance)
    {
        AccountType = "Checking";
    }
    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
    }
    public override void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Type: {AccountType}");
        base.DisplayAccountInfo();
    }
}