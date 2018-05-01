using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Provides a method to encrypt using hashing.
    /// </summary>
    public class Encryption
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

            return Encoding.UTF8.GetString(hash);
        }
    }
}
