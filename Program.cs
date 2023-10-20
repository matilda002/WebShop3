using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebShop3;

if (!File.Exists("products.csv"))
{
    File.Create("products.csv").Close();
}

ILoginSystem loginSystem = new LogIn();

Console.WriteLine("Enter username: ");
string username = Console.ReadLine().ToLower();

Console.WriteLine("Enter password: ");
string password = Console.ReadLine();

if (loginSystem.Login(username, password))
{
    UserRole userRole = GetRole(username); //reads the role from the method

    if (userRole == UserRole.Admin)
    {
        // admin specific actions
    }
    else
    {
        //user specific actions   

        User user = new User(username, password);

        Transaction transaction = new Transaction();
        user.SaveTransaction(transaction);
    }
}

static UserRole GetRole(string username)
{
    string userFilePath = $"../../../Users/{username}.txt"; // finds directory of user files

    if (File.Exists(userFilePath))
    {
        string[] lines = File.ReadAllLines(userFilePath); //reads all lines in the user .txt file
        if (lines.Length >= 3)
        {
            string roleString = lines[2]; //saves the third row, as that's where the role is saved in the .txt file
            if (Enum.TryParse(roleString, out UserRole role)) // parse string into the corresponding enum value
            {
                return role;
            }
        }
    }
    return UserRole.User; // default to the user file if it doesn't exist or is incorrect
}