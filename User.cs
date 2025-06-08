/*
Name: Moriah Payne
Date: 5/25/2025
Description: Week 2 - Bank Account Management Application
*/
public class User
//Class demonstrates composition because accounts have a user
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public User(int userId, string name)
    {
        UserId = userId;
        Name = name;
    }
}