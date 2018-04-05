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
        /// <param name="file">The file to encrypt.</param>
        /// <returns>A dictionary with one key-pair </returns>
        public static Dictionary<string, byte[]> Encrypt(Stream file)
        {
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
