using ClassLib.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebApp.aspClass;

namespace WebApp.Pages
{
    public class EditListingModel : BasePageModel
    {
        public bool loggedin = false;
        public User loggedinUser;
        public House thisHouse;

        [BindProperty]
        public HouseModel HouseInfo { get; set; }

        public IActionResult OnGet()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
                int userId = (int)HttpContext.Session.GetInt32("userId");
                loggedinUser = userHandler.GetLoggedinUser(userId);


            }
            else
            {
                loggedin = false;
                Console.WriteLine("OnGet: user is not logged in");
            }

            if (Request.Query.TryGetValue("id", out var id))
            {
                int houseId;
                if (int.TryParse(id, out houseId))
                {   
                    InitializeHouseDetails(houseId);
                    
                }
                else
                {
                    return Redirect("/Error");
                }
            }
            else
            {
                return Redirect("/Error");
            }

            return Page();
        }

        private IActionResult InitializeHouseDetails(int houseId)
        {
            thisHouse = houseHandler.ReturnHouses().Find(house => house.GetHouseId() == houseId);

            if (thisHouse == null)
            {
                return Redirect("/Error");
            }

            if (thisHouse.GetOwnerId() != loggedinUser.GetId())
            {
                return Redirect("/Index");
            }

            return null;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int houseId = Convert.ToInt32(Request.Form["houseId"]);

                    int isSold = HouseInfo.IsSold ? 1 : 0;
                    object[] houseData = new object[]
                    {
                    houseId,
                    HouseInfo.Address,
                    HouseInfo.City,
                    HouseInfo.Price,
                    HouseInfo.SqmLiving,
                    HouseInfo.SqmProperty,
                    HouseInfo.Bathrooms,
                    HouseInfo.Bedrooms,
                    HouseInfo.Volume,
                    HouseInfo.Floors,
                    HouseInfo.EnergyLabel.ToString(),
                    HouseInfo.ConstructionYear,
                    isSold,
                    HouseInfo.Description
                    };

                    if (houseHandler.UpdateHouse(houseData))
                    {
                        TempData["message"] = "House successfully edited";
                        return RedirectToPage("/Account");
                    }
                    else
                    {
                        TempData["message"] = "Failed to update house data in database";
                        return RedirectToPage("/Account");
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = $"An error occurred: {ex.Message}";
                    return RedirectToPage("/Account");
                }
            }
            else
            {
                return RedirectToPage("/Account");
            }
        }
    }
}
