using System.IO;
using System.Security.Cryptography;

namespace Week13Security
{
    /// <summary>
    /// A class to demonstrate hashing files.
    /// </summary>
    public static class Hashing
    {
        /// <summary>
        /// Hashes the supplied file with the SHA256 algorithm.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <returns>A byte array representation of the hash.</returns>
        public static byte[] Hash(Stream file)
        {
            var sha = SHA256.Create();
            return sha.ComputeHash(file);
        }

        /// <summary>
        /// Hashes the supplied file with the SHA256 algorithm.
        /// </summary>
        /// <param name="filePath">The path to the file to hash.</param>
        /// <returns>A byte array representation of the hash.</returns>
        public static byte[] Hash(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] hashed = null;
                using (var file = File.OpenRead(filePath))
                {
                    hashed = Hash(file);
                }
                return hashed;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
