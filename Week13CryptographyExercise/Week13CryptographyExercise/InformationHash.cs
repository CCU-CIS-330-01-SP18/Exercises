using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13CryptographyExercise
{
    public class InformationHash
    {
        public static byte[] Hash(string valuedInfo)
        {
            string password = valuedInfo;
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            //string hashedValue = Encoding.UTF8.GetString(hash);

            return hash;
        }
    }
}
