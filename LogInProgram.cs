using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WebShop3;

class LogInProgram
{
    static void Main(string[] args)
    {
        ILoginSystem loginSystem = new LogIn();

        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        if (loginSystem.Register(username, password))
        {
            Console.WriteLine("You are now a registered user");
        }
    }
    
}
