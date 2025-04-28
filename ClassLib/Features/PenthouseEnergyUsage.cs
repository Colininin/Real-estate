using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Classes;
using ClassLib.Interfaces;

namespace ClassLib.Features
{
    public class PenthouseEnergyUsage : IEnergyUsage
    {
        public string CalculateEfficiency(int squareMeters, EnergyLabel energyLabel)
        {
            if (energyLabel == EnergyLabel.A)
            {
                return "Excellent energy efficiency";
            }
            else if (energyLabel == EnergyLabel.B && squareMeters > 150)
            {
                return "Good energy efficiency but consider improvements";
            }
            else if (energyLabel == EnergyLabel.C)
            {
                return "Average energy efficiency, room for improvement";
            }
            return "Poor energy efficiency";
        }
    }
}
