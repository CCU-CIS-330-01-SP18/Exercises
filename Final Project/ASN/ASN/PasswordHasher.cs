using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// Hashes a string (presumably a password) using the SHA256 algorithm.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes a string using SHA256.
        /// </summary>
        /// <param name="password">The string to hash.</param>
        /// <returns>A Base64 string representation of the hash.</returns>
        public static string HashPassword(string password)
        {
            var hasher = SHA256.Create();
            byte[] hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}
