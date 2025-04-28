using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Interfaces;

namespace ClassLib.Features
{
    public class VillaDesign : IDesign
    {
        public string GetDesign()
        {
            return "Villa design: Luxury";
        }
    }
}
