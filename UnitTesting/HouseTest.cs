using ClassLib.Classes;
using ClassLib.Interfaces;
using Moq;
using Handlers.Classes;
using ClassLib.Features;
namespace UnitTesting
{
    [TestClass]
    public class HouseTest
    {
        [TestMethod]
        public void TestMethodGetHouses()
        {
            var mockHouseHandler = new Mock<IHouseHandler>();

            IHouseFactory villaFactory = new VillaFactory();
            IHouseFactory penthouseFactory = new PenthouseFactory();

            var expectedHouses = new List<House>
            {
                villaFactory.CreateHouse(
                    1,
                    1,
                    new PrivateSeller(1, "Private", "Colin van der Tak", "Colin@gmail.com", 12345678),
                    450000,
                    "Rachelsmolen 10",
                    "1234AJ Eindhoven",
                    100,
                    150,
                    200,
                    3,
                    2,
                    2,
                    EnergyLabel.A,
                    "house description",
                    2002,
                    false,
                    1
                ),

                penthouseFactory.CreateHouse(
                    2,
                    2,
                    new Broker(1, "Broker", "Freek Vonk", "Freek@gmail.com", 12345678),
                    500000,
                    "Rachelsmolen 15",
                    "1234AJ Eindhoven",
                    100,
                    150,
                    200,
                    3,
                    2,
                    2,
                    EnergyLabel.B,
                    "house description2",
                    2004,
                    false,
                    4
                )
            };

            mockHouseHandler.Setup(h => h.GetHouses()).Returns(expectedHouses);

            var houses = mockHouseHandler.Object.GetHouses();

            Assert.IsNotNull(houses, "The houses list should be populated");
            Assert.AreEqual(expectedHouses.Count, houses.Count, "The list contains the expected amount of items");
        }

    }
}
