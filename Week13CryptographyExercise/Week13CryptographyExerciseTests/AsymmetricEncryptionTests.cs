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

            // Checks to see if the decrypted value is equal to the orginal value of the text.
            Assert.AreEqual(text, decryptedText);
        }
    }
}
