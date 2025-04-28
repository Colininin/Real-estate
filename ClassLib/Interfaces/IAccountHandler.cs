using ClassLib.Classes;

namespace ClassLib.Interfaces
{
    public interface IAccountHandler
    {
        bool PublicRegister(object[] registerData);
        User PublicLogin(string email, string password);
        List<User> GetUsers();

        User GetLoggedinUserr(int id);
    }
}
