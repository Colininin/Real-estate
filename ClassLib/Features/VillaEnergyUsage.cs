using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Classes;
using ClassLib.Interfaces;

namespace ClassLib.Features
{
    public class VillaEnergyUsage: IEnergyUsage
    {
        public string CalculateEfficiency(int squareMeters, EnergyLabel energyLabel)
        {
            if (energyLabel == EnergyLabel.A)
            {
                return "Top-notch energy efficiency";
            }
            else if (energyLabel == EnergyLabel.B)
            {
                return "Good energy efficiency";
            }
            else if (energyLabel == EnergyLabel.C && squareMeters > 200)
            {
                return "Average efficiency but large space makes up for it";
            }
            return "Needs energy efficiency improvements";
        }
    }
}
