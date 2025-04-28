using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Interfaces;

namespace ClassLib.Features
{
    public class VillaArea: IArea
    {
        public string AreaValuation(int squareMeters)
        {
            if (squareMeters > 300)
            {
                return "Luxury villa with plenty of space";
            }
            else if (squareMeters > 200)
            {
                return "Comfortable living area";
            }
            return "Smaller villa, might feel cramped";
        }
    }
}
