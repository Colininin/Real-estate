using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;
using Humanizer;
using Handlers.Classes;

namespace WebApp.aspClass
{
    public class BasePageModel : PageModel
    {
        public readonly HouseManager houseHandler;
        public readonly UserManager userHandler;


        public BasePageModel()
        {
            this.userHandler = new UserManager();
            this.houseHandler = new HouseManager();

        }

        public bool IsLoggedIn()
        {
            var email = HttpContext.Session.GetString("email");
            Console.WriteLine("Checking Session: Email = " + email);
            return !string.IsNullOrEmpty(email);
        }
    }
}
