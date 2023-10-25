using System.Security.Permissions;

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
    public record Transaction(string userName, List<Product> BoughtProducts)
    {
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

        public DateTime GetDateTime(string userName)
        {
            DateTime dateTime = DateTime.Now;

            string[] rawContentOfFile = File.ReadAllLines($"transaction_{userName}.txt");
            List<string> separaretedContentOfFile = new List<string>();
            foreach (string line in rawContentOfFile)
            {
                string separator = "purchase: ";
                if (line.Contains(separator))
                {
                    separaretedContentOfFile = line.Split(separator).ToList();
                }
            }
            dateTime = DateTime.Parse(separaretedContentOfFile[1]);
            return dateTime;
        }

        public override string ToString()
        {
            string transactionDataFormated = GetBoughtProductsFormated() +
                                                                   "\nThe total sum is: " +
                                                                   GetAmountOfMoneySpent() +
                                                                   " kr." +
                                                                   "\n\nTime of purchase: " +
                                                                   GetDateTime(userName) +
                                                                   ".";
            return transactionDataFormated;
        }
    }
}
