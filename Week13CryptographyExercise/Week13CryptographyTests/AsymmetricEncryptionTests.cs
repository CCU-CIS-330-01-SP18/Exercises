using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;

namespace Week13CryptographyTests
{
    [TestClass]
    public class AsymmetricEncryptionTests
    {
        [TestMethod]
        public void CanEncryptAndDecryptEncryption()
        {
            string text = "Super secret information.";
            string encryptedText = AsymmetricEncryption.Encrypt(text);

            Assert.AreEqual(text, encryptedText);
        }
    }
}
