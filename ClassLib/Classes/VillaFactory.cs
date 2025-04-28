using ClassLib.Interfaces;
using System.ComponentModel.Design;
using ClassLib.Features;

namespace ClassLib.Classes;

public class VillaFactory : IHouseFactory
{
    public House CreateHouse(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving, int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel, string description, int constYear, bool isSold, int clicks)
    {
        return new Villa(houseId, ownerId, owner, price, address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors, energyLabel, description, constYear, isSold, clicks);
    }

    public IEnergyUsage CreateEnergyUsage()
    {
        return new VillaEnergyUsage();
    }

    public IArea CreateArea()
    {
        return new VillaArea();
    }

    public IDesign CreateDesign()
    {
        return new VillaDesign();
    }
}