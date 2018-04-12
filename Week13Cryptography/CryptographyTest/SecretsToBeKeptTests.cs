using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyTest
{
    [TestClass]
    public class SecretsToBeKeptTests
    {
        [TestMethod]
        public void SymetryicEncriptionTest()
        {
            // Generate some text to be encrypted.
            string text = "One ring to rule them all, one ring to find them. One ring to bring them all and in the darkness bind them.";

            // Symetrically encrypt the text, and return the decrypted version of that text.
            string result = SecretsToBeKept.SymmetricEncryptionItUp(text);

            // Check to see if the decrypted text which the method returned is the same as the text we wanted to be encrypted.
            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void HashingTest()
        {
            // Create the password in plain text.
            string password = "ThereCanOnlyBeOne";

            // Encrypt the password using the Hash method.
            string result1 = SecretsToBeKept.HashItUp(password);

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
