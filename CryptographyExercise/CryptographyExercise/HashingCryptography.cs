using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyExercise
{
    /// <summary>
    /// Is used to hash nuclear code data.
    /// </summary>
    public class HashingCryptography
    {
        /// <summary>
        /// Hashes some secret words so that they cannot be read by those we do not trust.
        /// </summary>
        /// <param name="secretWords">The nuclear codes to be hashed.</param>
        /// <returns>The hashed nuclear code value.</returns>
        public static byte[] HashThat(string secretWords)
        {
            string nuclearCodes = secretWords;
            byte[] data = Encoding.UTF8.GetBytes(nuclearCodes);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }
    }
}
