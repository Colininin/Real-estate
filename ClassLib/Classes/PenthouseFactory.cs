using ClassLib.Features;
using ClassLib.Interfaces;

namespace ClassLib.Classes;

public class PenthouseFactory : IHouseFactory
{
    public House CreateHouse(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving, int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel, string description, int constYear, bool isSold, int clicks)
    {
        return new Penthouse(houseId, ownerId, owner, price, address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors, energyLabel, description, constYear, isSold, clicks);
    }
    public IEnergyUsage CreateEnergyUsage()
    {
        return new PenthouseEnergyUsage();
    }

    public IArea CreateArea()
    {
        return new PenthouseArea();
    }

    public IDesign CreateDesign()
    {
        return new PenthouseDesign();
    }
}