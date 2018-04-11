using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Security;

namespace Week13SecurityTests
{
    [TestClass]
    public class SymmetricEncryptionTests
    {
        [TestMethod]
        public void CanEncrypt()
        {
            string filePath = "encrypt.txt";
            var file = File.CreateText(filePath);
            file.WriteLine("Encrypt THIS");
            file.Close();

            var encrypted = SymmetricEncryption.Encrypt(filePath);

            Assert.IsNotNull(encrypted, "The encryption method returned nothing.");
            Assert.IsTrue(encrypted.Count == 1, "More than one key-value pair was returned.");

            //Assert.AreEqual(SymmetricEncryption.Decrypt(encrypted.Values.First(), encrypted.Keys.First()), );

            File.Delete(filePath);
        }

        [TestMethod]
        public void CanDecrypt()
        {
            Assert.Fail();
        }
    }
}
