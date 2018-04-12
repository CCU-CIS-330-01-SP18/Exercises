using System;
using System.Security.Cryptography;
using System.Text;


namespace Week13CryptographyExercise
{
    /// <summary>
    /// A class that provides a method to encrypt text asymmetrically.
    /// </summary>
    public static class AsymmetricEncryption
    {
        /// <summary>
        /// Encrypts text asymmetrically.
        /// </summary>
        /// <param name="plainText">Text passed to be encrypted.</param>
        /// <returns>An encrypted string.</returns>
        public static string Encrypt(string plainText)
        {
            string decryptedValue;
            string privateKey;
            string publicKey;
            byte[] encryptedValue;

            // Gets public and private keys.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            // Uses the public key to encrypt the value.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(plainText), true);
            }
            
            // Uses the private key to decrypt the value.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }
            
            return decryptedValue;
        }
    }
}
