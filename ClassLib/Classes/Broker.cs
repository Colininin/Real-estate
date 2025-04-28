using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Classes
{
    public class Broker:User
    {
        private List<House> myHouses;
        public Broker(int id, string accType, string name, string email, int phoneNumber) : base(id, accType, name, email, phoneNumber)
        {
           //myHouses = new List<House>(GetHouses());
        }

        public List<House> ReturnHouses()
        {
            return myHouses;
        }

        //private List<House> GetHouses()
        //{
        //    HouseHandler houseHand = new HouseHandler();
        //
        //    IEnumerable<House> allHouses = houseHand.ReturnHouses();
        //
        //    return allHouses.Where(house => house.GetOwnerId() == this.GetId()).ToList();
        //
        //}

    }
}
