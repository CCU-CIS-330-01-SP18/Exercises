using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyAssignment;

namespace CryptographyTests
{
    [TestClass]
    public class AsymetricTests
    {
        [TestMethod]
        public void AsymmetricCheck()
        {
            string text = "The Rocket will be launching in 30 days!!";

            string decryptedText = Asymmetric.Encrypt(text);

            Assert.AreEqual(text, decryptedText);
        }
    }
}
