using MySql.Data.MySqlClient;
using ClassLib.Interfaces;
using ClassLib.Classes;
using System.Runtime.InteropServices.ObjectiveC;
using Org.BouncyCastle.Bcpg;
using static ClassLib.Classes.HouseFactoryProvider;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Classes
{
    public class HouseDB: IHouseHandler
    {
        public MySqlConnection MakeConnection()
        {
            
            string connectionString =
                "Server=server;" +
                "Database=database_name;" +
                "User ID=username;" +
                "Password=password;" +
                "Connection Timeout=2;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            
            if (TestConnection(connection))
            {
                return connection; 
            }
            else
            {
                Console.WriteLine("Connection test failed.");
                return null;
            }

        }
        public bool TestConnection(MySqlConnection conn)
        {
            try
            {
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MYSQL Exception: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool PublicHouseUpdate(object[] houseData)
        {
            return PrivateHouseUpdate(MakeConnection(), houseData);
        }

        public List<House> GetHouses()
        {
            return FetchHouses(MakeConnection());
        }

        public List<House> GetSimilarHouses(double price, int houseId)
        {
            return GetSimilar(MakeConnection(), price, houseId);
        }

        public bool DeleteHouse(int houseId)
        {
            return PrivateDeleteHouse(MakeConnection(), houseId);
        }

        public int InsertHouse(object[] houseData)
        {
            return PrivateInsert(MakeConnection(), houseData);
        }

        public List<House> GetFavs(int id)
        {
            return PrivateFavs(id, MakeConnection());
        }

        public void AddClickHouse(int houseId)
        {
            PrivateAddClick(houseId, MakeConnection());
        }

        public bool DeleteFavorite(int houseId, int ownerId)
        {
            return PrivateDeleteFav(houseId, ownerId, MakeConnection());
        }

        public bool AddToFavorites(int houseId, int userId)
        {
            return PrivateAddFav(houseId, userId, MakeConnection());   
        }



        private bool PrivateHouseUpdate(MySqlConnection connection, object[] houseData)
        {
            bool success = false;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query =
                            "UPDATE houses SET address = @newAddress, city = @newCity, price = @newPrice, squareMLiving = @newLiving, squareMProperty = @newProperty, volume = @newVolume, bedrooms = @newBed, bathrooms = @newBath, floors = @newFloors, energyLabel = @newEL, description = @newDesc, constructionYear = @newYear, isSold = @newSold WHERE houseId = @houseID;";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@houseID", houseData[0]);
                            cmd.Parameters.AddWithValue("@newAddress", houseData[1]);
                            cmd.Parameters.AddWithValue("@newCity", houseData[2]);
                            cmd.Parameters.AddWithValue("@newPrice", houseData[3]);
                            cmd.Parameters.AddWithValue("@newLiving", houseData[4]);
                            cmd.Parameters.AddWithValue("@newProperty", houseData[5]);
                            cmd.Parameters.AddWithValue("@newVolume", houseData[8]);
                            cmd.Parameters.AddWithValue("@newBed", houseData[7]);
                            cmd.Parameters.AddWithValue("@newBath", houseData[6]);
                            cmd.Parameters.AddWithValue("@newFloors", houseData[9]);
                            cmd.Parameters.AddWithValue("@newEL", houseData[10]);
                            cmd.Parameters.AddWithValue("@newDesc", houseData[13]);
                            cmd.Parameters.AddWithValue("@newYear", houseData[11]);
                            cmd.Parameters.AddWithValue("@newSold", houseData[12]);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            success = rowsAffected > 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }

        private List<House> FetchHouses(MySqlConnection connection)
        {
            List<House> houses = new List<House>();

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "SELECT h.*, ph.click_amount " +
                                       "FROM houses h " +
                                       "LEFT JOIN pop_houses ph ON h.houseId = ph.houseId";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int houseId = Convert.ToInt32(reader["houseId"]);
                                    int ownerId = Convert.ToInt32(reader["ownerId"]);
                                    int price = Convert.ToInt32(reader["price"]);
                                    string address = reader["address"].ToString();
                                    string city = reader["city"].ToString();
                                    int sqMLiving = Convert.ToInt32(reader["squareMLiving"]);
                                    int sqMProperty = Convert.ToInt32(reader["squareMProperty"]);
                                    int volume = Convert.ToInt32(reader["volume"]);
                                    int bedrooms = Convert.ToInt32(reader["bedrooms"]);
                                    int bathrooms = Convert.ToInt32(reader["bathrooms"]);
                                    int floors = Convert.ToInt32(reader["floors"]);
                                    string energyLabel = reader["energyLabel"].ToString();
                                    string description = reader["description"].ToString();
                                    int constructionYear = Convert.ToInt32(reader["constructionYear"]);
                                    int isSold = Convert.ToInt32(reader["isSold"]);
                                    string type = reader["type"].ToString();
                                    int clicks = reader["click_amount"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(reader["click_amount"]);

                                    EnergyLabel energyLabelEnum;
                                    if (Enum.TryParse(energyLabel, out energyLabelEnum))
                                    {
                                        User owner = GetOwner(ownerId, MakeConnection());
                                        IHouseFactory factory = GetFactory(type);
                                        if (isSold == 1)
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, price, address,
                                                city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors,
                                                energyLabelEnum, description, constructionYear, true, clicks);
                                            houses.Add(house);
                                        }
                                        else
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, price, address,
                                                city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms, floors,
                                                energyLabelEnum, description, constructionYear, false, clicks);
                                            houses.Add(house);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Retrieving houses went wrong:", ex);
                }
            }
            return houses;
        }

        
        private List<House> GetSimilar(MySqlConnection connection, double price, int id)
        {
            List<House> similarHouses = new List<House>();

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "SELECT h.*, ph.click_amount " +
                                       "FROM houses h " +
                                       "LEFT JOIN pop_houses ph ON h.houseId = ph.houseId " +
                                       "WHERE h.price BETWEEN (@housePrice - 100000) AND (@housePrice + 100000) AND h.houseId != @id " +
                                       "LIMIT 5";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@housePrice", price);
                            cmd.Parameters.AddWithValue("@id", id);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    int houseId = Convert.ToInt32(reader["houseId"]);
                                    int ownerId = Convert.ToInt32(reader["ownerId"]);
                                    int similarPrice = Convert.ToInt32(reader["price"]);
                                    string address = reader["address"].ToString();
                                    string city = reader["city"].ToString();
                                    int sqMLiving = Convert.ToInt32(reader["squareMLiving"]);
                                    int sqMProperty = Convert.ToInt32(reader["squareMProperty"]);
                                    int volume = Convert.ToInt32(reader["volume"]);
                                    int bedrooms = Convert.ToInt32(reader["bedrooms"]);
                                    int bathrooms = Convert.ToInt32(reader["bathrooms"]);
                                    int floors = Convert.ToInt32(reader["floors"]);
                                    string energyLabel = reader["energyLabel"].ToString();
                                    string description = reader["description"].ToString();
                                    int constructionYear = Convert.ToInt32(reader["constructionYear"]);
                                    int isSold = Convert.ToInt32(reader["isSold"]);
                                    string type = reader["type"].ToString();
                                    int clicks = reader["click_amount"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(reader["click_amount"]);

                                    EnergyLabel energyLabelEnum;
                                    if (Enum.TryParse(energyLabel, out energyLabelEnum))
                                    {
                                        User owner = GetOwner(ownerId, MakeConnection());
                                        IHouseFactory factory = GetFactory(type);
                                        if (isSold == 1)
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, similarPrice,
                                                address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms,
                                                floors, energyLabelEnum, description, constructionYear, true, clicks);
                                            similarHouses.Add(house);
                                        }
                                        else
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, similarPrice,
                                                address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms,
                                                floors, energyLabelEnum, description, constructionYear, false, clicks);
                                            similarHouses.Add(house);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return similarHouses;

        }

        private bool PrivateDeleteHouse(MySqlConnection connection, int houseId)
        {
            bool success = false;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query =
                            "DELETE FROM favorites WHERE houseId = @houseId; DELETE FROM pop_houses WHERE houseId = @houseId; DELETE FROM houses WHERE houseId = @houseId;";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@houseId", houseId);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            success = rowsAffected > 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }

        private int PrivateInsert(MySqlConnection connection, object[] houseData)
        {
            int houseId = -1;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();

                    string query = "INSERT INTO houses (ownerId, price, address, city, squareMLiving, squareMProperty, volume, bedrooms, bathrooms, floors, energyLabel, description, constructionYear, isSold, type) " +
                       "VALUES (@ownerId, @price, @address, @city, @sqMLiving, @sqMProperty, @volume, @bedrooms, @bathrooms, @floors, @energyLabel, @description, @constructionYear, @isSold, @type); " +
                       "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ownerId", houseData[0]);
                        cmd.Parameters.AddWithValue("@price", houseData[1]);
                        cmd.Parameters.AddWithValue("@address", houseData[2]);
                        cmd.Parameters.AddWithValue("@city", houseData[3]);
                        cmd.Parameters.AddWithValue("@sqMLiving", houseData[4]);
                        cmd.Parameters.AddWithValue("@sqMProperty", houseData[5]);
                        cmd.Parameters.AddWithValue("@volume", houseData[6]);
                        cmd.Parameters.AddWithValue("@bedrooms", houseData[7]);
                        cmd.Parameters.AddWithValue("@bathrooms", houseData[8]);
                        cmd.Parameters.AddWithValue("@floors", houseData[9]);
                        cmd.Parameters.AddWithValue("@energyLabel", houseData[10]);
                        cmd.Parameters.AddWithValue("@description", houseData[11]);
                        cmd.Parameters.AddWithValue("@constructionYear", houseData[12]);
                        cmd.Parameters.AddWithValue("@isSold", houseData[13]);
                        cmd.Parameters.AddWithValue("@type", houseData[14]);

                        houseId = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return houseId;
        }

        private List<House> PrivateFavs(int id, MySqlConnection connection)
        {
            List<House> favorites = new List<House>();

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "SELECT h.*, ph.click_amount " +
                                       "FROM favorites f " +
                                       "JOIN houses h ON f.houseId = h.houseId " +
                                       "LEFT JOIN pop_houses ph ON h.houseId = ph.houseId " +
                                       "WHERE f.userId = @userId";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", id);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    int houseId = Convert.ToInt32(reader["houseId"]);
                                    int ownerId = Convert.ToInt32(reader["ownerId"]);
                                    int similarPrice = Convert.ToInt32(reader["price"]);
                                    string address = reader["address"].ToString();
                                    string city = reader["city"].ToString();
                                    int sqMLiving = Convert.ToInt32(reader["squareMLiving"]);
                                    int sqMProperty = Convert.ToInt32(reader["squareMProperty"]);
                                    int volume = Convert.ToInt32(reader["volume"]);
                                    int bedrooms = Convert.ToInt32(reader["bedrooms"]);
                                    int bathrooms = Convert.ToInt32(reader["bathrooms"]);
                                    int floors = Convert.ToInt32(reader["floors"]);
                                    string energyLabel = reader["energyLabel"].ToString();
                                    string description = reader["description"].ToString();
                                    int constructionYear = Convert.ToInt32(reader["constructionYear"]);
                                    int isSold = Convert.ToInt32(reader["isSold"]);
                                    string type = reader["type"].ToString();
                                    int clicks = reader["click_amount"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(reader["click_amount"]);

                                    EnergyLabel energyLabelEnum;
                                    if (Enum.TryParse(energyLabel, out energyLabelEnum))
                                    {
                                        User owner = GetOwner(ownerId, MakeConnection());
                                        IHouseFactory factory = GetFactory(type);
                                        if (isSold == 1)
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, similarPrice,
                                                address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms,
                                                floors, energyLabelEnum, description, constructionYear, true, clicks);
                                            favorites.Add(house);
                                        }
                                        else
                                        {
                                            House house = factory.CreateHouse(houseId, ownerId, owner, similarPrice,
                                                address, city, sqMLiving, sqMProperty, volume, bedrooms, bathrooms,
                                                floors, energyLabelEnum, description, constructionYear, false, clicks);
                                            favorites.Add(house);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return favorites;
        }


        private void PrivateAddClick(int houseId, MySqlConnection connection)
        {
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();

                    string query = "INSERT INTO pop_houses (houseId, click_amount) VALUES (@houseId, 1) ON DUPLICATE KEY UPDATE click_amount = click_amount + 1;";

                    using (MySqlCommand cmd = new(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@houseId", houseId);
                        cmd.ExecuteNonQuery();
                    }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }


        private bool PrivateDeleteFav(int houseId, int ownerId, MySqlConnection connection)
        {
            bool success = false;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "DELETE FROM favorites WHERE houseId = @houseId AND userId = @ownerId";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@houseId", houseId);
                            cmd.Parameters.AddWithValue("@ownerId", ownerId);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            success = rowsAffected > 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }

        private bool PrivateAddFav(int houseId, int userId, MySqlConnection connection)
        {
            bool success = false;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                    string query = "INSERT INTO favorites (userId, houseId) VALUES (@userId, @houseId)";

                    using (MySqlCommand cmd = new(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@houseId", houseId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return success;
        }


        private User GetOwner(int ownerId, MySqlConnection connection)
        {
            User owner = null;

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "SELECT * FROM users WHERE id = @ownerId";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ownerId", ownerId);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int userId = Convert.ToInt32(reader["id"]);
                                    string accountType = reader["type"].ToString();
                                    string name = reader["name"].ToString();
                                    string email = reader["email"].ToString();
                                    int phonenum = Convert.ToInt32(reader["phonenumber"]);

                                    if (accountType == "Private")
                                    {
                                        owner = new PrivateSeller(userId, accountType, name, email, phonenum);
                                    }
                                    else if (accountType == "Broker")
                                    {
                                        owner = new Broker(userId, accountType, name, email, phonenum);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Retrieving users went wrong:", ex);
                }
            }
            return owner;
        }
    }
}
