/*
Name: Moriah Payne
Date: 6/8/2025
Assignment: Week 4 - Bank Account Management Application
Description: represents a user, demonstrates constructors and access specifiers
*/
public class User
//Class demonstrates composition because accounts have a user
{
    public int UserId { get; set; }
    public string Name { get; private set; }
    private List<Account> accounts;
    public User(int userId, string name)
    {
        UserId = userId;
        Name = name;
        accounts = new List<Account>();
    }
    public void AddAccount(Account acct)
    {
        accounts.Add(acct);
    }
    public void DisplayAccounts()
    {
        Console.WriteLine($"\n{Name}'s Accounts:");
        foreach (Account acct in accounts)
        {
            acct.DisplayAccountInfo();
        }
    }
}