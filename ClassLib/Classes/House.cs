using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLib.Classes
{
    public abstract class House
    {
        public int houseId { get; set; }
        public int ownerId { get; set; }
        public User owner { get; set; }
        public int price { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int squareMeterLiving { get; set; }
        public int squareMeterProperty { get; set; }
        public int volume { get; set; }
        public int bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int floors { get; set; }
        public EnergyLabel energyLabel { get; set; }
        public string description { get; set; }
        public int constructionYear { get; set; }
        public bool isSold { get; set; }

        public int clicks { get; set; }

        public House(int houseId, int ownerId, User owner, int price, string address, string city, int sqMLiving, int sqMProperty, int volume, int bedrooms, int bathrooms, int floors, EnergyLabel energyLabel, string description, int constYear, bool isSold, int clicks)
        {

            this.houseId = houseId;
            this.ownerId = ownerId;
            this.owner = owner;
            this.price = price;
            this.address = address;
            this.city = city;
            squareMeterLiving = sqMLiving;
            squareMeterProperty = sqMProperty;
            this.volume = volume;
            this.bedrooms = bedrooms;
            this.bathrooms = bathrooms;
            this.floors = floors;
            this.energyLabel = energyLabel;
            this.description = description;
            constructionYear = constYear;
            this.isSold = isSold;
            this.clicks = clicks;
        }

        public int GetHouseId() { return houseId; }
        public double GetPrice() { return price; }

        public string FormattedPrice()
        {
            string formattedNumber = price.ToString("#,0", System.Globalization.CultureInfo.GetCultureInfo("nl-NL"));
            return formattedNumber;
        }
        public string GetAddress() { return address; }
        public string GetCity() { return city; }
        public int GetBedrooms() { return bedrooms; }
        public int GetBathrooms() { return bathrooms; }

        public int GetFloors() { return floors; }
        public int GetSqMLiving() { return squareMeterLiving; }
        public int GetSqMProperty() { return squareMeterProperty; }
        public int GetVolume() { return volume; }
        public EnergyLabel GetEnergyLabel() { return energyLabel; }
        public string GetDescription() { return description; }
        public int GetConstructionYear() { return constructionYear; }

        public string GetOwnerName()
        {
            return owner.GetName();
        }

        public int GetOwnerId()
        {
            return ownerId;
        }
        public string GetOwnerPhone()
        {
            return owner.GetPhoneNumber();
        }

        public string PricePerM2()
        {
            int pricePerM2 = price / squareMeterLiving;

            return pricePerM2.ToString();
        }

        public string IsSold()
        {
            if (isSold)
            {
                return "Sold";
            }
            else
            {
                return "Available";
            }
        }

        public virtual string GetType()
        {
            return "House";
        }
    }
}
