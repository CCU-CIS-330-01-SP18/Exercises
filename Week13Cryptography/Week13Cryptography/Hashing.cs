using System.Security.Cryptography;
using System.Text;

namespace Week13Cryptography
{
    /// <summary>
    /// Methods for hashing strings.
    /// </summary>
    public class Hashing
    {
        /// <summary>
        /// Creates the hashed version of the passed string.
        /// </summary>
        /// <param name="dataToBeHashed">The string to be hashed.</param>
        /// <returns>The SHA256 hash of the passed string.</returns>
        public static byte[] GetHashOf(string dataToBeHashed)
        {
            // Turn the passed string into a hashable byte array.
            byte[] hashableData = Encoding.UTF8.GetBytes(dataToBeHashed);

            return SHA256.Create().ComputeHash(hashableData);
        }
    }
}
