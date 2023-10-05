using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    public record Transaction(List<string> boughtProducts, int amountOfSpentMoney, DateTime timeOfPurchase)
    {

        public List<string> BoughtProducts
        {
            get
            {
                return boughtProducts;
            }
        }

        public int AmountOfSpentMoney
        {
            get
            {
                return amountOfSpentMoney;
            }
        }

        public DateTime TimeOfPurchase
        {
            get
            {
                return timeOfPurchase;
            }
        }

        public override string ToString()
        {
            string boughtProductformated = "Bought products: \n";
            foreach (string boughtProduct in BoughtProducts)
            {
                boughtProductformated += boughtProduct + "\n";
            }

            string transactionDataFormated = boughtProductformated +
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
