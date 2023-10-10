using WebShop3;
// file added to not mess upp anything in program.cs when merging


Admin test = new Admin();

test.StockMenu();

foreach (var line in test.stockPrice)
{
    Console.WriteLine(line);
}