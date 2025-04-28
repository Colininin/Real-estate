using ClassLib.Classes;

namespace ClassLib.Interfaces
{
    public interface IHouseHandler
    {

        bool PublicHouseUpdate(object[] houseData);
        List<House> GetHouses();

        List<House> GetSimilarHouses(double price, int houseId);

        bool DeleteHouse(int houseId);

        int InsertHouse(object[] houseData);

        List<House> GetFavs(int id);

        void AddClickHouse(int  houseId);

        bool DeleteFavorite(int houseId, int ownerId);
        bool AddToFavorites(int houseId, int userId);

    }
}
