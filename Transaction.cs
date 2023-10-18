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
    ///     A record type is used to indicate that this is primarily used to store data.  
    ///     The data is not represented by a dictionary due to user might buy
    ///     multiple articles of the same type, which a dictionary cannot handle.
    /// </param>
    public record Transaction(List<Product> BoughtProducts)
    {
        DateTime TimeOfPurchase = DateTime.Now;
        private int GetAmountOfMoneySpent()
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
            string boughtProductformated = "\nBought products: \n";
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
                                                                   "\nThe total sum is: " +
                                                                   GetAmountOfMoneySpent() +
                                                                   " kr." +
                                                                   "\n\nTime of purchase: " +
                                                                   TimeOfPurchase +
                                                                   ".";
            return transactionDataFormated;
        }
    }
}