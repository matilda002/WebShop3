namespace WebShop3;

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public UserRole Role { get; set; }


    private string filePath;

    List<Product> _boughtProducts = new List<Product>();

    public User(string userName, string passWord, UserRole role = UserRole.User)
    {

        UserName = userName;
        PassWord = passWord;
        Role = role;
        Transaction _transaction = new Transaction(_boughtProducts);
        filePath = $"../../../transactions/transaction_{UserName}";

        SaveTransactionData(_transaction);
        DisplayTransactionData();
    }

    void DisplayTransactionData()
    {
        string[] contentOfFile = File.ReadAllLines(filePath);

        foreach (string line in contentOfFile)
        {
            string[] info = line.Split(", ");

            Product product = new Product(contentOfFile[0], int.Parse(contentOfFile[1]));
            _boughtProducts.Add(product);
            Transaction transaction = new Transaction(_boughtProducts);
            Console.WriteLine(transaction.ToString());
        }
    }

    // Transaction
    void SaveTransactionData(Transaction transaction)
    {
        File.AppendAllText(filePath, transaction.ToString());
    }
}

