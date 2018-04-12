using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyExercise
{
    /// <summary>
    /// Encrpyts data assymetrically.
    /// </summary>
    public class AsymmetricCryptography
    {
        /// <summary>
        /// Encrpyts and Decryts a string using a public and primary key.
        /// </summary>
        /// <param name="info">The information to be decrypted.</param>
        /// <returns>The decrypted data.</returns>
        public static string EncryptThat(string info)
        {
            string privateKey;
            string publicKey;
            byte[] encryptedValue;
            string decryptedValue;

            // Get a public/private key pair.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            // Encrypt the value using asymmetric encryption using the public key.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(info), true);
            }

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }
            return decryptedValue;
        }
            
    }
}