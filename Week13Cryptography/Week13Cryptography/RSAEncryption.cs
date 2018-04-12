using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13Cryptography
{
    /// <summary>
    /// A class to perform simple asymmetric encryption through RSA.
    /// </summary>
    public class RSAEncryption
    {
        /// <summary>
        /// This instance's public key, created at initialization.
        /// </summary>
        public string PublicKey { get; private set; }

        /// <summary>
        /// This instance's private key, created at initialization.
        /// </summary>
        public string PrivateKey { get; private set; }

        /// <summary>
        /// Constructs a new instance, and prepares a public and private key pair.
        /// </summary>
        public RSAEncryption()
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                PublicKey = crypto.ToXmlString(false);
                PrivateKey = crypto.ToXmlString(true);
            }
        }

        /// <summary>
        /// Encrypts a string according to a key.
        /// </summary>
        /// <param name="key">The key to use for encryption.</param>
        /// <param name="plainText">The secret text to encrypt.</param>
        /// <returns>A byte array of encrypted information.</returns>
        public byte[] Encrypt(string key, string plainText)
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(key);

                return crypto.Encrypt(Encoding.UTF8.GetBytes(plainText), true);
            }
        }

        /// <summary>
        /// Decrypts a byte array according to a key.
        /// </summary>
        /// <param name="key">The key to use for decryption.</param>
        /// <param name="encodedText">The byte array to decrypt.</param>
        /// <returns>A string of decrypted information.</returns>
        public string Decrypt(string key, byte[] encodedText)
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(key);

                return Encoding.UTF8.GetString(crypto.Decrypt(encodedText, true));
            }
        }
    }
}