/*
Name: Moriah Payne
Date: 6/8/2025
Assignment: Week 4 - Bank Account Management Application
Description: main application - demonstrates abstraction, constructors, access specifiers, and displays instances
*/
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
public class BankApplication
{
    static string dbName = "MPBankApp.db";
    static void Main(string[] args)
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Week 4 Bank Account Management Application");
        Console.WriteLine("       Developed by Moriah Payne          ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("\"Money often costs too much.\" - Ralph Waldo Emerson\n");
        Console.WriteLine("Welcome! This is a demonstration of CRUD, abstraction, constructors, access specifiers, inheritance, composition, interfaces, and polymorphism.\n");
        //creates database file
        if (!File.Exists(dbName))
        {
            //abstraction
            SQLiteConnection.CreateFile(dbName);
        }
        //constructor
        using var conn = new SQLiteConnection($"Data Source={dbName};Version=3;");
        conn.Open();
        //abstraction
        AccountDB.CreateTables(conn);
        //user menu
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Add Account to User");
            Console.WriteLine("3. View All Users and Accounts");
            Console.WriteLine("4. Update Account Balance");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(choice))
            {
                string name = choice;
            }
            else
            {
                Console.WriteLine("Name is required.");
            }
            switch (choice)
            {
                case "1":
                    AccountDB.AddUser(conn);
                    break;
                case "2":
                    AccountDB.AddAccountToUser(conn);
                    break;
                case "3":
                    AccountDB.ViewUsersAndAccounts(conn);
                    break;
                case "4":
                    AccountDB.UpdateAccountBalance(conn);
                    break;
                case "5":
                    AccountDB.DeleteAccount(conn);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}