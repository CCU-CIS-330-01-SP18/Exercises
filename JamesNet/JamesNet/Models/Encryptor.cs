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
        private static byte[] iv;

        /// <summary>
        /// Generate the IV that will be used until this method is called again.
        /// </summary>
        /// <remarks>Yes, I know this isn't how IVs are supposed to work. I'll fix this later if I have time.</remarks>
        public static void GenerateIV()
        {
            using (var crypto = new AesCryptoServiceProvider())
            {
                crypto.GenerateIV();
                iv = crypto.IV;
            }
        }

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
                crypto.IV = iv;
                crypto.Padding = PaddingMode.ANSIX923;
                var encrypt = crypto.CreateEncryptor();

                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(message);
                    }
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
            byte[] encryptedMessagePadded;
            if (encryptedMessage.Length % 16 > 0)
            {
                string encryptedString = Encoding.UTF8.GetString(encryptedMessage);
                //encryptedString.PadRight(encryptedString.Length + 16 - encryptedString.Length % 16, '=');
                encryptedMessagePadded = Encoding.UTF8.GetBytes(encryptedString);
            }
            else
            {
                encryptedMessagePadded = encryptedMessage;
            }
            string decryptedMessage;
            byte[] keyHash = SHA256.Create().ComputeHash(key);

            using (var crypto = new AesCryptoServiceProvider())
            {
                crypto.Key = keyHash;
                // I know this isn't how you use IVs. Will fix later if I have time.
                crypto.IV = iv;
                crypto.Padding = PaddingMode.ANSIX923;
                var decryptor = crypto.CreateDecryptor();

                using (var memoryStream = new MemoryStream(encryptedMessage))
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