using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week13Cryptography
{
    public class RSAEncryption
    {
        public string PublicKey { get; private set; }

        public string PrivateKey { get; private set; }

        public RSAEncryption()
        {
            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider())
            {
                PublicKey = crypto.ToXmlString(false);
                PrivateKey = crypto.ToXmlString(true);
            }
        }

        public string Encrypt(string key, string plainText)
        {
            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(key);

                return Encoding.UTF8.GetString(crypto.Encrypt(Encoding.UTF8.GetBytes(plainText), true));
            }
        }

        public string Decrypt(string key, string encodedText)
        {
            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(key);

                return Encoding.UTF8.GetString(crypto.Decrypt(Encoding.UTF8.GetBytes(encodedText), true));
            }
        }
    }
}