using System;
using System.Collections.Generic;
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
    //enter everything that the user can do
}

else if (loginSystem.Register(username, password, UserRole.User)) //calls on the register method to register a new user
{
    Console.WriteLine("You are now a registered user");
}