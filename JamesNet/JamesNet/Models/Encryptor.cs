using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// An encryption class, allowing for encryption and decryption of various objects.
    /// </summary>
    public class Encryptor
    {
        /// <summary>
        /// Encrypt the message with the key, and return it.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="key">The key to encrypt the message with.</param>
        /// <returns>The encrypted message.</returns>
        public static byte[] Encrypt(string message, byte[] key)
        {
            byte[] encryptedMessage;
            byte[] keyHash = SHA256.Create().ComputeHash(key);

            using (var crypto = new AesCryptoServiceProvider())
            {
                crypto.Key = keyHash;
                // I know this isn't how you use IVs. Will fix later if I have time.
                crypto.IV = new byte[] { 1, 0, 1 };
                var encrypt = crypto.CreateEncryptor();

                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(message);
                    encryptedMessage = memoryStream.ToArray();
                }
            }

            return encryptedMessage;
        }

        /// <summary>
        /// Encrypt the message with the key, and return it.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="key">The key to encrypt the message with.</param>
        /// <returns>The encrypted message.</returns>
        public static byte[] Encrypt(string message, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            return Encrypt(message, keyBytes);
        }

        /// <summary>
        /// Attempt to decrypt the message with the key, and return it.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="key">The key to attempt decryption with.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(byte[] encryptedMessage, byte[] key)
        {
            string decryptedMessage;
            byte[] keyHash = SHA256.Create().ComputeHash(key);

            using (var crypto = new AesCryptoServiceProvider())
            {
                crypto.Key = keyHash;
                // I know this isn't how you use IVs. Will fix later if I have time.
                // TODO: Fix this! Is broken!
                crypto.IV = new byte[] { 1, 0, 1 };
                var decryptor = crypto.CreateDecryptor();

                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cryptoStream))
                {
                    decryptedMessage = reader.ReadToEnd();
                }
            }

            return decryptedMessage;
        }

        /// <summary>
        /// Attempt to decrypt the message with the key, and return it.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="key">The key to attempt decryption with.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(byte[] encryptedMessage, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            return Decrypt(encryptedMessage, keyBytes);
        }

        /// <summary>
        /// Attempt to decrypt the message with the key, and return it.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="key">The key to attempt decryption with.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string encryptedMessage, byte[] key)
        {
            byte[] encryptedMessageBytes = Encoding.UTF8.GetBytes(encryptedMessage);
            return Decrypt(encryptedMessageBytes, key);
        }

        /// <summary>
        /// Attempt to decrypt the message with the key, and return it.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="key">The key to attempt decryption with.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string encryptedMessage, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] encryptedMessageBytes = Encoding.UTF8.GetBytes(encryptedMessage);
            return Decrypt(encryptedMessageBytes, keyBytes);
        }
    }
}