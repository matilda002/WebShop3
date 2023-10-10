using WebShop3;

List<Product> _boughtProducts = new List<Product>
{
    new Product("x", 1),
    new Product("y", 3),
    new Product("z", 5),
};

Transaction _transaction = new Transaction(_boughtProducts, DateTime.Now);

Console.WriteLine(_transaction.ToString());
SaveTransactionData(_transaction,
                                    "user123");

void SaveTransactionData(Transaction transaction, string userWhoOrdered)
{
    string filePath = "../../../transaction_" +
                               userWhoOrdered +
                               '_' +
                               DateTime.Now.ToString("yyyyMMdd_hhmmss") +
                               ".txt";
    File.WriteAllText(filePath, transaction.ToString());
}