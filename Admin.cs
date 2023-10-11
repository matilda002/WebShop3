namespace WebShop3;

public class Admin : IStockMenu
{
    // dictonary for items in stock with their price
    public Dictionary<string, int> stockPrice = new Dictionary<string, int>();

    public void StockMenu()
    {
        string? forward = string.Empty;
        do // doing a loop since I don't want to return to the main menu until there's a valid answer
        {
            Console.Clear();
            // asking if the user wants to go foward and change any products
            Console.Write("Do you want to change the range of products?\nWrite 'y' (yes) or 'n' (no):  ");
            forward = Console.ReadLine()?.ToLower();

            switch (forward)
            {
                case "y":
                case "yes":
                    StockMenu2();
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

    public void StockMenu2()
    {
        string? forward2 = string.Empty;
        do
        {
            Console.Clear();
            // asking if the user wants to add or remove items
            Console.Write("Do you want to add or remove items?\nWrite 'a' (add) or 'r' (remove)\nTo quit answer 'q' (quit):  ");
            forward2 = Console.ReadLine()?.ToLower();

            switch (forward2)
            {
                case "a":
                case "add":
                    AddItems();
                    break;
                case "r":
                case "remove":
                    RemoveItems();
                    break;
                case "q":
                    Console.WriteLine("You have chosen to quit!"); // go back to StockMenu() to quit program
                    break;
                default:
                    Console.WriteLine("Unvalid answer, try again by pressing the ENTER key!");
                    Console.ReadKey();
                    break;
            }
        }
        while (forward2 != "q");
    }

    // add items to stock, does not work with several items
    private void AddItems()
    {
        Console.Clear();

        string? inputItem = string.Empty;
        bool validItem = false;
        while (inputItem?.Length == 0 && !validItem)
        {
            Console.Write("Item: ");
            inputItem = Console.ReadLine()?.ToLower();
            if (!stockPrice.ContainsKey(inputItem) && inputItem?.Length != 0) // empty inputs shall not become an item, therefore second condition is added
            {
                InputPrice();
                validItem = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(inputItem + " already exists in range of products!\n Press the ENTER key to try again");
                Console.ReadKey();
            }

        }
        void InputPrice() // making sure price cannot be accessed if the inputItem is unvalid
        {
            bool validPrice = false;
            while (!validPrice)
            {
                Console.Clear();
                // admin setting a price for the corresponding item
                Console.Write("Set a price for " + inputItem + ": ");
                bool parsePrice = int.TryParse(Console.ReadLine(), out int successful); // parse to make sure the price contains just numbers

                if (parsePrice == true)
                {
                    stockPrice.Add(inputItem, successful);
                    validPrice = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input, try again by pressing the ENTER key");
                    Console.ReadKey();
                }
            }
        }
    }

    // remove items from stock
    private void RemoveItems()
    {
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
