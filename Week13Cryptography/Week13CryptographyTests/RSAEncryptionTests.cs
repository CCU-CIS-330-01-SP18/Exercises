using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Cryptography;

namespace Week13CryptographyTests
{
    [TestClass]
    public class RSAEncryptionTests
    {
        [TestMethod]
        public void CanPerformAsymmetricEncryption()
        {
            var anakin = new RSAEncryption();
            var palpatine = new RSAEncryption();

            // The secret message the chancellor wishes to send to Anakin.
            string palpatineMessage = "Have you ever heard the tragedy of Darth Plagueis the Wise?";

            // Compute the hash of the plaintext message.
            string palpatineHash = SHAHashing.Hash(palpatineMessage);

            // Encrypt the data with Anakin's public key.
            byte[] palpatineData = anakin.Encrypt(anakin.PublicKey, palpatineMessage);

            // Let's pretend Palpatine sent it off, and Anakin is now receiving the secret message.

            // Receive and decrypt the chancellor's message with Anakin's private key.
            string palpatineDecrypted = anakin.Decrypt(anakin.PrivateKey, palpatineData);

            // Perform some asserts to verify that the data is the same, and the hashes are the same.
            Assert.AreEqual(palpatineMessage, palpatineDecrypted);
            Assert.AreEqual(palpatineHash, SHAHashing.Hash(palpatineDecrypted));

            // Cool! Now, we must send a response, using Palpatine's public key.

            // Our response to the chancellor.
            string anakinResponse = "No.";

            // Compute a hash of the data.
            string anakinHash = SHAHashing.Hash(anakinResponse);

            // Encrypt the data using Palpatine's public key.
            byte[] anakinData = palpatine.Encrypt(palpatine.PublicKey, anakinResponse);
            
            // Send it off to the capitol.

            // Receive and decrypt Anakin's message with Palpatine's private key.
            string anakinDecrypted = palpatine.Decrypt(palpatine.PrivateKey, anakinData);

            // Perform some asserts to verify that the data is the same, and the hashes are the same.
            Assert.AreEqual(anakinResponse, anakinDecrypted);
            Assert.AreEqual(anakinHash, SHAHashing.Hash(anakinDecrypted));
        }
    }
}
