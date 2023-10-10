using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public User(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;
    }
    
}

