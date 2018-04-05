using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;

namespace Week13CryptographyExerciseTests
{
    [TestClass]
    public class InformationHashTests
    {
        [TestMethod]
        public void CorrectlyHashesValues()
        {
            string value = "abcd1234";

            byte[] hashedValue = InformationHash.Hash(value);

            byte[] data = Encoding.UTF8.GetBytes(value);
            byte[] hash = SHA256.Create().ComputeHash(data);



            Assert.IsTrue(hashedValue.SequenceEqual(hash));

        }
    }
}
