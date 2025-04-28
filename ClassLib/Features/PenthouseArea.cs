using ClassLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Features
{
    public class PenthouseArea : IArea
    {
        public string AreaValuation(int squareMeters)
        {
            if (squareMeters > 250)
            {
                return "Spacious penthouse";
            }
            else if (squareMeters > 150)
            {
                return "Moderately spacious penthouse";
            }
            return "Compact penthouse";
        }
    }
}
