using ClassLib.Classes;
using ClassLib.Interfaces;
using WebApp.aspClass;

namespace WebApp.Pages
{
    public class ContactModel : BasePageModel
    {
        public bool loggedin = false;

        public void OnGet()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
            }
            else { loggedin = false; }
        }
    }
}
