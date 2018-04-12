using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Week13CryptographyExerciseTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void HashesDataAccuratetly()
        {
            string plainText = "The combination to my gold safe is 49 22 12";

            byte[] hashData = Hashing.HashData(plainText);

            byte[] comparisonBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] comparisonHash = SHA256.Create().ComputeHash(comparisonBytes);

            Assert.IsTrue(hashData.SequenceEqual(comparisonHash));
        }
    }
}
