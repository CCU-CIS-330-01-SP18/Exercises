using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;

namespace Week13CryptographyExerciseTests
{
    [TestClass]
    public class AsymetricEncryptionTests
    {
        [TestMethod]
        public void EncryptsDataAccurately()
        {
            string plaintext = "I will meet you in Central Park, south side, at 4:00pm next Saturday";

            string decryptedText = AsymetricEncryption.EncryptData(plaintext);

            Assert.AreEqual(plaintext, decryptedText);
        }
    }
}
