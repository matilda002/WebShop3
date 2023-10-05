using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public class User
{
    string email;
    string passWord;
    public User(string loginEmail, string loginPassWord)
    {
        email = loginEmail;
        passWord = loginPassWord;
    }
}

