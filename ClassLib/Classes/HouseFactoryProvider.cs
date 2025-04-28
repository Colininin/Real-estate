using ClassLib.Interfaces;

namespace ClassLib.Classes;

public static class HouseFactoryProvider
{
    public static IHouseFactory GetFactory(string type)
    {
        return type switch
        {
            "Villa" => new VillaFactory(),
            "Penthouse" => new PenthouseFactory(),
            _ => new NAFactory(),
        };
    }
}