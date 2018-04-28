using System;
using System.Text;
using JamesNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamesNetTests.Models
{
    [TestClass]
    public class EncryptorTests
    {
        [TestMethod]
        public void CanEncryptDecrypt()
        {
            Encryptor.GenerateIV();
            string stringToEncrypt = "Lorem Ipsum";

            byte[] encrypted = Encryptor.Encrypt(stringToEncrypt, "test").Result;

            Assert.IsNotNull(encrypted, "The encryption method returned nothing.");
            Assert.AreNotEqual(stringToEncrypt, Encoding.UTF8.GetString(encrypted), "The encryption method did not actually encrypt the string.");

            string decrypted = Encryptor.Decrypt(encrypted, "test").Result;

            Assert.AreEqual(stringToEncrypt, decrypted, "Decryption yielded a different result.");
        }
    }
}
