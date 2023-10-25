namespace WebShop3;

public class TransactionOverview
{
    public string? username = string.Empty;
    public void UserTransaction()
    {
        // Loops until there is a matching username
        bool valid = false;
        do
        {
            Console.Clear();
            Console.WriteLine("----- Transaction Overview -----\n");
            Console.Write("Enter a username: ");
            username = Console.ReadLine();
            // program searching for a file with the same name
            switch (File.Exists($"../../../transactions/transaction_{username}"))
            {
                case (true):
                    OpenTransaction();
                    valid = true; break;
            }
        } while (!valid);
    }
    private void OpenTransaction()
    {
        Console.Clear();
        string[] _transactionFile = File.ReadAllLines($"../../../transactions/transaction_{username}");
        foreach (string line in _transactionFile)
        {
            Console.WriteLine(line);
        }
        Console.Write("\n\nPress 'ENTER' to quit!");
        Console.ReadKey();
        return;
    }
}