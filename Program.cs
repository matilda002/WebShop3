using System.IO;
using System.Xml.Linq;
using WebShop3;


Console.WriteLine("Hello, enter the name of the user you want to register");


User user = new();
user.Name = Console.ReadLine();

Console.WriteLine("Please enter your email");

user.Email = Console.ReadLine();

Console.WriteLine("Please enter the password you want to use");
user.PassWord = Console.ReadLine();

string path = "../../../Users/" (user.Name, ".txt");
File.WriteAllText(path, user.Name + ", " + user.Email + ", " + user.PassWord);