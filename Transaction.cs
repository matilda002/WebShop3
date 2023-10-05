using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3
{
    public class Transaction
    {
        public readonly List<string> BoughtProducts;
        public readonly int AmountOfSpentMoney = 0;

        public readonly DateTime TimeOfPurchase;

        public Transaction(List<string> boughtProducts, int amountOfMoneySpent)
        {
            BoughtProducts = boughtProducts;
            AmountOfSpentMoney = amountOfMoneySpent;


            TimeOfPurchase = DateTime.Now;
        }

        public override string ToString()
        {
            string boughtProductformated = "Bought products: \n";
            foreach (string boughtProduct in BoughtProducts)
            {
                boughtProductformated += boughtProduct + "\n";
            }

            string transactionData = boughtProductformated +
                                                    "\n" +
                                                    "The total sum is: "+
                                                    AmountOfSpentMoney +
                                                    " kr." +
                                                    "\n\nTime of purchase: " +
                                                    TimeOfPurchase +
                                                    ".";
            return transactionData;
        }
    }
}
