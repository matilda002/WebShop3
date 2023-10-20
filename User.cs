namespace WebShop3;

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public UserRole Role { get; set; }
    public User(string userName, string passWord, UserRole role = UserRole.User)
    {

        UserName = userName;
        PassWord = passWord;
        Role = role;
    }

    public void DisplayTransaction(Transaction transaction)
    {
        Console.WriteLine(transaction.ToString());
    }

    public void SaveTransaction(Transaction transaction)
    {
        string filePath = $"transaction_{UserName}.txt";
        File.AppendAllText(filePath, transaction.ToString());
    }
}

