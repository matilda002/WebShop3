namespace WebShop3;


public class EditUser
{
    private string? _username = string.Empty;
    public void EditUserMenu()
    {
        // Loops until there is a matching username
        bool valid = false;
        do
        {
            Console.Clear();
            Console.WriteLine("----- Edit User -----\n");
            Console.Write("Enter a username: ");
            _username = Console.ReadLine();
            // program searching for a file with the same name
            switch (File.Exists($"../../../Users/{_username}.txt"))
            {
                case (true):
                    OpenUser();
                    valid = true; break;
            }
        } while (!valid);
    }
    private void OpenUser()
    {        
        // Loops until the new username includes 3 characters, and doesn't already exist in the Users folder
        string? _newUsername = string.Empty;
        bool _validUsername = false;
        while (!_validUsername)
        {
            // Printing out username + password + role 
            Console.Clear();
            Console.WriteLine("----- Edit User -----");
            string[] _userFile = File.ReadAllLines($"../../../Users/{_username}.txt");
            foreach (string line in _userFile)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            // User insert a new password
            Console.Write("Enter a new username (min. 3 characters): ");
            _newUsername = Console.ReadLine()?.ToLower();
            // Program checking that the new username doesn't already exist
            switch (File.Exists($"../../../Users/{_newUsername}.txt") && _newUsername?.Length > 2)
            {
                case true:
                    Console.WriteLine("Username successfully changed to " + _newUsername);
                    _validUsername = true; break;
                case false:
                    switch (_newUsername?.Length < 3)
                    {
                        case false:
                            Console.WriteLine("Username already exists!");
                            break;
                        case true:
                            Console.WriteLine("The username must include a min. 3 characters!");
                            break;
                    }
                    Console.ReadKey();
                    break;   
            }
        }

        // Program checking that the new password is at least 5 characters long
        string? _newPassword = string.Empty;
        while (_newPassword?.Length <= 4) // 4 instead of 5 because index start at 0
        {
            Console.Clear();
            Console.WriteLine("----- Edit User -----\n");
            Console.Write("Enter the new password (min. 5 characters): ");
            _newPassword = Console.ReadLine();
        }

        // Program checking if the repated password is the same as the new password 
        bool _validInput = false;
        do
        {
            // Input for repeated password
            Console.Write("Repeat the new password: ");
            string? _pRepeat = Console.ReadLine();

            // When the repeated password match, they come back to menu
            switch (_newPassword == _pRepeat)
            {
                case (false):
                    Console.WriteLine("The repeated password does not match!");
                    break;
                case (true):
                    Console.Clear();
                    Console.WriteLine("----- Edit User -----\n");
                    Console.WriteLine("Password changed!");
                    _validInput = true;
                    break;
            }
            Console.WriteLine("\n\nPress ENTER to continue!");
            Console.ReadKey();

        } while (!_validInput);

        // Variables to the userfiles for easier identefing string of code
        string _newUserFilepath = $"../../../Users/{_newUsername}.txt";
        string _oldUserFilepath = $"../../../Users/{_username}.txt"; // original file
        // Writing over the old login information with the new
        File.WriteAllText(_newUserFilepath, $"{ _newUsername}\n{ _newPassword}\n{UserRole.User}");
        File.WriteAllText(_oldUserFilepath, $"{_newUsername}\n{_newPassword}\n{UserRole.User}");
        // Replacing the old file with the new one
        File.Replace(_oldUserFilepath, _newUserFilepath, null); 
    }
}