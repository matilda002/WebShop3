using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public class User
{
    public string Email;
    public string PassWord;
    public string Name;

    public User()
    {

    }

    public User(string name, string loginEmail, string loginPassWord)
    {
        Email = loginEmail;
        PassWord = loginPassWord;
        name = Name;

        
    }
}

