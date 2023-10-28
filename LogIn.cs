namespace WebShop3;
public class LogIn : ILoginSystem
{
    private List<User> users;
    public LogIn() // loading data from user list
    {
        users = LoadUsers();
    }
    // method to handle user login
    public bool Login(string username, string password)
    {
        //looks for the user with the username the user provided
        User user = users.Find(u => u.UserName == username && u.PassWord == password);

        if (user != null)
        {
            if (user.Role == UserRole.Admin) // checks to see if it's an admin that logged in
            {
                Console.WriteLine(user.Role + " logged in, welcome, " + username);
                Console.WriteLine("\n\nPress 'ENTER' to continue!");
                Console.ReadKey();
            }
            else if (user.Role == UserRole.User) // checks to see if its a user that logged in
            {
                Console.WriteLine("Welcome, " + username + ", you are now logged in");
                Console.WriteLine("\n\nPress 'ENTER' to continue!");
                Console.ReadKey();
            }
            return true;
        }
        else
        {
            // if log in failed
            Console.WriteLine("Log in failed");
            return false;
        }

    }

    //Method for future use when handling logging out
    public void Logout()
    {
        Console.WriteLine("Logged out");
    }
    // handles new registrations
    public bool Register(string username, string password, UserRole role = UserRole.User) // only users can registrate new accounts
                                                                                          // admins have to be created manually via the "database"
    {
        if (users.Exists(u => u.UserName == username))
        {
            // logging in if username already exists
            Console.WriteLine("Logging in...");
            Console.WriteLine("\n\nPress 'ENTER' to continue!");
            Console.ReadKey();
            return true;
        }

        User newUser = new User(username, password, role); //creates a new user with the provided information
        users.Add(newUser);

        string userFilePath = $"../../../Users/{username}.txt"; // saves the user information to a textfile. the .txt file has the same name as the user
        if (!File.Exists(userFilePath))
        {
            SaveUsers(newUser); //saves the user
            Console.WriteLine("Registration successful");
            Console.WriteLine("\n\nPress 'ENTER' to continue!");
            Console.ReadKey();
        }

        return false;
    }

    // loads all users, so the program knows
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
                UserRole role = Enum.Parse<UserRole>(lines[2]); // writes all the information on different lines
                loadedUsers.Add(new User(username, password, role));
            }
        }
        return loadedUsers;
    }
    // method to save the users to a textfile
    private void SaveUsers(User user)
    {
        string userFilePath = $"../../../Users/{user.UserName}.txt";
        File.WriteAllText(userFilePath, $"{user.UserName}\n{user.PassWord}\n{user.Role}");
    }
}