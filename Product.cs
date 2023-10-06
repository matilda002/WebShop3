using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop3
{    
    /// <summary>
     ///     A record type is used to indicate that this is used to store data, primarily.  
     /// </summary>
    public record Product (string Name, int Price)
    {

    }
}
