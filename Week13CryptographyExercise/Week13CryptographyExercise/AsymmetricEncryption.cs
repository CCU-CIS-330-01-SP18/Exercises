using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13CryptographyExercise
{
    public class AsymmetricEncryption
    {
        public static string Encrypt(string value)
        {
            string plainOldText = value;
            string privateKey;
            string publicKey;
            byte[] encryptedValue;
            string decryptedValue;

            using (var csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(plainOldText), true);
            }

            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }

            return decryptedValue;
        }
    }
}
