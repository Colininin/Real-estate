namespace ClassLib.Classes;

public class NA(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving, int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel, string description, int constYear, bool isSold, int clicks) : House(houseId, ownerId, owner, price, address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors, energyLabel, description, constYear, isSold, clicks)
{
    public override string GetType()
    {
        return "N/A";
    }
}