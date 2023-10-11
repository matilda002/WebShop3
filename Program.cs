using System.Diagnostics;
using WebShop3;

Admin test = new Admin();

test.StockMenu();

foreach (var line in test.stockPrice)
{
    Console.WriteLine(line);
}