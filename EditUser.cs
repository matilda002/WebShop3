﻿namespace WebShop3;


// To put in Admin() later
public class EditUser
{
    public string? username = string.Empty;
    public void EditUserMenu()
    {
        // Loops until there is a matching username
        bool valid = false;
        do
        {
            Console.Clear();
            Console.Write("Enter a username: ");
            username = Console.ReadLine();
            // program searching for a file with the same name
            switch (File.Exists($"../../../Users/{username}.txt"))
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
        // Loops until the new username includes 3 characters, and doesn't already exist in the Users folder
        string? _newUsername = string.Empty;
        bool validUsername = false;
        while (!validUsername)
        {
            // Printing out username + password 
            Console.Clear();
            string[] _userFile = File.ReadAllLines($"../../../Users/{username}.txt");
            foreach (string line in _userFile)
            {
                Console.WriteLine(line);
            }

            Console.Write("Enter a new username (minimum 3 characters): ");
            _newUsername = Console.ReadLine()?.ToLower();
            // Program checking that the new username doesn't already exist
            if (!File.Exists($"../../../Users/{_newUsername}.txt") && _newUsername?.Length > 3)
            {
                Console.WriteLine("Username successfully changed to " + _newUsername);
                validUsername = true;
            }
            else if (_newUsername?.Length < 3)
            {
                Console.WriteLine("The username need to include a minimum 3 characters!");
            }
            else 
            {
                Console.WriteLine("Username already exists!"); 
            }
            Console.WriteLine("\n\nPress ENTER to continue!");
            Console.ReadKey();
        }

        // Program checking that the new password is at least 8 characters long
        string? _newPassword = string.Empty;
        while (_newPassword?.Length <= 7) // 7 instead of 8 because index start at 0
        {
            Console.Clear();
            Console.Write("Enter the new password (minimum 8 characters): ");
            _newPassword = Console.ReadLine();
        }

        // Program checking if the repated password is the same as the new password 
        bool _validInput = false;
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
                    Console.Clear();
                    Console.WriteLine("Password changed!");
                    _validInput = true;
                    break;
            }
            Console.WriteLine("\n\nPress ENTER to continue!");
            Console.ReadKey();

        } while (!_validInput);

        // Making a list to add to the user.txt file later
        List<string> userUpdate = new List<string>()
        {
            _newUsername,
            _newPassword,
        };

        // Replacing the old file with the new one
        File.WriteAllLines($"../../../Users/{_newUsername}.txt", userUpdate);
        File.WriteAllLines($"../../../Users/{username}.txt", userUpdate);
        File.Replace($"../../../Users/{username}.txt", $"../../../Users/{_newUsername}.txt", null); 
    }
}