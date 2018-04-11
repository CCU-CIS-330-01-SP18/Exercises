using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13Cryptography
{
    /// <summary>
    /// A static class for computing the SHA256 hash of a string.
    /// </summary>
    public static class SHAHashing
    {
        /// <summary>
        /// Computes a SHA256 hash.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <returns>A SHA-256 hash of the string.</returns>
         public static string Hash(string text)
        {
            var crypto = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return Encoding.UTF8.GetString(crypto.ComputeHash(bytes));
        }
    }
}
