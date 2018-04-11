using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Cryptography;

namespace SymmetricEncryptionTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void PasswordHashesMatch()
        {
            // Generates a random alphanumeric password between 10 and 20 characters long.
            string password = Guid.NewGuid().ToString("n").Substring(0, new Random().Next(10, 20));

            // Yes, the following is that boring.
            byte[] hashedPassword = Hashing.GetHashOf(password);
            byte[] rehashedPassword = Hashing.GetHashOf(password);

            Assert.IsTrue(hashedPassword.SequenceEqual(rehashedPassword));
        }
    }
}
