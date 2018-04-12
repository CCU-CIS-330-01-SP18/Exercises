using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyAssignment
{
    /// <summary>
    /// Class for Hashing Strings.
    /// </summary>
    public class Hashing
    {
        /// <summary>
        /// Created a hashed value from the the string passed as the parameter.
        /// </summary>
        /// <param name="hashedText">The text passed into be hashed. </param>
        /// <returns>HashedData, which is the data that is hashed. </returns>
        public static byte[] Hash(string hashedText)
        {
            byte[] data = Encoding.UTF8.GetBytes(hashedText);
            byte[] hashedData = SHA256.Create().ComputeHash(data);

            return hashedData;
        }
    }
}
