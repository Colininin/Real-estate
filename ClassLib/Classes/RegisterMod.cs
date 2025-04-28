using System.ComponentModel.DataAnnotations;
using System;

namespace ClassLib.Classes
{
    public class RegisterMod
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{5,}$",
            ErrorMessage = "Password must be at least 5 characters long and contain only letters and numbers.")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{5,}$",
            ErrorMessage = "Password must be at least 5 characters long and contain only letters and numbers.")]
        public string PassConfirm { get; set; }
        [Required]
        public string Type { get; set; }
        public RegisterMod()
        {

        }
        public RegisterMod(string type, string name, string email, int phone, string password, string passConfirm)
        {
            Type = type;
            Name = name;
            Email = email;
            PhoneNumber = phone;
            Password = password;
            PassConfirm = passConfirm;
        }
    }
}
