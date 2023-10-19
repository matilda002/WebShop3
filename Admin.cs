namespace WebShop3
{
    public class Admin
    {
        //Skapa CRUD för admin
        //Kunna se vilka köp görs
        //custommer history

        //Skapa ny produkt med namn och pris


        
        public void CreateProduct()
        { 
            string[] productFile = File.ReadAllLines("products.csv");
            Console.WriteLine("Create new product");
            Console.WriteLine("Product name: ");
            string name = Console.ReadLine();

            foreach (string product in productFile)
            {
                if (product.Contains(name))
                {
                    Console.WriteLine($"{name} already exists in product catalog");
                    return;
                }
            }


            Console.WriteLine("Product Price: ");
            Console.WriteLine("Product is now created");
            
            string price = Console.ReadLine();
            File.AppendAllText("products.csv", $"{name},{price}" + Environment.NewLine);
        }
        public void ReadProduct()
        {
            string[] products = File.ReadAllLines("products.csv");

            Console.WriteLine("Product list: ");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }
            
        }
        public void UpdateProduct()
        {
            string[] productFile = File.ReadAllLines("products.csv");
           
            for (int i = 0; i < productFile.Length; i++)
            {
                Console.WriteLine($"{i}. {productFile[i]}");
            }
            Console.WriteLine("Select index of product you wish to update");

            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Select new name for product");
            Console.WriteLine("Product name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Select new price for product: ");
            Console.WriteLine("Product is now created");
            string price = Console.ReadLine();
            productFile[index] = $"{name},{price}";
            File.WriteAllLines("products.csv", productFile);
        }
        public void DeleteProduct()
        {
            //string[] productFile = File.ReadAllLines("products.cvs");
            List<string> productFile = File.ReadAllLines("products.csv").ToList();
            
            if (productFile.Count == 0)
            {
                Console.WriteLine("No products to delete.");
                return;
            }

            for (int i = 0; i < productFile.Count; i++)
            {
                Console.WriteLine($"{i}. {productFile[i]}");
            }

            Console.WriteLine("Select index of product you wish to delete: ");

            if (int.TryParse(Console.ReadLine(), out int selectedIndex))
            {
                string deletedProduct = productFile[selectedIndex];


                productFile.RemoveAt(selectedIndex);

                //productFile = productFile.Where((line, index) => index != selectedIndex).ToArray();

                // Spara den uppdaterade listan till filen
                File.WriteAllLines("products.csv", productFile);

                Console.WriteLine($"Product '{deletedProduct}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please select a valid index to delete a product.");
            }
            
        }
    }
}
