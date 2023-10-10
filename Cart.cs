using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop3;

public class Cart : LogIn
{
    public List<string> CurrentCart = new List<string>();
}

public void AddToCart()
{
    Cart cart = new Cart();
}