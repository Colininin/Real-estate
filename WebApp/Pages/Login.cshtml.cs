using Microsoft.AspNetCore.Mvc;
using ClassLib.Classes;
using WebApp.aspClass;
using ClassLib.Interfaces;

namespace WebApp.Pages
{
    public class LoginModel : BasePageModel
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


        [BindProperty]
        public LoginMod Login { get; set; }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User loggedInUser = userHandler.TryLogin(Login.Email, Login.Password);

                if (loggedInUser != null)
                {
                    HttpContext.Session.SetInt32("userId", loggedInUser.GetId());
                    HttpContext.Session.SetString("name", loggedInUser.GetName());
                    HttpContext.Session.SetString("email", loggedInUser.GetEmail());

                    return Redirect("Index");
                }

            }
            TempData["message"] = "Login Failed";
            return RedirectToPage();
        }
    }
}
