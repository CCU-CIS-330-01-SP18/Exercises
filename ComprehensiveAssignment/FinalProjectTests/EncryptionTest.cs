using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
using System.Text;
using System.Security.Cryptography;

namespace FinalProjectTests
{
    [TestClass]
    public class EncryptionTest
    {
        [TestMethod]
        public void HashingTest()
        {
            // Create the password in plain text.
            string password = "ThereCanOnlyBeOne";

            // Encrypt the password using the Hash method.
            string result1 = Encryption.HashItUp(password);

            // Encrypt the password yourself.
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            // Convert the hashed bytes to a string.
            string result2 = Encoding.UTF8.GetString(hash);

            // Ensure that the output is the same.
            Assert.AreEqual(result1, result2);
        }
    }
}
