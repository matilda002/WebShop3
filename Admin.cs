using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public class Admin : IAdmin
{
    public string UserName { get; set; }
    public string PassWord { get; set; }

    public Admin(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;
    }

    public bool Login(string userName, string passWord)
    {
        throw new NotImplementedException();
    }
}
