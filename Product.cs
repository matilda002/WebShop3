using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop3
{
    /// <summary>
    ///     A record type is used to indicate that this is primarily used to store data.  
    ///     The data is not represented by a dictionary due to user might buy
    ///     multiple articles of the same type, which a dictionary cannot handle.
    /// </summary>
    public record Product(string Name, int Price)
    {

    }
}