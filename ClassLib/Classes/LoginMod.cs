using System.ComponentModel.DataAnnotations;
using System;

namespace ClassLib.Classes
{
    public class LoginMod
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{5,}$",
        ErrorMessage = "Password must be at least 5 characters long and contain only letters and numbers.")]
        public string Password { get; set; }

        public LoginMod()
        {

        }

        public LoginMod(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}
