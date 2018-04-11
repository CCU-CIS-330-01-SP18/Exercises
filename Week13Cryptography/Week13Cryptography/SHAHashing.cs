using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13Cryptography
{
    class SHAHashing
    {
        /*
         * // Hash and "save" the password
            string myPassword = "P@ssw0rd!";
            byte[] data = Encoding.UTF8.GetBytes(myPassword);
            byte[] hash = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hash));

            // Confirm the user entered the same password.
            byte[] data2 = Encoding.UTF8.GetBytes(myPassword);
            byte[] hash2 = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hash2));

            Console.WriteLine(hash.SequenceEqual(hash2));
         */
         public string Hash(string text)
        {
            return Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(text)));
        }
    }
}
