using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Week13CryptographyExercise
{
    /// <summary>
    /// Asymetrically encrypts data.
    /// </summary>
    public class AsymetricEncryption
    {
        /// <summary>
        /// Encrypts a string using a public and private key.
        /// </summary>
        /// <param name="plainText">String data to be encrypted.</param>
        /// <returns>Encrypted data as type byte.</returns>
        public static string EncryptData(string plainText)
        {
            byte[] encryptedData;
            string decryptedData;
            string privateKey;
            string publicKey;

            //Make public and private keys.
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                publicKey = rsaCryptoServiceProvider.ToXmlString(false);
                privateKey = rsaCryptoServiceProvider.ToXmlString(true);
            }

            //Encrypt plainText asymetrically with the public key.
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(publicKey);
                encryptedData = rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(plainText), true);
            }

            //Decrypt byte[] asmetrically with private key.
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKey);
                decryptedData = Encoding.UTF8.GetString(rsaCryptoServiceProvider.Decrypt(encryptedData, true));
            }

            return decryptedData;
        }
    }
}
