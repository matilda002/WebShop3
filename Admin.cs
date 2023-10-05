using System.Threading.Channels;

namespace WebShop3;

public class Admin : TempoaryUser
{

    public Admin (string username, string email) : base(username, email)
    {

    }

    // list for the items and their price
    public static void Stockist()
    {
        Dictionary<string, int> stockPrice = new Dictionary<string, int>();

        stockPrice.Add("apple", 12);
        stockPrice.Add("orange", 20);
        stockPrice.Add("pear", 6);
        stockPrice.Add("plum", 70);
        stockPrice.Add("banana", 50);

        foreach (var item in stockPrice)
        {
            Console.WriteLine(item);
        }
    }
    
}