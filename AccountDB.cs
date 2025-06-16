/*
Name: Moriah Payne
Date: 6/8/2025
Assignment: Week 4 - Bank Account Management Application
Description: handles database operations, demonstrates abstraction, use of constructors and access specifiers
*/
using System.Data.SQLite;
//abstraction for isolating logic
public static class AccountDB
{
    public static void CreateTables(SQLiteConnection conn)
    {
        string createUsers = @"CREATE TABLE IF NOT EXISTS Users (
            UserId INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL);";

        string createAccounts = @"CREATE TABLE IF NOT EXISTS Accounts (
            AccountId INTEGER PRIMARY KEY AUTOINCREMENT,
            UserId INTEGER,
            Type TEXT NOT NULL,
            Balance REAL,
            FOREIGN KEY(UserId) REFERENCES Users(UserId));";
        //constructor and abstraction
        new SQLiteCommand(createUsers, conn).ExecuteNonQuery();
        new SQLiteCommand(createAccounts, conn).ExecuteNonQuery();
    }

    public static void AddUser(SQLiteConnection conn)
    {
        Console.Write("Enter user's name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name.");
            return;
        }
        string insert = "INSERT INTO Users (Name) VALUES (@Name)";
        var cmd = new SQLiteCommand(insert, conn);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.ExecuteNonQuery();
        Console.WriteLine("User added successfully.");
    }

    public static void AddAccountToUser(SQLiteConnection conn)
    {
        //composition - account has a user
        Console.Write("Enter user ID to add account to: ");
        string? inputId = Console.ReadLine();
        if (!int.TryParse(inputId, out int userId))
        {
            Console.WriteLine("Invalid user ID.");
            return;
        }
        Console.Write("Enter account type (Checking/Savings): ");
        string? type = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(type))
        {
            Console.WriteLine("Invalid account type.");
            return;
        }
        Console.Write("Enter initial balance: ");
        string? inputBal = Console.ReadLine();
        if (!double.TryParse(inputBal, out double balance))
        {
            Console.WriteLine("Invalid balance.");
            return;
        }
        string insert = "INSERT INTO Accounts (UserId, Type, Balance) VALUES (@UserId, @Type, @Balance)";
        var cmd = new SQLiteCommand(insert, conn);
        cmd.Parameters.AddWithValue("@UserId", userId);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Balance", balance);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Account added successfully.");
    }

    public static void ViewUsersAndAccounts(SQLiteConnection conn)
    {
        //read operation - abstraction
        string query = @"SELECT u.UserId, u.Name, a.AccountId, a.Type, a.Balance
                         FROM Users u LEFT JOIN Accounts a ON u.UserId = a.UserId
                         ORDER BY u.UserId;";

        var cmd = new SQLiteCommand(query, conn);
        var reader = cmd.ExecuteReader();

        Console.WriteLine("\nUsers and Accounts:");
        while (reader.Read())
        {
            int userId = reader.GetInt32(0);
            string name = reader.GetString(1);
            object acctId = reader[2];
            object type = reader[3];
            object balance = reader[4];

            Console.WriteLine($"User ID: {userId}, Name: {name}, " +
                              $"Account ID: {acctId}, Type: {type}, Balance: {balance:C}");
        }
    }

    public static void UpdateAccountBalance(SQLiteConnection conn)
    {
        //update operation - constructor
        Console.Write("Enter Account ID to update: ");
        string? inputId = Console.ReadLine();
        if (!int.TryParse(inputId, out int acctId))
        {
            Console.WriteLine("Invalid account ID.");
            return;
        }
        Console.Write("Enter new balance: ");
        string? inputBal = Console.ReadLine();
        if (!double.TryParse(inputBal, out double newBalance))
        {
            Console.WriteLine("Invalid balance.");
            return;
        }
        string update = "UPDATE Accounts SET Balance = @Balance WHERE AccountId = @Id";
        var cmd = new SQLiteCommand(update, conn);
        cmd.Parameters.AddWithValue("@Balance", newBalance);
        cmd.Parameters.AddWithValue("@Id", acctId);
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("Balance updated.");
        else
            Console.WriteLine("Account not found.");
    }

    public static void DeleteAccount(SQLiteConnection conn)
    {
        //delete operation
        Console.Write("Enter Account ID to delete: ");
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out int acctId))
        {
            Console.WriteLine("Invalid account ID.");
            return;
        }
        string delete = "DELETE FROM Accounts WHERE AccountId = @Id";
        var cmd = new SQLiteCommand(delete, conn);
        cmd.Parameters.AddWithValue("@Id", acctId);
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("Account deleted.");
        else
            Console.WriteLine("Account not found.");
    }
}