using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    public class Store
    {
        List<Product> _availableProducts = new List<Product>();
        List<Product> _productsInCart = new List<Product>();

        public Store()
        {
            AddAvailableProducts();
            bool isMenuRunning = true;
            while (isMenuRunning)
            {
                isMenuRunning = DisplayStoreMenu();
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

        private bool DisplayStoreMenu()
        {
            Console.WriteLine("----------------------" +
                                            "Choose an option:" +
                                            "1) Show cart" +
                                            "2) Display store" +
                                            "3) Exit store" + 
                                            "----------------------");
            switch (Console.Read())
            {
                case '1':
                    DisplayCart();
                    return true;
                case '2':
                    DisplayStore();
                    return true;
                default: 
                    return false;
            }
        }

        private void DisplayProductData(List<Product> productsToShow)
        {
            for (int index = 0; index < productsToShow.Count; index++)
            {
                Product product = productsToShow[index];
                Console.WriteLine(index +
                                                " Name: " +
                                                product.Name +
                                                "\n  Price: " +
                                                product.Price);
            }
        }

        private void RemoveProductInCart()
        {
            Console.WriteLine("Do you want to remove a product from the cart? [y/n]");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Specify the index.");
                int indexOfProductToRemoveFromCart = int.Parse(Console.ReadLine());
                _productsInCart.RemoveAt(indexOfProductToRemoveFromCart);
            }
        }

        private void DisplayCart()
        {
            if (_productsInCart.Count > 0)
            {
                Console.WriteLine("----------------------\nItems in cart: \n----------------------");
                DisplayProductData(_productsInCart);
                RemoveProductInCart();
            }
            else
            {
                Console.WriteLine("----------------------\nThe cart is empty\n----------------------");
            }
        }

        private bool AddProductToCart()
        {
            Console.WriteLine("\n\n\nDo you want to add a product to the cart? [y/n]");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Specify the index.");
                int indexOfProductToAddToCart = int.Parse(Console.ReadLine());
                _productsInCart.Add(_availableProducts[indexOfProductToAddToCart]);
                return false;
            }
            return true;
        }

        private void DisplayStore()
        {
            bool isMenuRunning = true;
            while (isMenuRunning)
            {
                DisplayProductData(_availableProducts);
                isMenuRunning = AddProductToCart();
            }
        }
    }
}
