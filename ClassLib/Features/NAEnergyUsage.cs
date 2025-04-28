using ClassLib.Classes;
using ClassLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Features
{
    public class NAEnergyUsage : IEnergyUsage
    {
        public string CalculateEfficiency(int squareMeters, EnergyLabel energyLabel)
        {
            return "N/A Energy Usage: Unknown";
        }
    }
}
