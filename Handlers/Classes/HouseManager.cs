using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;

namespace Handlers.Classes
{
    public class HouseManager
    {
        private List<House> houses;
        private readonly IHouseHandler houseHand;
        private List<House> popularHouses;
        public HouseManager() 
        {
            houseHand = new HouseDB();
            houses = GetHouses();
            popularHouses = GetPopularHouses();
        }

        //public HouseHandler()
        //{
        //    GetHouses();
        //}

        private List<House> GetHouses()
        {
            houses = houseHand.GetHouses();
            return houses;
        }

        public bool UpdateHouse(object[] HouseData)
        {
            return houseHand.PublicHouseUpdate(HouseData);
        }

        public List<House> GetSimilarHouses(double price, int houseId)
        {
            return houseHand.GetSimilarHouses(price, houseId);
        }

        public List<House> ReturnHouses()
        {
            return houses;
        }

        public bool DeleteHouse(int houseId)
        {
            return houseHand.DeleteHouse(houseId);
        }

        public int InsertHouse(object[] houseData)
        {
            return houseHand.InsertHouse(houseData);
        }

        public List<House> GetFavs(int id)
        {
            return houseHand.GetFavs(id);
        }

        public House GetOwnerHouse(int ownerId)
        {
            return houses.FirstOrDefault(house => house.ownerId == ownerId);
        }

        public List<House> GetOwnerHouses(int ownerId)
        {
            return houses.Where(house => house.ownerId == ownerId).ToList();
        }

        public void AddClick(int houseId)
        {
            houseHand.AddClickHouse(houseId);
        }

        public List<House> ReturnPopularHouses()
        {
            return popularHouses;
        }
        private List<House> GetPopularHouses()
        {
            return popularHouses = houses.OrderByDescending(h=> h.clicks).Take(3).ToList();
        }

        public bool DeleteFav(int houseId, int ownerId)
        {
             return houseHand.DeleteFavorite(houseId, ownerId);
        }

        public bool AddFavorite(int houseId, int userId)
        {
            return houseHand.AddToFavorites(houseId, userId);
        }

    }
}
