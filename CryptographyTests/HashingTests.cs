using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyAssignment;

namespace CryptographyTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void HashKeyCheck()
        {
            string key = Guid.NewGuid().ToString("n").Substring(0, new Random().Next(10, 20));

            byte[] hashedKey = Hashing.Hash(key);
            byte[] rehashedKey = Hashing.Hash(key);

            Assert.IsTrue(hashedKey.SequenceEqual(rehashedKey));
        }
    }
}
