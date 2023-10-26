using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    public class Store
    {
        private List<Product> _availableProducts;
        private List<Product> _productsInCart;

        public Store()
        {
            Initialize();
        }

        private void Initialize()
        {
            _availableProducts = new List<Product>();
            _productsInCart = new List<Product>();

            AddAvailableProducts();

            bool isMenuRunning = true;
            while (isMenuRunning)
            {
                DisplayStoreMenu();
                isMenuRunning = StoreMenuInput();
            }
        }

        private int GetIndex(int index, int maxIndex)
        {
            int lowestIndex = 0;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow when index < maxIndex:
                    index++;
                    break;
                case ConsoleKey.DownArrow when index > lowestIndex:
                    index--;
                    break;
            }
            return index;
        }

        private void UpdateIndexUserInterface()
        {
            int lowestPosition = 0;
            int highestPositionOffset = 1;
            Console.SetCursorPosition(lowestPosition, Console.CursorTop - highestPositionOffset);
            ClearCurrentConsoleLine();
        }

        private BinaryDialogueChoice GetBinaryDialogueAnswer()
        {
            BinaryDialogueChoice dialogueAnswer;

            int index = 0;
            Console.WriteLine(GetHelpText());
            do
            {
                // BinaryDialogueChoice.No is the highest value.
                index = GetIndex(index, (int)BinaryDialogueChoice.No);
                
                UpdateIndexUserInterface();

                dialogueAnswer = (BinaryDialogueChoice)Enum.GetValues(typeof(BinaryDialogueChoice)).GetValue(index);
                Console.WriteLine(dialogueAnswer);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            return dialogueAnswer;
        }

        // Arrow keys are used as a mean of selection instead of Console.ReadLine()
        // to avoid needing to parse strings to enums.
        private NumericalDialogueAnswer GetNumericalDialogueAnswer()
        {
            NumericalDialogueAnswer dialogueAnswer;

            int index = 0;
            do
            {
                int indexOffset = 1;
                index = GetIndex(index, _availableProducts.Count - indexOffset);

                UpdateIndexUserInterface();

                dialogueAnswer = (NumericalDialogueAnswer)Enum.GetValues(typeof(NumericalDialogueAnswer)).GetValue(index);
                Console.WriteLine(dialogueAnswer);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            return dialogueAnswer;
        }

        // This uses integers and arrow keys to select index
        private int GetListIndex()
        {
            int index = 1;
            Console.WriteLine(GetHelpText());
            do
            {
                index = GetIndex(index, _availableProducts.Count - 1);

                UpdateIndexUserInterface();
                Console.WriteLine(index);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            return index;
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

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void AddAvailableProducts()
        {
            string productFilePath = "../../../products.csv";
            string[] availableProductsRepresentedByStrings = File.ReadAllLines(productFilePath);

            foreach (string productRepresentedByString in availableProductsRepresentedByStrings)
            {
                string separator = ", ";
                string[] products = productRepresentedByString.Split(separator);
                
                int firstProductIndex = 0;
                int secondProductIndex = 1;
                Product product = new Product(products[firstProductIndex], int.Parse(products[secondProductIndex]));
                
                _availableProducts.Add(product);
            }
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
                _productsInCart.RemoveAt(GetListIndex());
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
                _productsInCart.Add(_availableProducts[GetListIndex()]);
                return false;
            }
            return true;
        }

        private void DisplayCart()
        {
            int minimalCartSize = 0;
            if (_productsInCart.Count > minimalCartSize)
            {
                string itemsInCartMessage = "----------------------\nItems in cart: \n----------------------";
                Console.WriteLine(itemsInCartMessage);
                DisplayProductData(_productsInCart);
                RemoveProductInCart();
            }
            else
            {
                string cartIsEmptyMessage = "----------------------\nThe cart is empty\n----------------------";
                Console.WriteLine(cartIsEmptyMessage);
            }
        }

        private void DisplayProductData(List<Product> productsToShow)
        {
            Console.Clear();
            for (int index = 0; index < productsToShow.Count; index++)
            {
                Product product = productsToShow[index];
                string productInformation = $"{index} : {product.Name}, {product.Price}kr";
                Console.WriteLine(productInformation);
            }
        }

        private void DisplayStoreMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Store -----");
            string storeMenuText = "\nChoose an option:\n" +
                                                   NumericalDialogueAnswer.Zero +
                                                   ") Display cart\n" +
                                                   NumericalDialogueAnswer.One +
                                                   ") Display store\n" +
                                                   NumericalDialogueAnswer.Two +
                                                   ") Exit\n" +
                                                   $"\r\n {GetHelpText()}";
            Console.Write(storeMenuText);
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

        private string GetHelpText()
        {
            string helpText = "Press arrow keys to change index. Press Esc to stop.";
            return helpText;
        }
    }
}
