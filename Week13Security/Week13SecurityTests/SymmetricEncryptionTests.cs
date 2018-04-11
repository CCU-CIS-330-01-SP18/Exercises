using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Security;

namespace Week13SecurityTests
{
    [TestClass]
    public class SymmetricEncryptionTests
    {
        [TestMethod]
        public void CanEncryptDecrypt()
        {
            string stringToEncrypt = "Lorem Ipsum";

            var encrypted = SymmetricEncryption.Encrypt(stringToEncrypt);

            Assert.IsNotNull(encrypted, "The encryption method returned nothing.");
            Assert.IsNotNull(encrypted["iv"], "A null initialization vector was returned.");
            Assert.IsNotNull(encrypted["encrypted"], "A null encrypted file was returned.");
            Assert.IsNotNull(encrypted["key"], "A null encryption key was returned.");
            Assert.IsTrue(encrypted.Count == 3, "An invalid dictionary was returned.");
            Assert.AreNotEqual(stringToEncrypt, encrypted["encrypted"], "The encryption method did not actually encrypt the string.");

            string decrypted = SymmetricEncryption.Decrypt(encrypted["encrypted"], encrypted["key"], encrypted["iv"]);

            Assert.AreEqual(stringToEncrypt, decrypted, "Decryption yielded a different result.");
        }
    }
}
