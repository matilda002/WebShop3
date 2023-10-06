using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    /// <summary>
    ///     A record type is used to indicate that this is primarily used to store data.  
    /// </summary>
    /// <param name="BoughtProducts">
    ///     This is not represented by a dictionary in order to minimize boiler plate code.
    /// </param>
    public record Transaction(List<Product> BoughtProducts, DateTime TimeOfPurchase)
    {
        public int GetAmountOfMoneySpent()
        {
            int amountOfMoneySpent = 0;
            foreach (Product boughtProduct in BoughtProducts)
            {
                amountOfMoneySpent += boughtProduct.Price;
            }
            return amountOfMoneySpent;
         }

        private string GetBoughtProductsFormated()
        {
            string boughtProductformated = "Bought products: \n";
            foreach (Product boughtProduct in BoughtProducts)
            {
                boughtProductformated += boughtProduct.Name +
                                                             ", " +
                                                             boughtProduct.Price +
                                                             " kr" +
                                                             "\n";
            }
            return boughtProductformated;
        }

        public override string ToString()
        {
            string transactionDataFormated = GetBoughtProductsFormated() +
                                                                   "\nThe total sum is: "+
                                                                   GetAmountOfMoneySpent() +
                                                                   " kr." +
                                                                   "\n\nTime of purchase: " +
                                                                   TimeOfPurchase +
                                                                   ".";
            return transactionDataFormated;
        }
    }
}
