using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    /// <summary>
    /// Provides a method to encrypt and decrypt using symetric encryption, and provides a method to encrypt using hashing.
    /// </summary>
    public class SecretsToBeKept
    {
        /// <summary>
        /// Encrypts data sent to it using the hashing methodology.
        /// </summary>
        /// <param name="password">This is the text which is to be hashed.</param>
        /// <returns>The hashed value conveted to string format.</returns>
        public static string HashItUp(string password)
        {
            // Hash and "save" the password.
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return Encoding.UTF8.GetString(hash);
        }

        /// <summary>
        /// Encrypts data sent to it using symetric encryption.
        /// </summary>
        /// <param name="plainText">The value which is to be encrypted.</param>
        /// <returns>The decrypted value in string which is a string.</returns>
        public static string SymmetricEncryptionItUp(string plainText)
        {
            byte[] encryptedValue;
            string decryptedValue;

            byte[] key;
            byte[] iv;

            // Encrypt the value.
            using (var encryptionProvider = new AesCryptoServiceProvider())
            {
                // Generate the key.
                key = encryptionProvider.Key;

                // Generate the IV.
                iv = encryptionProvider.IV;

                ICryptoTransform encryptor = encryptionProvider.CreateEncryptor(key, iv);

                // Create the streams for encryption.
                using (var stream = new MemoryStream())
                using (var crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(crypt))
                    {
                        writer.Write(plainText);
                    }

                    encryptedValue = stream.ToArray();
                }
            }

            // Decrypt the value.
            using (var encryptionProvider = new AesCryptoServiceProvider())
            {
                ICryptoTransform decryptor = encryptionProvider.CreateDecryptor(key, iv);

                // Create the streams for decryption.
                using (var stream = new MemoryStream(encryptedValue))
                using (var crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(crypt))
                {
                    decryptedValue = reader.ReadToEnd();
                }

                return decryptedValue;
            }
        }
    }
}
