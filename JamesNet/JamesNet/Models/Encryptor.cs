using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// An encryption class, allowing for encryption and decryption of various objects.
    /// </summary>
    public class Encryptor
    {
        private static byte[] passwordHash;

        public static void SetUpPassword(string password)
        {
            byte[] passData = Encoding.UTF8.GetBytes(password);
            passwordHash = SHA256.Create().ComputeHash(passData);
        }

        /// <summary>
        /// Verifies whether the password entered is the same as the password saved.
        /// </summary>
        /// <param name="passwordAttempt">The password attempt, in plain text.</param>
        /// <returns>Whether or not the passwords match.</returns>
        public static bool VerifyPassword(string passwordAttempt)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passwordAttempt)) == passwordHash;
        }
    }
}