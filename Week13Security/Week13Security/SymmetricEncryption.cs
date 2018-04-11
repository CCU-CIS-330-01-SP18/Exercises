using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Week13Security
{
    /// <summary>
    /// A class to demonstrate symmetric encryption and decryption.
    /// </summary>
    public static class SymmetricEncryption
    {
        /// <summary>
        /// Encrypts the given string.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <returns>A dictionary containing the encrypted file as "encrypted", the key used to encrypt it as "key", and the initialization vector as "iv".</returns>
        public static Dictionary<string, byte[]> Encrypt(string stringToEncrypt)
        {
            var keyFile = new Dictionary<string, byte[]>();
            byte[] encryptedValue;
            byte[] key;
            byte[] initializationVector;

            using (var cryptoServiceProvider = new AesCryptoServiceProvider())
            {
                cryptoServiceProvider.GenerateKey();
                key = cryptoServiceProvider.Key;

                cryptoServiceProvider.GenerateIV();
                initializationVector = cryptoServiceProvider.IV;

                var encryptor = cryptoServiceProvider.CreateEncryptor(key, initializationVector);

                using (var stream = new MemoryStream())
                using (var crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(crypt))
                    {
                        writer.Write(stringToEncrypt);
                    }

                    encryptedValue = stream.ToArray();
                }
            }

            keyFile.Add("encrypted", encryptedValue);
            keyFile.Add("key", key);
            keyFile.Add("iv", initializationVector);

            return keyFile;
        }

        /// <summary>
        /// Decrypts the given bytestream, using the key supplied.
        /// </summary>
        /// <param name="encrypted">The encrypted file, as a byte array.</param>
        /// <param name="key">The symmetric encryption key to decrypt the file with.</param>
        /// <param name="iv">The initialization vector to decrypt the file with.</param>
        /// <returns>The decrypted file, as a byte array.</returns>
        public static string Decrypt(byte[] encrypted, byte[] key, byte[] iv)
        {
            string decrypted;

            using (var cryptoServiceProvider = new AesCryptoServiceProvider())
            {
                var decryptor = cryptoServiceProvider.CreateDecryptor(key, iv);
                
                using (var stream = new MemoryStream(encrypted))
                using (var crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(crypt))
                {
                    decrypted = reader.ReadToEnd();
                }
            }

            return decrypted;
        }
    }
}
