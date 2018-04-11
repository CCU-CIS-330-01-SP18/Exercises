using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Week13Security
{
    /// <summary>
    /// A class to demonstrate symmetric encryption and decryption.
    /// </summary>
    public static class SymmetricEncryption
    {
        /// <summary>
        /// Encrypts the given file and returns both the encrypted file, as well as the key used to encrypt it.
        /// </summary>
        /// <param name="filePath">The path to the file to encrypt.</param>
        /// <returns>A dictionary with one key-pair value: the encryption key, as well as the encrypted file in byte array form.</returns>
        public static Dictionary<string, byte[]> Encrypt(string filePath)
        {
            var keyFile = new Dictionary<string, byte[]>();
            byte[] fileContents = File.ReadAllBytes(filePath);

            byte[] encryptedValue;

            byte[] key;
            byte[] iv;
            
            using (var cryptoServiceProvider = new AesCryptoServiceProvider())
            {
                //provider.GenerateKey();
                key = cryptoServiceProvider.Key;
                Console.WriteLine("Key: {0}", Encoding.UTF8.GetString(key));

                //provider.GenerateIV();
                iv = cryptoServiceProvider.IV;
                Console.WriteLine("IV: {0}", Encoding.UTF8.GetString(iv));

                ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor(key, iv);

                // Create the streams used for encryption.
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.Write(fileContents);
                    }

                    encryptedValue = stream.ToArray();
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrypts the given bytestream, using the key supplied.
        /// </summary>
        /// <param name="encrypted">The encrypted file, as a byte array.</param>
        /// <param name="key">The symmetric encryption key to decrypt the file with.</param>
        /// <returns>The decrypted file.</returns>
        public static Stream Decrypt(byte[] encrypted, string key)
        {
            throw new NotImplementedException();
        }
    }
}
