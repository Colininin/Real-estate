using ClassLib.Classes;
using ClassLib.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Handlers.Classes;
namespace UnitTesting
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestMethodLogin()
        {
            var mockAccountHandler = new Mock<IAccountHandler>();
            var expectedUser = new PrivateSeller(1, "Private", "Colin van der Tak", "colin@gmail.com", 12345678);

            mockAccountHandler.Setup(m => m.PublicLogin("Colin@gmail.com", "Colin123")).Returns(expectedUser);

            var userHand = new UserManager(mockAccountHandler.Object);

            var result = userHand.TryLogin("Colin@gmail.com", "Colin123");

            Assert.IsNotNull(result, "Result is null but should return a user");
            Assert.IsInstanceOfType(result, typeof(User));

        }

        [TestMethod]
        public void TestMethodCreateAccount()
        {
            // Arrange
            var mockAccountHandler = new Mock<IAccountHandler>();

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: "Password",
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );

            Object[] registerData = new Object[]
            {
                "Private",
                "Colin van der Tak",
                "Colinln@gmail.com",
                12345678,
                hashedPass,
                salt
            };

            mockAccountHandler.Setup(m => m.PublicRegister(registerData)).Returns(true);

            var userHand = new UserManager(mockAccountHandler.Object);

            var result = userHand.RegisterAccount(registerData);

            Assert.IsTrue(result, "User is registered");

            mockAccountHandler.Verify(m => m.PublicRegister(registerData), Times.Once); 
        }
    }
}
