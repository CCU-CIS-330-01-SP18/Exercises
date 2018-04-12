using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Week13CryptographyExercise
{
    /// <summary>
    /// Securely hashes a string of data.
    /// </summary>
    public class Hashing
    {
        /// <summary>
        /// Generates a hash of an inputted string.
        /// </summary>s
        /// <param name="plainText">Data to be hashed.</param>
        /// <returns>The resulting hashed data.s</returns>
        public static byte[] HashData(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] hashData = SHA256.Create().ComputeHash(data);
            
            return hashData;
        }
    }
}
