using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week6;
namespace week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void TenDigitPhoneValidatorValidatesNoSpaces()
        {
            bool result = false;
            string phoneNumber = "8066837766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TenDigitPhoneValidatorValidatesHyphens()
        {
            bool result = false;
            string phoneNumber = "806-683-7766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TenDigitPhoneValidatorValidatesPeriods()
        {
            bool result = false;
            string phoneNumber = "806.683.7766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TenDigitPhoneValidatorValidatesNoSpacesParentheses()
        {
            bool result = false;
            string phoneNumber = "(806)6837766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TenDigitPhoneValidatorValidatesHyphensParentheses()
        {
            bool result = false;
            string phoneNumber = "(806)-683-7766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SevenDigitPhoneValidatorValidatesNoSpaces()
        {
            bool result = false;
            string phoneNumber = "6837766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SevenDigitPhoneValidatorValidatesHyphen()
        {
            bool result = false;
            string phoneNumber = "683-7766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SevenDigitPhoneValidatorValidatesPeriod()
        {
            bool result = false;
            string phoneNumber = "683.7766";
            result = PhoneValidator.ValidatePhoneNumber(phoneNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
            PhoneValidator.ValidatePhoneNumber(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhoneValidatorThrowsForOutOfRangeNumber()
        {
            string phoneNumber = "(865)-9898-8989";
            PhoneValidator.ValidatePhoneNumber(phoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PhoneValidatorThrowsForFormatException()
        {
            string phoneNumber = "asdf1234";
            PhoneValidator.ValidatePhoneNumber(phoneNumber);
        }

    }
}
