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
            Console.WriteLine(Encoding.UTF8.GetString(hash));

            // Confirm the user entered the same password.
            byte[] data2 = Encoding.UTF8.GetBytes(password);
            byte[] hash2 = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hash2));

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
            using (AesCryptoServiceProvider encryptionProvider = new AesCryptoServiceProvider())
            {
                // Generate the key.
                key = encryptionProvider.Key;
                Console.WriteLine("Key: {0}", Encoding.UTF8.GetString(key));

                // Generate the IV.
                iv = encryptionProvider.IV;
                Console.WriteLine("IV: {0}", Encoding.UTF8.GetString(iv));

                ICryptoTransform encryptor = encryptionProvider.CreateEncryptor(key, iv);

                // Create the streams for encryption.
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.Write(plainText);
                    }

                    encryptedValue = stream.ToArray();
                }
            }

            // Decrypt the value.
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                ICryptoTransform decryptor = csp.CreateDecryptor(key, iv);

                // Create the streams for decryption.
                using (MemoryStream stream = new MemoryStream(encryptedValue))
                using (CryptoStream crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(crypt))
                {
                    decryptedValue = reader.ReadToEnd();
                }

                return decryptedValue;
            }
        }
    }
}
