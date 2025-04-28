using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApp.aspClass;
namespace WebApp.Pages
{
    public class ListingsModel : BasePageModel
    {
        public bool loggedin = false;
        public List<House> availableHouses;

        

        public void OnGet()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
            }
            else { loggedin = false; }

            availableHouses = houseHandler.ReturnHouses();
        }

        public JsonResult OnGetHouseJsonResult()
        {
            var houses = houseHandler.ReturnHouses();
            return new JsonResult(houses);
        }
    }
}
