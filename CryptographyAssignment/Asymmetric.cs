using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyAssignment
{
    /// <summary>
    /// Class for encrypting data asymmetrically.
    /// </summary>
    public class Asymmetric
    {
        /// <summary>
        /// Encrypts the data that is passed into as a parameter.
        /// </summary> 
        /// <param name="value"> The information that is needed to be encrypted.</param>
        /// <returns> Encrypted data passed in from the parameter.</returns>
        public static string Encrypt(string value)
        {
            // Keys.
            string privateKey;
            string publicKey;

            // Values.
            byte[] encryptedValue;
            string decryptedValue;

            // Generates the public and private key.
            using (var csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            // Encrypts the parameter with the Primary Key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(value), true);
            }

            // Decrypts the parameter with the Private Key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }

            return decryptedValue;
        }
    }
}
