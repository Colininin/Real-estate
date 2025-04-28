using ClassLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Features
{
    public class NAArea : IArea
    {
        public string AreaValuation(int squareMeters)
        {
            return "N/A Area: Undefined";
        }
    }
}

