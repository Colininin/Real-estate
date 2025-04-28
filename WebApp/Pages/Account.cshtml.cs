using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLib.Classes;
using WebApp.aspClass;
using ClassLib.Interfaces;
using DAL.Classes;
namespace WebApp.Pages
{
    public class AccountModel : BasePageModel
    {
        public bool loggedin = false; 
        public User loggedinUser;
        public List<House> userFavs;
        public House myHouse;
        public List<House> myHouses;

        public IActionResult OnGet()
        {
            if(IsLoggedIn())
            {
                loggedin = true;
                int userId = (int)HttpContext.Session.GetInt32("userId");
                loggedinUser = userHandler.GetLoggedinUser(userId);

                GetFavoritesAndHouses(userId);
            }
            else
            {
                return Redirect("Login");
            }

            return Page();

        }

        private void GetFavoritesAndHouses(int userId)
        {
            userFavs = new List<House>(GetFavorites(userId));
            if (loggedinUser is PrivateSeller)
            {
                myHouse = houseHandler.GetOwnerHouse(userId);
            }
            else
            {
                myHouses = new List<House>(houseHandler.GetOwnerHouses(userId));
            }
        }

        private List<House> GetFavorites(int id)
        {
            return houseHandler.GetFavs(id);
        }

        public IActionResult OnPostDeleteFav()
        {
            int houseId = Convert.ToInt32(Request.Form["houseId"]);
            int ownerId = Convert.ToInt32(Request.Form["ownerId"]);

            int userId = (int)HttpContext.Session.GetInt32("userId");
            loggedinUser = userHandler.GetLoggedinUser(userId);

            if (houseHandler.DeleteFav(houseId, ownerId))
            {
                GetFavoritesAndHouses(userId);
                return RedirectToPage();
            }

            return Page();
        }

        public IActionResult OnPostDeleteHouse()
        {
            int houseId = Convert.ToInt32(Request.Form["houseId"]);
            int ownerId = Convert.ToInt32(Request.Form["ownerId"]);

            int userId = (int)HttpContext.Session.GetInt32("userId");
            loggedinUser = userHandler.GetLoggedinUser(userId);

            if (houseHandler.DeleteHouse(houseId))
            {
                GetFavoritesAndHouses(userId);
                return RedirectToPage();
            }

            return Page();
        }

        [BindProperty]
        public HouseModel NewHouse { get; set; } = new HouseModel();
        [BindProperty]
        public List<IFormFile> images { get; set; }
        public async Task<IActionResult> OnPostNewHouse()
        {
            if (ModelState.IsValid)
            {
                if (NewHouse == null)
                {
                    TempData["message"] = "House data is missing.";
                    return RedirectToPage("/Account");
                }

                try
                {
                    int isSold = NewHouse?.IsSold ?? false ? 1 : 0;
                    int userId = (int)HttpContext.Session.GetInt32("userId");
                    loggedinUser = userHandler.GetLoggedinUser(userId);
                    object[] houseData = new object[]
                    {
                        loggedinUser.GetId(),
                        NewHouse.Price,
                        NewHouse.Address,
                        NewHouse.City,
                        NewHouse.SqmLiving,
                        NewHouse.SqmProperty,
                        NewHouse.Volume,
                        NewHouse.Bedrooms,
                        NewHouse.Bathrooms,
                        NewHouse.Floors,
                        NewHouse.EnergyLabel.ToString(),
                        NewHouse.Description,
                        NewHouse.ConstructionYear,
                        isSold,
                        NewHouse.Type
                    };

                    int houseId = houseHandler.InsertHouse(houseData);

                    if (images != null && images.Count > 0)
                    {
                        var imageFolder = Path.Combine("wwwroot", "images", "house", houseId.ToString());
                        Directory.CreateDirectory(imageFolder);

                        for (int i = 0; i < images.Count; i++)
                        {
                            var extension = Path.GetExtension(images[i].FileName).ToLower();
                            var mimeType = images[i].ContentType.ToLower();

                            if (extension != ".jpg" && extension != ".jpeg" || (mimeType != "image/jpeg" && mimeType != "image/pjpeg"))
                            {
                                ModelState.AddModelError("", "Only JPG images are allowed.");
                                return Page();
                            }

                            var imgName = $"{houseId}_{i + 1}{extension}";
                            var filePath = Path.Combine(imageFolder, imgName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await images[i].CopyToAsync(fileStream);
                            }
                        }
                    }

                    TempData["message"] = "Successfully added a house";
                    return RedirectToPage("/Account");
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
