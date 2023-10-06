using WebShop3;

List<Product> boughtProducts = new List<Product>
{
    new Product("x", 1),
    new Product("y", 3),
    new Product("z", 5),
};

Transaction transaction = new Transaction(boughtProducts, 
                                                                     22, 
                                                                     DateTime.Now);

Console.WriteLine(transaction.ToString());
SaveTransactionData(transaction,
                                    "user123");

 void SaveTransactionData(Transaction transaction, string userWhoOrdered)
{
    string filePath = "../../../transaction_" +
                               userWhoOrdered +
                               ".txt";
    File.WriteAllText(filePath, transaction.ToString());
}