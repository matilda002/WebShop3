namespace WebShop3;

public interface IStockList
{
    public static void Stock()
    {
        // List for stock and price
        List<string> stock = new List<string>();
        List<int> price = new List<int>();

        // Dictonary for items in stock with their price
        Dictionary<string, int> stockPrice = new Dictionary<string, int>();

        // Admin adding items to the stock list
        Console.Write("Add item to list: ");
        stock.Add(Console.ReadLine());

        // Admin setting a price for the corresponding item
        Console.Write("Set a price for the item: ");
        price.Add(Convert.ToInt32(Console.ReadLine()));


        // adding the item + price in the dictonary
        for (int i = 0; i < stock.Count; i++)
        {
            for (int j = 0; j < price.Count; j++)
            {
                stockPrice.Add(stock[i], price[j]);
            }
        }

        // printing out the dictonary containing item + price
        foreach (var item in stockPrice)
        {
            Console.WriteLine(item);

        }
    }
}
