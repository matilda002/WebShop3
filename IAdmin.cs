using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

internal interface IAdmin
{
    bool Login(string userName, string passWord);
    
}
