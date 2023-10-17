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
                DisplayStoreMenu();
                isMenuRunning = StoreMenuInput();
            }
        }

        private void AddAvailableProducts()
        {
            string[] availableProductsRepresentedByStrings = File.ReadAllLines("../../../Products.txt");

            foreach (string productRepresentedByString in availableProductsRepresentedByStrings)
            {
                string separator = ", ";
                string[] separatedProductFields = productRepresentedByString.Split(separator);

                int firstFieldIndex = 0;
                int secondFieldIndex = 1;
                Product product = new Product(separatedProductFields[firstFieldIndex], int.Parse(separatedProductFields[secondFieldIndex]));
                _availableProducts.Add(product);
            }
        }

        private void DisplayStoreMenu()
        {
            Console.WriteLine("\nChoose an option:\n" +
                                            NumericalDialogueAnswer.Zero +
                                            ") Display cart\n" +
                                            NumericalDialogueAnswer.One +
                                            ") Display store\n" +
                                            NumericalDialogueAnswer.Two +
                                            ") Exit\n");
            Console.Write("\r\nSelect an option: ");
        }

        private BinaryDialogueChoice GetBinaryDialogueAnswer()
        {
            BinaryDialogueChoice dialogueAnswer;

            int index = 0;
            DisplayHelpText();
            do
            {
                if (Console.ReadKey(false).Key == ConsoleKey.UpArrow &&
                     index < (int)BinaryDialogueChoice.No)
                {
                    index++;
                }
                else if (Console.ReadKey(false).Key == ConsoleKey.DownArrow &&
                            index > 0)
                {
                    index--;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();

                dialogueAnswer = (BinaryDialogueChoice)Enum.GetValues(typeof(BinaryDialogueChoice)).GetValue(index);
                Console.WriteLine(dialogueAnswer);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            return dialogueAnswer;
        }

        private NumericalDialogueAnswer GetNumericalDialogueAnswer()
        {
            NumericalDialogueAnswer dialogueAnswer;

            int index = 0;
            DisplayHelpText();
            do
            {
                if (Console.ReadKey(false).Key == ConsoleKey.UpArrow &&
                     index < _availableProducts.Count - 1)
                {
                    index++;
                }
                else if (Console.ReadKey(false).Key == ConsoleKey.DownArrow &&
                            index > 0)
                {
                    index--;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();

                dialogueAnswer = (NumericalDialogueAnswer)Enum.GetValues(typeof(NumericalDialogueAnswer)).GetValue(index);
                Console.WriteLine(dialogueAnswer);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            return dialogueAnswer;
        }
        private bool StoreMenuInput()
        {
            switch (GetNumericalDialogueAnswer())
            {
                case NumericalDialogueAnswer.Zero:
                    DisplayCart();
                    return true;
                case NumericalDialogueAnswer.One:
                    DisplayStore();
                    return true;
                case NumericalDialogueAnswer.Two:
                    return false;
                default:
                    return true;
            }
        }

        private void DisplayProductData(List<Product> productsToShow)
        {
            for (int index = 0; index < productsToShow.Count; index++)
            {
                Product product = productsToShow[index];
                Console.WriteLine($"{index} Name: {product.Name}\n  Price: {product.Price}");
            }
        }

        private void DisplayHelpText()
        {
            Console.WriteLine("Press arrow keys to change index. Press Esc to stop.");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        // This uses integers and arrow keys to select index
        private int ParseIndexInput()
        {
            int index = 1;
            DisplayHelpText();
            do
            {
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.UpArrow when index < _availableProducts.Count:
                        index++;
                        break;
                    case ConsoleKey.DownArrow when index > 0:
                        index--;
                        break;
                }

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.WriteLine(index);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            return index;
        }

        private void RemoveProductInCart()
        {
            string removeDialogue = "Do you want to remove a product from the cart? [" +
                                                     BinaryDialogueChoice.Yes +
                                                     "/" +
                                                     BinaryDialogueChoice.No +
                                                     "]";
            Console.WriteLine(removeDialogue);

            if (GetBinaryDialogueAnswer() == BinaryDialogueChoice.Yes)
            {
                _productsInCart.RemoveAt(ParseIndexInput());
            }
        }

        private void DisplayCart()
        {
            int minimalCartSize = 0;
            if (_productsInCart.Count > minimalCartSize)
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
            string addDialogue = "Do you want to add a product to the cart? [" +
                                                 BinaryDialogueChoice.Yes +
                                                 "/" +
                                                 BinaryDialogueChoice.No +
                                                 "]";
            Console.WriteLine(addDialogue);
            if (GetBinaryDialogueAnswer() == BinaryDialogueChoice.Yes)
            {
                _productsInCart.Add(_availableProducts[ParseIndexInput()]);
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
