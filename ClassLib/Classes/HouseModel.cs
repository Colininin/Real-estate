using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Classes
{
    public class HouseModel
    {
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int Price { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int SqmLiving { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int SqmProperty { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int Volume { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int Bedrooms { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int Bathrooms { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int Floors { get; set; }
        [Required]
        public EnergyLabel EnergyLabel { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.")]
        public int ConstructionYear { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool IsSold { get; set; }
    }
}
