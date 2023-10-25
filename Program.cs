
﻿using System;
using System.Collections.Generic;
using WebShop3;

if (!File.Exists("products.csv"))
{
    File.Create("products.csv").Close();
}

ILoginSystem loginSystem = new LogIn();

Console.WriteLine("Enter username: ");
string username = Console.ReadLine();

Console.WriteLine("Enter password: ");
string password = Console.ReadLine();

if (loginSystem.Register(username, password))
{
    Console.WriteLine("You are now a registered user");
}


