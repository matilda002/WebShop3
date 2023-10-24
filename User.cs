using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WebShop3;

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
<<<<<<< HEAD
    public UserRole Role { get; set; }


    private string filePath;

    List<Product> _boughtProducts = new List<Product>();

    public User(string userName, string passWord, UserRole role = UserRole.User)
    {
=======
>>>>>>> 3d18adf435594f857c54b349b6829be9f5b1280f

    private string filePath;

    List<Product> _boughtProducts = new List<Product>();

    public User(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;
<<<<<<< HEAD
        Role = role;
        Transaction _transaction = new Transaction(_boughtProducts);
        filePath = $"../../../transactions/transaction_{UserName}";

=======

        Transaction _transaction = new Transaction(_boughtProducts);
        filePath = $"../../../transactions/transaction_{UserName}";

>>>>>>> 3d18adf435594f857c54b349b6829be9f5b1280f
        SaveTransactionData(_transaction);
        DisplayTransactionData();
    }

<<<<<<< HEAD
    void DisplayTransactionData()
=======
    public void DisplayTransactionData()
>>>>>>> 3d18adf435594f857c54b349b6829be9f5b1280f
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
<<<<<<< HEAD
    void SaveTransactionData(Transaction transaction)
=======
    public void SaveTransactionData(Transaction transaction)
>>>>>>> 3d18adf435594f857c54b349b6829be9f5b1280f
    {
        File.AppendAllText(filePath, transaction.ToString());
    }
}
