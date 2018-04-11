using System.IO;
using System.Security.Cryptography;

namespace Week13Cryptography
{
    /// <summary>
    /// Methods for symmetric encryption.
    /// </summary>
    public class SymmetricEncryption
    {
        /// <summary>
        /// Encrypt the value using symmetric encryption.
        /// </summary>
        /// <param name="dataToEncrypt">The string of data you want to encrypt.</param>
        /// <param name="encryptor">An encryptor made with a key and IV.</param>
        /// <returns>The encrypted data as a byte array.</returns>
        public static byte[] Encrypt(string dataToEncrypt, ICryptoTransform encryptor)
        {
            // Create the streams used for encryption.
            using (var stream = new MemoryStream())
            using (var crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                using (var writer = new StreamWriter(crypt))
                {
                    writer.Write(dataToEncrypt);
                }

                return stream.ToArray();
            }
        }

        /// <summary>
        /// Decrypt an encrypted byte array using symmetric encryption.
        /// </summary>
        /// <param name="dataToDecrypt">The data to decrypt.</param>
        /// <param name="decryptor">A decryptor made with the same key and IV as the encryptor.</param>
        /// <returns>The decrypted data as a string.</returns>
        public static string Decrypt(byte[] dataToDecrypt, ICryptoTransform decryptor)
        {
            // Create the streams for decryption.
            using (var stream = new MemoryStream(dataToDecrypt))
            using (var crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            using (var reader = new StreamReader(crypt))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
