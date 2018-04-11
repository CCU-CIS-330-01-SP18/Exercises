using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Cryptography;

namespace SymmetricEncryptionTests
{
    [TestClass]
    public class SymmetricEncryptionTests
    {
        [TestMethod]
        public void SymmetricEncryptDecrypt()
        {
            // Uses a GUID as random encryption data.
            string randomDataToEncrypt = Guid.NewGuid().ToString("n").Substring(0, 8);
            byte[] key, iv;
            ICryptoTransform encryptor, decryptor;

            using (var csp = new AesCryptoServiceProvider())
            {
                key = csp.Key;
                iv = csp.IV;
                encryptor = csp.CreateEncryptor(key, iv);
                decryptor = csp.CreateDecryptor(key, iv);
            }

            byte[] encryptedData = SymmetricEncryption.Encrypt(randomDataToEncrypt, encryptor);
            string unencryptedData = SymmetricEncryption.Decrypt(encryptedData, decryptor);
            
            Assert.AreEqual(randomDataToEncrypt, unencryptedData);
        }
    }
}
