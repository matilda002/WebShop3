namespace WebShop3;

public class EditProduct
{
    // List for items in stock with their price;
    public List<string> stockList = new List<string>();


    // add items to stock, does not work with several items
    public void AddItems()
    {
        stockList = File.ReadAllLines("../../../products.csv").ToList();
        Console.Clear();

        string? inputItem = string.Empty;
        bool validItem = false;
        while (inputItem?.Length == 0 && !validItem) // checking if the input equals to 0
        {
            Console.Clear();
            Console.WriteLine("--------- Add Product ---------");
            Console.Write("Product name: ");
            inputItem = Console.ReadLine()?.ToLower();;
            if (!stockList.Contains(inputItem) && inputItem?.Length != 0) // empty inputs shall not become an item, therefore second condition is added
            {
                InputPrice();
                validItem = true;
            }
            else
            {
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
                Console.WriteLine("--------- Add Product ---------");
                // admin setting a price for the corresponding item
                Console.Write("Set a price for " + inputItem + ": ");
                bool parsePrice = int.TryParse(Console.ReadLine(), out int successful); // parse to make sure the price contains just numbers

                if (parsePrice == true)
                {
                    File.AppendAllText("../../../products.csv", $"{inputItem}, {successful}\n"); // writing new line in a csv for each product
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
    public void RemoveItems()
    {
        // delete items from dictonary, admin need to type in the specific item
        bool validInput = false;
        while (!validInput)
        {
            stockList = File.ReadAllLines("../../../products.csv").ToList(); // calling product list 

            Console.Clear();
            Console.WriteLine("--------- Remove Product ---------");
            foreach (var line in stockList) // print out list
            {
                Console.WriteLine(line);
            }

            string? deleteStock = string.Empty;
            while (deleteStock?.Length == 0) // makes sure user cannot remove item from stock if answer is zero characters
            {
                Console.Write("Write the name of the product you'd like to remove:  ");
                deleteStock = Console.ReadLine()?.ToLower();
            }


            // program looks in the dictonary to search for a matching name, deletes if true
            if (stockList.Contains(deleteStock))
            {
                stockList.Remove(deleteStock);
                File.WriteAllLines("../../../products.csv", stockList); // updating list, writing over the existing file
                Console.WriteLine(deleteStock + " was removed!");
                validInput = true;
            }
            else
            {
                Console.WriteLine("\n" + deleteStock + " does not exist in the range of products!\nMake sure the spelling is correct and try again");
            }
            

            Console.WriteLine("\nPress the ENTER key to return to menu!"); // holding program so the user can see the result before clearing screen
            Console.ReadKey();
        }
    }
}