using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Classes;

namespace ClassLib.Interfaces
{
    public interface IHouseFactory
    {
        House CreateHouse(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving,
            int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel,
            string description, int constYear, bool isSold, int clicks);

        IEnergyUsage CreateEnergyUsage();
        IArea CreateArea();
        IDesign CreateDesign();
    }
}
