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

        if (user.Role == UserRole.Admin)
        {
            Console.WriteLine(user.Role + " logged in,welcome, " + username + ", you are now logged in");
            return true;
        }
        else if (user.Role == UserRole.User)
        {
            Console.WriteLine("Welcome, " + username + ", you are now logged in");
            return true;
        }
        else
        {
            Console.WriteLine("Log in failed");
            return false;
        }
    }

    public void Logout()
    {
        Console.WriteLine("Logged out");
    }

    public bool Register(string username, string password, UserRole role = UserRole.User)
    {
        if (users.Exists(u => u.UserName == username))
        {
            Console.WriteLine("Logging in...");
            return true;
        }

        User newUser = new User(username, password, role);
        users.Add(newUser);

        string userFilePath = $"../../../Users/{username}.txt";
        if (!File.Exists(userFilePath))
        {
            SaveUsers(newUser);
            Console.WriteLine("Registration successful");
        }

        return false;
    }

    private List<User> LoadUsers()
    {
        List<User> loadedUsers = new List<User>();
        string[] userFiles = Directory.GetFiles("../../../Users", "*.txt");

        foreach (string userFile in userFiles)
        {
            string[] lines = File.ReadAllLines(userFile);
            if (lines.Length == 3)
            {
                string username = lines[0];
                string password = lines[1];
                UserRole role = Enum.Parse<UserRole>(lines[2]);
                loadedUsers.Add(new User(username, password, role));
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