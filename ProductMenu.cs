namespace WebShop3;

public class ProductMenu : EditProduct
{
    public void StockMenu()
    {
        string? forward = string.Empty;
        do // doing a loop since I don't want to return to the main menu until there's a valid answer
        {
            Console.Clear();
            Console.WriteLine("--------- Edit Products ---------");
            // asking if the user wants to go foward and change any products
            Console.Write("Do you want to change the range of products? [y/n]:  ");
            forward = Console.ReadLine()?.ToLower();

            switch (forward)
            {
                case "y":
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
            Console.WriteLine("--------- Edit Products ---------");
            // asking if the user wants to add or remove items
            Console.Write("Do you want to add or remove product? [a/r]\nTo quit answer 'q':  ");
            forward2 = Console.ReadLine()?.ToLower();

            switch (forward2)
            {
                case "a":
                    AddItems();
                    break;
                case "r":
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
}