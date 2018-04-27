using System;
using ASN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASNTests
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void CanHashString()
        {
            string text = "A secret password";
            string hash1 = PasswordHasher.HashPassword(text);
            string hash2 = PasswordHasher.HashPassword(text);

            Assert.AreEqual(hash1, hash2);
        }
    }
}
