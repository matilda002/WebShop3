using System.Diagnostics;
using WebShop3;


ProductMenu test = new ProductMenu();

test.StockMenu();

Console.Clear();

string[] p = File.ReadAllLines("../../../products.csv");

foreach (var item in p)
{
    Console.WriteLine(item);
}

