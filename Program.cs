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

if (loginSystem.Register(username, password, UserRole.User))
{
    Console.WriteLine("You are now a registered user");
}

//Log in the user
if (loginSystem.Login(username, password))
{
    Console.WriteLine("You are now logged in");
}