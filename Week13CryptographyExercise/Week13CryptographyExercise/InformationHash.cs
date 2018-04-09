using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13CryptographyExercise
{
    /// <summary>
    /// Implements Hashing of data.
    /// </summary>
    public class InformationHash
    {
        /// <summary>
        /// Hashes data.
        /// </summary>
        /// <param name="valuedInfo">Data that is to be hashed in the form of a string.</param>
        /// <returns>The hashed value in form of a byte array.</returns>
        public static byte[] Hash(string valuedInfo)
        {
            string password = valuedInfo;
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }
    }
}
