using ClassLib.Classes;
using ClassLib.Interfaces;
using WebApp.aspClass;

namespace WebApp.Pages
{
    public class IndexModel : BasePageModel
    {
        public bool loggedin = false;
        public List<House> popularHouses;
        public void OnGet()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
            }
            else { loggedin = false; }

            popularHouses = houseHandler.ReturnPopularHouses();
        }
    }
}
