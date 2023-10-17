using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            File.AppendAllText("products.csv", $"{name},{price}");
        }
        public void ReadProduct()
        {
            string name;
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

        }
    }
}
