using ClassLib.Classes;
using ClassLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.aspClass;

namespace WebApp.Pages
{
    public class houseDetailsModel : BasePageModel
    {
        public bool loggedin = false;
        public House house;
        public List<string> houseImages { get; set; }
        public string imageFolderPath { get; set; }
        public List<House> similarHouses;

        public string EnergyString;
        public string AreaString;
        IEnergyUsage energyCalc = null;
        IArea areaCalc = null;

        public houseDetailsModel()
        {
            houseImages = new List<string>();
        }

        public IActionResult OnGet()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
                Console.WriteLine("onGet: user is loggedin");
            }
            else
            {
                loggedin = false;
                Console.WriteLine("OnGet: user is not loggedin");
            }

            if (Request.Query.TryGetValue("id", out var id))
            {
                int houseId = Convert.ToInt32(id);
                InitializeHouseDetails(houseId);
            }
            else
            {
                return Redirect("/Error");
            }

            return Page();
        }

        private void InitializeHouseDetails(int houseId)
        {
            house = houseHandler.ReturnHouses().Find(house => house.GetHouseId() == houseId);
            if (house == null)
            {
                Redirect("/Error");
            }

            similarHouses = new List<House>(GetSimilarHouses(house.GetPrice(), house.GetHouseId()));
            houseHandler.AddClick(house.GetHouseId());

            InitializeHouseCalculators(house);
            LoadHouseImages(house);
        }

        private void InitializeHouseCalculators(House house)
        {
            if (house is Penthouse)
            {
                IHouseFactory penthouseFactory = new PenthouseFactory();
                energyCalc = penthouseFactory.CreateEnergyUsage();
                areaCalc = penthouseFactory.CreateArea();
            }
            else if (house is Villa)
            {
                IHouseFactory villaFactory = new VillaFactory();
                energyCalc = villaFactory.CreateEnergyUsage();
                areaCalc = villaFactory.CreateArea();
            }
            else
            {
                IHouseFactory naFactory = new NAFactory();
                energyCalc = naFactory.CreateEnergyUsage();
                areaCalc = naFactory.CreateArea();
            }

            if (energyCalc != null)
            {
                EnergyString = energyCalc.CalculateEfficiency(house.GetSqMLiving(), house.GetEnergyLabel());
                AreaString = areaCalc.AreaValuation(house.GetSqMLiving());
            }
        }

        private void LoadHouseImages(House house)
        {
            var imageFolder = Path.Combine("wwwroot", "images", "house", house.GetHouseId().ToString());
            if (Directory.Exists(imageFolder))
            {
                imageFolderPath = $"/images/house/{house.GetHouseId()}";
                houseImages = Directory.GetFiles(imageFolder).Select(Path.GetFileName).ToList();
            }
            else
            {
                imageFolderPath = "/images/house/placeHolder";
                var imageFolderPlaceHolder = Path.Combine("wwwroot", "images", "house", "placeHolder");
                houseImages = Directory.GetFiles(imageFolderPlaceHolder).Select(Path.GetFileName).ToList();
            }
        }

        private List<House> GetSimilarHouses(double price, int houseId)
        {
            return houseHandler.GetSimilarHouses(price, houseId);
        }

        public IActionResult OnPostAddFavorite()
        {
            if (IsLoggedIn())
            {
                loggedin = true;
                
                int? userId = HttpContext.Session.GetInt32("userId");
                if (userId == null)
                {
                    return Redirect("/Error");
                }

                if (!int.TryParse(Request.Form["houseId"], out int houseId))
                {
                    return Redirect("/Error");
                }

                house = houseHandler.ReturnHouses().Find(house => house.GetHouseId() == houseId);

                if (house == null)
                {
                    return Redirect("/Error");
                }

                if (houseHandler.AddFavorite(houseId, (int)userId))
                {
                    Console.WriteLine("House added to favorites");
                    TempData["message"] = "House added to favorites";
                    InitializeHouseDetails(houseId);
                    return RedirectToPage("/HouseDetails", new { id = houseId });
                }
                else
                {
                    TempData["message"] = "Something went wrong, please try again";
                    return RedirectToPage("/HouseDetails", new { id = houseId });
                }
            }
            else
            {
                return Redirect("/Login");
            }
        }
    }
}
