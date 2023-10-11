namespace WebShop3;
public class LogIn : ILoginSystem
{
    private List<User> users;
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

        SaveUsers(newUser);
        Console.WriteLine("Registration successful");
        return true;
    }

    private List<User> LoadUsers()
    {
        List<User> loadedUsers = new List<User>();
        string[] userFiles = Directory.GetFiles("../../../Users", "*.txt");

        foreach (string userFile in userFiles)
        {
            string[] lines = File.ReadAllLines(userFile);
            if (lines.Length == 2)
            {
                string username = lines[0];
                string password = lines[1];
                loadedUsers.Add(new User(username, password));
            }
        }
        return loadedUsers;
    }
    private void SaveUsers(User user)
    {
        string userFilePath = $"../../../Users/{user.UserName}.txt";
        File.WriteAllText(userFilePath, $"{user.UserName}\n{user.PassWord}");
    }
}