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
    public record Transaction(List<Product> BoughtProducts, int AmountOfSpentMoney, DateTime TimeOfPurchase)
    {
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
                                                                   AmountOfSpentMoney +
                                                                   " kr." +
                                                                   "\n\nTime of purchase: " +
                                                                   TimeOfPurchase +
                                                                   ".";
            return transactionDataFormated;
        }
    }
}
