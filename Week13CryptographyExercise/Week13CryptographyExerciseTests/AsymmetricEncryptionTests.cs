using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CryptographyExercise;

namespace Week13CryptographyExerciseTests
{
    [TestClass]
    public class AsymmetricEncryptionTests
    {
        [TestMethod]
        public void CanDecryptEncryptedValue()
        {
            string text = "Some boring old text... yeah";

            string decryptedText = AsymmetricEncryption.Encrypt(text);

            Assert.AreEqual(text, decryptedText);
        }
    }
}
