using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace WebShop3;


// To put in Admin() later
public class NewProductMenu
{
    public string? name = string.Empty;
    public void EditUserMenu()
    {
        bool valid = false;
        do
        {
            Console.Clear();
            Console.Write("Enter a name: ");
            name = Console.ReadLine();
            switch(File.Exists($"../../../Users/{name}.txt"))
            {
                case (true):
                    OpenUser();
                    valid = true;
                    break;
            }
        } while (!valid);
    }
    private void OpenUser()
    {
        string[] _userFile = File.ReadAllLines($"../../../Users/{name}.txt");
        foreach (string line in _userFile)
        {
            Console.WriteLine(line);
        }

        Console.Write("Edit the username: ");
        string? _newUsername = Console.ReadLine();

        Console.Write("Enter the new password: ");
        string? _newPassword = Console.ReadLine();

        bool validInput = false;
        do
        {
            Console.Write("Repeat the new password: ");
            string? _pRepeat = Console.ReadLine();

            switch (_newPassword == _pRepeat)
            {
                case (false):
                    Console.WriteLine("The repeated password does not match!");
                    break;
                case (true):
                    validInput = true;
                    break;
            }
        } while (!validInput);

        Console.WriteLine("Password changed!");
    }
}
