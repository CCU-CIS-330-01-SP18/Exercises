using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13CryptographyExercise
{
    /// <summary>
    /// Encrypts data Asymmetrically.
    /// </summary>
    public class AsymmetricEncryption
    {
        /// <summary>
        /// Encrypts data.
        /// </summary>
        /// <param name="value">Data that is wanting to be encrypted and decrypted.</param>
        /// <returns>The decrypted and original value of data after it was encrypted.</returns>
        public static string Encrypt(string value)
        {
            string plainOldText = value;
            string privateKey;
            string publicKey;
            byte[] encryptedValue;
            string decryptedValue;

            // Generates a public and private key.
            using (var csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            // Encrypts passed in string parameter using the public key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(plainOldText), true);
            }

            // Decrypts value using the private key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }

            return decryptedValue;
        }
    }
}
