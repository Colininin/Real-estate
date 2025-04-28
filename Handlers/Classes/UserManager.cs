using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ClassLib.Classes;
using DAL.Classes;

namespace Handlers.Classes
{
    public class UserManager
    {
        private readonly IAccountHandler accHandler;
        private List<User> users;
        public UserManager()
        {
            accHandler = new AccountDB();
        }

        public UserManager(IAccountHandler accountHandler)
        {
            accHandler = accountHandler ?? throw new ArgumentNullException(nameof(accountHandler));
            users = new List<User>();
        }

        public bool RegisterAccount(object[] registerData)
        {
            return accHandler.PublicRegister(registerData);
        }

        public User TryLogin(string email, string password)
        {
            return accHandler.PublicLogin(email, password);
        }

        public List<User> ReturnUsers()
        {
            return GetUsers();
        }

        private List<User> GetUsers()
        {
            users = accHandler.GetUsers();
            return users;
        }

        public User GetLoggedinUser(int id)
        {
            return accHandler.GetLoggedinUserr(id);
        }
    }
}
