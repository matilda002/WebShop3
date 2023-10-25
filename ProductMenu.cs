namespace WebShop3;

public class ProductMenu : Admin
{
    public void StockMenu()
    {
        bool forward = false;
        do
        {
            Console.Clear();
            Console.WriteLine("--------- Product Overview ---------\n" +
                              "1. Create a new product\n" +
                              "2. Print out list of products\n" +
                              "3. Update a product\n" +
                              "4. Delete a product\n\n" +
                              "5. Quit");
            Console.Write("\nWrite your menuchoice:  ");
            int.TryParse(Console.ReadLine(), out int successful);

            switch (successful)
            {
                case 1:
                    CreateProduct();
                    break;
                case 2:
                    ReadProduct();
                    break;
                case 3:
                    UpdateProduct();
                    break;
                case 4:
                    DeleteProduct();
                    break;
                case 5:
                    Console.WriteLine("You have chosen to quit!\n\nPress 'ENTER' to continue!"); // quit program
                    Console.ReadKey();
                    forward = true;  break;
                default:
                    Console.WriteLine("Not a valid menuchoice!\n\nPress 'ENTER' to continue!");
                    Console.ReadKey();
                    break;
            }
        }
        while (!forward);
    }
}