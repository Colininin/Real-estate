using ClassLib.Interfaces;

namespace ClassLib.Classes
{
    public class PrivateSeller : User
    {
        private House myHouse;

        public PrivateSeller(int id, string accType, string name, string email, int phoneNumber) : base(id, accType,
            name, email, phoneNumber)
        {
            //myHouse = GetHouse();
        }

        public House ReturnHouse()
        {
            return myHouse;
        }
    }
}
