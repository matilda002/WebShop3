namespace WebShop3;

public interface ILoginSystem
{
    bool Login(string username, string password);
    void Logout();

    bool Register(string username, string password, UserRole role);
}
