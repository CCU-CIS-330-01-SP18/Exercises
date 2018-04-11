using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Cryptography;

namespace Week13CryptographyTests
{
    [TestClass]
    public class SHAHashingTests
    {
        [TestMethod]
        public void CanComputeHash()
        {
            string secretPhrase = "Haden is a nerd";
            string hashedValue = SHAHashing.Hash(secretPhrase);
            
            Assert.AreEqual(hashedValue, "�%ym$�� <D��<r��'07ݟ#0եD�");
        }
    }
}