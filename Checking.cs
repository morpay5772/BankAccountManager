/*
Name: Moriah Payne
Date: 5/25/2025
Description: Week 2 - Bank Account Management Application
*/
public class Checking : Account
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
    public override void DisplayInfo()
    {
        Console.WriteLine($"Account Type: {AccountType}");
        base.DisplayInfo();
    }
}