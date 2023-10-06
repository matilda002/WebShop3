using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;
public class LogIn : ILoginSystem
{
    private List<User> users;
    public string UsersFilePath = ("../../../Users/Users.txt");


    public LogIn()
    {
        users = LoadUsers();
    }
    public bool Login(string username, string password)
    {
        User user = users.Find(u => u.UserName == username && u.PassWord == password);

        if (user != null)
        {
            Console.WriteLine("Welcome, " + username + ", you are now logged in");
            return true;
        }
        else
        {
            Console.WriteLine("Login failed");
            return false;
        }
    }

    public void Logout()
    {
        Console.WriteLine("Logged out");
    }

    public bool Register(string username, string password)
    {
        if (users.Exists(u => u.UserName == username))
        {
            Console.WriteLine("Username already exists. Registration failed.");
            return false;
        }

        User newUser = new User(username, password);
        users.Add(newUser);
        SaveUsers(users);
        Console.WriteLine("Registration successfull");
        return true;
    }

    private List<User> LoadUsers()
    {
        List<User> loadedUsers = new List<User>();
        if (File.Exists(UsersFilePath))
        {
            string[] lines = File.ReadAllLines(UsersFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(", ");
                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string password = parts[1];
                    loadedUsers.Add(new User(username, password));
                }
            }
        }
        return loadedUsers;
    }
    private void SaveUsers(List<User> userList)
    {
        List<string> lines = new List<string>();
        foreach(User user in userList)
        {
            lines.Add($"{user.UserName},{user.PassWord}");
        }
        File.WriteAllLines(UsersFilePath, lines);
    }
}