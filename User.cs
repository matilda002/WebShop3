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

    private string filePath;

    List<Product> _boughtProducts = new List<Product>();

    public User(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;

        Transaction _transaction = new Transaction(_boughtProducts);
        filePath = $"../../../transactions/transaction_{UserName}";

        SaveTransactionData(_transaction);
        DisplayTransactionData();
    }

    public void DisplayTransactionData()
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
    public void SaveTransactionData(Transaction transaction)
    {
        File.AppendAllText(filePath, transaction.ToString());
    }
}
