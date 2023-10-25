namespace WebShop3;

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public UserRole Role { get; set; }


    private string filePath;

    public List<Product> BoughtProducts = new List<Product>();

    public User(string userName, string passWord, UserRole role = UserRole.User)
    {

        UserName = userName;
        PassWord = passWord;
        Role = role;

        filePath = $"../../../transactions/transaction_{UserName}";
    }

    public void GetProductsFromFile()
    {
        string[] contentOfFile = File.ReadAllLines("../../../");

        foreach (string line in contentOfFile)
        {
            string[] info = line.Split(", ");

            Product product = new Product(contentOfFile[0], int.Parse(contentOfFile[1]));
            BoughtProducts.Add(product);
            Transaction transaction = new Transaction(UserName, BoughtProducts);
            Console.WriteLine(transaction.ToString());
        }
    }

    public void DisplayTransactionData()
    {
        string[] contentOfFile = File.ReadAllLines(filePath);

        foreach (string line in contentOfFile)
        {
            string[] info = line.Split(", ");

            Product product = new Product(contentOfFile[0], int.Parse(contentOfFile[1]));
            BoughtProducts.Add(product);
            Transaction transaction = new Transaction(UserName, BoughtProducts);
            Console.WriteLine(transaction.ToString());
        }
    }

    // Transaction
    public void SaveTransactionData(Transaction transaction)
    {
        File.AppendAllText(filePath, transaction.ToString());
    }
}