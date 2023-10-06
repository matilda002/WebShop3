using System.Threading.Channels;

namespace WebShop3;

public class Admin : TempoaryUser, IStockList
{

    public Admin (string username, string email) : base(username, email)
    {

    }

}