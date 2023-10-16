﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public interface ILoginSystem
{
    bool Login(string userName, string passWord);
    void Logout();

    bool Register(string userName, string passWord);
}
