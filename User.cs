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

    public void DisplayTransaction()
    {

    }

    public void SaveTransaction(string filePath, Transaction transaction)
    {
        File.AppendAllText(filePath, transaction.ToString());
    }
}

