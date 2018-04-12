using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;

namespace Week13CryptographyTests
{
    [TestClass]
    public class HashingEncryptionTests
    {
        [TestMethod]
        public void HashValuesMatch()
        {
            string password = "p@$$W0r|)";

            byte[] value = HashingEncryption.Hash(password);
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            Assert.IsTrue(value.SequenceEqual(hash));
        }
    }
}
