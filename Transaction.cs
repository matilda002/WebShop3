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
    ///     This not a dictionary due to multiple 
    /// </param>
    public record Transaction(Dictionary<string, int> BoughtProducts, int AmountOfSpentMoney, DateTime TimeOfPurchase)
    {
        private string GetBoughtProductsFormated()
        {
            string boughtProductformated = "Bought products: \n";
            foreach (KeyValuePair boughtProduct in BoughtProducts)
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
                                                                   AmountOfSpentMoney +
                                                                   " kr." +
                                                                   "\n\nTime of purchase: " +
                                                                   TimeOfPurchase +
                                                                   ".";
            return transactionDataFormated;
        }
    }
}
