using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13Security
{
    /// <summary>
    /// A class to demonstrate hashing files.
    /// </summary>
    public static class Hashing
    {
        /// <summary>
        /// Hashes the supplied file with the SHA256 algorithm, and returns the result.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <returns>A byte array representation of the hash.</returns>
        public static byte[] Hash(Stream file)
        {
            var sha = SHA256.Create();
            return sha.ComputeHash(file);
        }
    }
}
