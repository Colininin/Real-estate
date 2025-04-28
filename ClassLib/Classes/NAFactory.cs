using ClassLib.Features;
using ClassLib.Interfaces;

namespace ClassLib.Classes;

public class NAFactory : IHouseFactory
{
    public House CreateHouse(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving, int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel, string description, int constYear, bool isSold, int clicks)
    {
        return new NA(houseId, ownerId, owner, price, address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors, energyLabel, description, constYear, isSold, clicks);
    }
    public IEnergyUsage CreateEnergyUsage()
    {
        return new NAEnergyUsage();
    }

    public IArea CreateArea()
    {
        return new NAArea();
    }

    public IDesign CreateDesign()
    {
        return new NADesign();
    }
}