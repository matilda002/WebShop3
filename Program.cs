using WebShop3;

// creates the file for products
if (!File.Exists("../../../products.csv")) // ändra till "../../../products.csv"
{
    File.Create("../../../products.csv").Close();
}

ILoginSystem loginSystem = new LogIn();

string? username = string.Empty;
while (username?.Length == 0) // making sure input isn't empty
{
    Console.Clear();
    Console.WriteLine("Enter username: ");
    username = Console.ReadLine()?.ToLower();
}

string? password = string.Empty;
while (password?.Length == 0) // making sure input isn't empty
{
    Console.Clear();
    Console.WriteLine("Enter password: ");
    password = Console.ReadLine();
}


if (loginSystem.Login(username, password))
{
    UserRole userRole = GetRole(username); // reads the role from the method

    if (userRole == UserRole.Admin)
    {
        AdminMenu();
    }
    else
    {
        UserMenu();
    }
}

static UserRole GetRole(string username)
{
    string userFilePath = $"../../../Users/{username}.txt"; // finds directory of user files

    if (File.Exists(userFilePath))
    {
        string[] lines = File.ReadAllLines(userFilePath); // reads all lines in the user .txt file
        if (lines.Length >= 3)
        {
            string roleString = lines[2]; // saves the third row, as that's where the role is saved in the .txt file
            if (Enum.TryParse(roleString, out UserRole role)) // parse string into the corresponding enum value
            {
                return role;
            }
        }
    }
    return UserRole.User; // default to the user file if it doesn't exist or is incorrect
}

void AdminMenu()
{
    bool validChoice = false;
    do
    {
        Console.Clear();
        Console.WriteLine("------- Admin Menu -------\n"+
                          "1. Transaction overview\n" +
                          "2. Product overview\n"+
                          "3. Edit user\n" +
                          "\n4. Quit");
        Console.Write("\nWrite your menuchoice:  ");
        int.TryParse(Console.ReadLine(), out int successful); // make sure the input is a number and included in the list

        switch (successful) // transfered to 
        {
            case 1:
                TransactionOverview transaction = new TransactionOverview();
                transaction.UserTransaction();
                validChoice = true; break;
            case 2:
                ProductMenu product = new ProductMenu();
                product.StockMenu();
                validChoice = true; break;
            case 3:
                EditUser user = new EditUser();
                user.EditUserMenu();
                validChoice = true; break;
            case 4:
                Console.WriteLine("You have chosen to quit!\n\nPress 'ENTER' to continue!"); // quit program
                Console.ReadKey();
                return;
            default:
                Console.WriteLine("Not a valid menuchoice!\n\nPress 'ENTER' to continue!");
                Console.ReadKey();
                break;
        }
    } while (!validChoice);
}

void UserMenu()
{
    bool validChoice = false;
    do
    {
        Console.Clear();
        Console.WriteLine("------- Costumer Menu -------\n" +
                          "1. Store\n" +
                          "2. See your orderhistory" +
                          "\n3. Quit");
        Console.Write("\nWrite your menuchoice:  ");
        int.TryParse(Console.ReadLine(), out int successful); // make sure the input is a number and included in the list

        switch (successful)
        {
            case 1:
                Store store = new Store();
                validChoice = true; break;
            case 2:
                // User.DisplayTransaction
                validChoice = true; break;
            case 3:
                Console.WriteLine("You have chosen to quit!\n\nPress 'ENTER' to continue!"); // quit program
                Console.ReadKey();
                return;
            default:
                Console.WriteLine("Not a valid menuchoice!\n\nPress 'ENTER' to continue!");
                Console.ReadKey();
                break;
        }
    } while (!validChoice);
}