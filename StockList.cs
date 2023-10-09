namespace WebShop3;

public class StockList
{
    public static void Stock()
    {
        // list for stock and price
        List<string> stock = new List<string>();
        List<int> price = new List<int>();

        // dictonary for items in stock with their price
        Dictionary<string, int> stockPrice = new Dictionary<string, int>();


        string? inputItem = string.Empty;
        // admin adding items to the stock list
        Console.Write("Add item to list: ");
        inputItem = Console.ReadLine().ToLower();
        stock.Add(inputItem);

        // admin setting a price for the corresponding item
        Console.Write("Set a price for the item: ");
        int inputPrice = Convert.ToInt32(Console.ReadLine());
        price.Add(inputPrice);



        // adding the item + price in the dictonary
        for (int i = 0; i < stock.Count; i++)
        {
            for (int j = 0; j < price.Count; j++)
            {
                stockPrice.Add(stock[i], price[j]);
            }
        }

        // delete items from dictonary, admin need to type in the specific item
        bool validInput = false;
        while (!validInput)
        {
            Console.Clear();
            foreach (var item in stockPrice)
            {
                Console.WriteLine(item);
            }

            string? deleteStock = string.Empty;

            while (deleteStock.Length == 0) // makes sure user cannot remove item from stock if answer is null
            {
                Console.Write("Write the name of the product you'd like to remove:  ");
                deleteStock = Console.ReadLine()?.ToLower();
            }

            if (stockPrice.ContainsKey(deleteStock)) // program looks in the dictonary to search for a matching name
            {
                stockPrice.Remove(deleteStock);
                Console.WriteLine(deleteStock + " was removed!");
                validInput = true;
            }
            else
                Console.WriteLine("\n" + deleteStock + " does not exist in the range of products!\nMake sure the spelling is correct and try again");


            Console.WriteLine("\nPress the ENTER key to continue!"); // holding program so the user can see the result before clearing screen
            Console.ReadKey();
        }
    }
}