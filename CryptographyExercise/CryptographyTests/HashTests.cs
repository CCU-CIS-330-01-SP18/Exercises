using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyExercise;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace CryptographyTests
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void CanHashNukeCodes()
        {
            string nukeAttempt = "12345NUKEM";
            string realNukeCode = "12345NUKEM";
            byte[] hashedCode = HashingCryptography.HashThat(nukeAttempt);

            byte[] realCode = Encoding.UTF8.GetBytes(realNukeCode);
            byte[] hashedRealCode = SHA256.Create().ComputeHash(realCode);

            Assert.IsTrue(hashedRealCode.SequenceEqual(hashedCode));
        }
    }
}
