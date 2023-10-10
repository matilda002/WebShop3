using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    public class Store
    {
        List<Product> _availableProducts = new List<Product>();
        List<Product> _boughtProducts = new List<Product>();

        public Store()
        {
            AddAvailableProducts();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private void AddAvailableProducts()
        {
            string[] availableProductsRepresentedByStrings = File.ReadAllLines("../../../Products.txt");

            foreach (string productRepresentedByString in availableProductsRepresentedByStrings)
            {
                string[] productFieldSeperated = productRepresentedByString.Split(", ");
                Product product = new Product(productFieldSeperated[0], int.Parse(productFieldSeperated[1]));
                _availableProducts.Add(product);
            }
        }
        private bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Show cart");
            Console.WriteLine("2) Display store");
            Console.WriteLine("3) Exit store");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowCart();
                    return true;
                case "2":
                    DisplayStore();
                    return true;
                default: 
                    return false;
            }
        }

        private void ShowCart()
        {
            foreach (var item in collection)
            {

            }
        }

        private void DisplayStore()
        {
            for (int index = 0; index < _availableProducts.Count; index++)
            {
                Product product = _availableProducts[index];
                Console.WriteLine((index) +
                                                " Name of product: " +
                                                product.Name +
                                                "\n  Price of product: " +
                                                product.Price);
            }
            int currentBoughtProductIndex = int.Parse(Console.ReadLine());
            _boughtProducts.Add(_availableProducts[currentBoughtProductIndex]);
        }
    }
}
