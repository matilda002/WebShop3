using System.Reflection.Metadata.Ecma335;

namespace WebShop3;

public interface IStockList
{
    public static void StockMenu()
    {
        string? forward = string.Empty;
        do
        {
            Console.Clear();
            Console.Write("Do you want to edit the range of products?\nWrite 'y' or 'n':  ");
            forward = Console.ReadLine()?.ToLower();

            switch (forward)
            {
                case "y":
                    EditStock();
                    break;
                case "n":
                    Console.WriteLine("You have chosen to quit!");
                    break;
                default:
                    Console.WriteLine("Unvalid answer, try again by pressing the ENTER key!");
                    Console.ReadKey();
                    break;
            }
        }
        while (forward != "n");
    }

    public static void EditStock()
    {
        Console.Clear();

        // list for stock and price
        List<string> stock = new List<string>();
        List<int> price = new List<int>();
        // dictonary for items in stock with their price
        Dictionary<string, int> stockPrice = new Dictionary<string, int>();

        // admin cannot enter an item if the answer is null
        string? inputItem = string.Empty;
        while (inputItem.Length == 0)
        {
            Console.Write("Add item to list: ");
            inputItem = Console.ReadLine()?.ToLower();
            stock.Add(inputItem);
        }

        bool validPrice = false;
        while (!validPrice)
        {
            // admin setting a price for the corresponding item
            Console.Write("Set a price for " + inputItem + ": ");
            bool parsePrice = int.TryParse(Console.ReadLine()?.ToLower(), out int successful); // parse to make sure the price contains just numbers

            if (parsePrice == true)
            {
                price.Add(successful);
                validPrice = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a valid input, try again by pressing the ENTER key");
                Console.ReadKey();
            }
        }

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
            foreach (var item in stockPrice) // printing out dictonary 
            {
                Console.WriteLine(item);
            }

            string? deleteStock = string.Empty;
            while (deleteStock?.Length == 0) // makes sure user cannot remove item from stock if answer is null
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
            {
                Console.WriteLine("\n" + deleteStock + " does not exist in the range of products!\nMake sure the spelling is correct and try again");
            }

            Console.WriteLine("\nPress the ENTER key to continue!"); // holding program so the user can see the result before clearing screen
            Console.ReadKey();
        }
    }
}