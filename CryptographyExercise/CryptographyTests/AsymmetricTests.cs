using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using CryptographyExercise;
using System.Text;

namespace CryptographyTests
{
    [TestClass]
    public class AsymmetricTests
    {
        [TestMethod]
        public void CanEncrpytAndDecrpyt()
        {
            string answerToTheQuestionOfLifeTheUniverseAndEverything = "42";
            string muchShorterVariable = answerToTheQuestionOfLifeTheUniverseAndEverything;

            string decryptedAnswer = AsymmetricCryptography.EncryptThat(muchShorterVariable);

            Assert.AreEqual(muchShorterVariable, decryptedAnswer);
        }
    }
}
