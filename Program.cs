/*
Name: Moriah Payne
Date: 5/25/2025
Description: Week 2 - Bank Account Management Application
*/
public class Application
{
    static void Main(string[] args)
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Week 2 Bank Account Management Application");
        Console.WriteLine("       Developed by Moriah Payne          ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("\"Money often costs too much.\" - Ralph Waldo Emerson\n");
        Console.WriteLine("Welcome! This is a demonstration of inheritance, composition, interfaces, and polymorphism.\n");

        // Create a list to hold multiple account types with an interface
        List<ITransaction> accounts = new List<ITransaction>();

        //Creating user instances demonstrates composition
        User user1 = new User(101, "John Doe");
        User user2 = new User(102, "Jane Smith");
        User user3 = new User(103, "Andrew Garfunkel");

        //creating accounts demonstrates both inheritance and compsition
        Checking checkingAccount1 = new Checking("CHK001", user1, 1500.00);
        Savings savingsAccount1 = new Savings("SAV001", user2, 2500.00);
        Savings savingsAccount2 = new Savings("SAV002", user3, 5000.00);

        //adding the account instances to the list of accounts 
        accounts.Add(checkingAccount1);
        accounts.Add(savingsAccount1);
        accounts.Add(savingsAccount2);

        //permorm transactions using polymorphism
        Console.WriteLine("--------- Performing Transactions --------");
        foreach (ITransaction account in accounts)
        {
            account.Deposit(500);
            account.Withdraw(300);
            account.Deposit(1000);
            Console.WriteLine();
        }

        //display account information using polymorphism
        Console.WriteLine("----------- Account Information ----------");
        foreach (ITransaction account in accounts)
        {
            ((Account)account).DisplayInfo();
        }
    }
}