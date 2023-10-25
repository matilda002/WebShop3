namespace WebShop3
{
    public class Admin
    {
        public void ShowAllPurchases()
        {

        }

        public void CreateProduct()
        {
            Console.Clear();
            // Läser befintlig produktdata från filen "products.csv" och lagrar den i en array.
            string[] productFile = File.ReadAllLines("../../../products.csv");
            Console.WriteLine("Create new product");
            Console.WriteLine("Product name: ");
            string? name = Console.ReadLine();

            // Kontrollerar om det angivna produktnamnet redan finns i produktkatalogen.
            foreach (string product in productFile)
            {
                if (product.Contains(name))
                {
                    Console.WriteLine($"{name} already exists in product catalog");
                    return;
                }
            }

            // Ber användaren att ange priset på den nya produkten.
            Console.WriteLine("Product Price: ");
            string? price = Console.ReadLine();

            // Ser till att programmet inte återvänder för snabbt
            Console.WriteLine("Product is now created!\n\nPress 'ENTER' to return to 'Product Overview'");
            Console.ReadKey();

            // Lägger till den nya produkten (namn och pris) i filen "products.csv".
            File.AppendAllText("../../../products.csv", $"{name}, {price}" + Environment.NewLine);
        }
        public void ReadProduct()
        {
            Console.Clear();
            // Läser all produktdata från filen "products.csv" och lagrar den i en array.
            string[] products = File.ReadAllLines("../../../products.csv");

            // Visar listan över produkter i konsolen.
            Console.WriteLine("Product list: ");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }
            // Ser till att programmet inte återvänder för snabbt
            Console.WriteLine("\n\nPress 'ENTER' to return to 'Product Overview'");
            Console.ReadKey();

        }
        public void UpdateProduct()
        {
            Console.Clear();
            // Läser produktdata från filen "products.csv" och visar den tillsammans med ett index för varje produkt.
            string[] productFile = File.ReadAllLines("../../../products.csv");

            // Visar en lista över produkter med deras index i konsolen.
            for (int i = 0; i < productFile.Length; i++)
            {
                Console.WriteLine($"{i}. {productFile[i]}");
            }
            Console.WriteLine("Select index of product you wish to update");

            // Ber användaren att välja index för produkten de vill uppdatera.
            int.TryParse(Console.ReadLine(), out int index);

            Console.Clear();

            // Ber användaren att ange ett nytt namn och pris för den valda produkten.
            Console.WriteLine("Select new name for product");
            Console.WriteLine("Product name: ");
            string? name = Console.ReadLine();


            Console.WriteLine("Select new price for product: ");
            string? price = Console.ReadLine();
            Console.WriteLine("Product is now created");

            // Ser till att programmet inte återvänder för snabbt
            Console.WriteLine("\n\nPress 'ENTER' to return to 'Product Overview'");
            Console.ReadKey();

            // Uppdaterar den valda produkten med den nya informationen och sparar ändringarna i filen "products.csv".
            productFile[index] = $"{name}, {price}";
            File.WriteAllLines("../../../products.csv", productFile);
        }
        public void DeleteProduct()
        {
            Console.Clear();
            // Läser produktdata från filen "products.csv" och lagrar den i en lista.
            //string[] productFile = File.ReadAllLines("products.cvs");
            List<string> productFile = File.ReadAllLines("../../../products.csv").ToList();

            // Kontrollerar om det finns produkter i listan och informerar användaren om att det inte finns några produkter att ta bort om så är fallet.
            if (productFile.Count == 0)
            {
                Console.WriteLine("No products to delete.\n\nPress 'ENTER' to return to 'Product Overview'");
                Console.ReadKey();
                return;
            }

            // Visar en lista över produkter med deras index i konsolen.
            for (int i = 0; i < productFile.Count; i++)
            {
                Console.WriteLine($"{i}. {productFile[i]}");
            }

            Console.WriteLine("Select index of product you wish to delete: ");

            // Ber användaren att välja index för produkten de vill ta bort.
            if (int.TryParse(Console.ReadLine(), out int selectedIndex))
            {
                // Tar bort den valda produkten från listan och uppdaterar filen "products.csv".
                string deletedProduct = productFile[selectedIndex];


                productFile.RemoveAt(selectedIndex);

                //productFile = productFile.Where((line, index) => index != selectedIndex).ToArray();

                // Spara den uppdaterade listan till filen
                File.WriteAllLines("../../../products.csv", productFile);


                // Informerar användaren om att den valda produkten har tagits bort.
                Console.WriteLine($"Product '{deletedProduct}' has been deleted.");
            }
            else
            {
                // Hanterar fallet där användaren anger ogiltigt index.
                Console.WriteLine("Invalid index. Please select a valid index to delete a product.");
            }
            // Ser till att programmet inte återvänder för snabbt
            Console.WriteLine("\n\nPress 'ENTER' to continue!");
            Console.ReadKey();

        }
    }
}