using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ClassLib.Classes;
using WebApp.aspClass;
using ClassLib.Interfaces;

namespace WebApp.Pages
{
    public class RegisterModel : BasePageModel
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
        public RegisterMod Register { get; set; }
        
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                if(Register.Password == Register.PassConfirm)
                {
                    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                    string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: Register.Password!,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8)
                        );

                    Object[] registerData = new Object[]
                    {
                        Register.Type,
                        Register.Name,
                        Register.Email,
                        Register.PhoneNumber,
                        hashedPass,
                        salt
                    };

                    if (userHandler.RegisterAccount(registerData))
                    {
                        TempData["message"] = "Registered succesfully";
                        return RedirectToPage("Login");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something went wrong");
                        return Page();
                    }
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Passwords did not match");
                    return Page(); 
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
