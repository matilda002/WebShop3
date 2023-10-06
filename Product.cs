using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop3
{
    /// <summary>
    ///     A record type is used to indicate that this is primarily used to store data.  
    ///     The data is not represented by a dictionary in order to minimize boiler plate code.
    /// </summary>
    public record Product (string Name, int Price)
    {

    }
}
