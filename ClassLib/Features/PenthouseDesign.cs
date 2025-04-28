using ClassLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Features
{
    public class PenthouseDesign : IDesign
    {
        public string GetDesign()
        {
            return "Penthouse Design: Modern";
        }
    }
}
