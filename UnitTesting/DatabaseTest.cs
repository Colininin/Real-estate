using Microsoft.AspNetCore.Routing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using ClassLib.Classes;

namespace UnitTesting
{
    [TestClass]
    public class DatabaseTest
    {
        HouseDB houseDB = new HouseDB();
        private readonly string connectionString =
            "Server=server;" +
            "Database=database_name;" +
            "User ID=username;" +
            "Password=password;";

        private MySqlConnection MakeConnection()
        {
            MySqlConnection connection = new(connectionString);
            return connection;
        }

        [TestMethod]
        public void TestMethodConnectionTest()
        {
            MySqlConnection connection = MakeConnection();

            connection.Open();
            bool isConnected = connection.State == System.Data.ConnectionState.Open;

            Assert.IsTrue(isConnected, "Connection opened");
            connection.Close();
        }


        [TestMethod]
        public void TestMethodUpdateHouseFail()
        {
            MySqlConnection connection = MakeConnection();
            object[] houseData = new object[] { -1, "New Address", "New City", 100000, 120, 150, 200, 2, 2, "B", "Updated description", 2000, 1 };

            bool result = houseDB.PublicHouseUpdate(houseData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethodFetchHouses()
        {
            MySqlConnection connection = MakeConnection();

            List<House> houses = houseDB.GetHouses();

            Assert.IsNotNull(houses);
        }
    }
}
