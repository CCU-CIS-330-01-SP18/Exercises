using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13CryptographyExercise
{
    /// <summary>
    /// A class that provides a method to hash data.
    /// </summary>
    public static class HashingEncryption
    {
        /// <summary>
        /// Takes a string, hashes it, then returns the byte[].
        /// </summary>
        /// <param name="password">A string passed to be hashed.</param>
        /// <returns>The hashed value in a byte[] type format.</returns>
        public static byte[] Hash(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }
    }
}
