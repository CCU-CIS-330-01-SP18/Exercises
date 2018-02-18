using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week6;
using System.Text.RegularExpressions;

namespace Week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void PhoneValidatorReturnsFalseForInvalidPhone()
        {
            var phoneNumber = PhoneValidator.ValidatePhoneNumber("97023147199");

            Assert.IsFalse(phoneNumber);
        }

        [TestMethod]
        public void PhoneValidatorReturnsFalseOnPhoneNumberBeginningWithSpace()
        {
            var phoneNumber = PhoneValidator.ValidatePhoneNumber(" 970-231-4719");
            Assert.IsFalse(phoneNumber);
        }

        [TestMethod]
        public void PhoneValidatorReturnsFalseOnPhoneNumberWithVaryingFormats()
        {
            var numberWithSpaces = PhoneValidator.ValidatePhoneNumber("97 231 4719");
            Assert.IsFalse(numberWithSpaces);

            var numberWithDashes = PhoneValidator.ValidatePhoneNumber("970--231-4719");
            Assert.IsFalse(numberWithDashes);
        }

        [TestMethod]
        public void PhoneValidatorReturnsTrueForValidPhoneNumber()
        {
            var areaCode = PhoneValidator.ValidatePhoneNumber("970-231-4719");

            Assert.AreEqual(true, areaCode);
        }

        [TestMethod]
        public void PhoneValidatorReturnsTrueForPhoneNumbersWithoutAreaCodes()
        {
            var areaCode = PhoneValidator.ValidatePhoneNumber("231-4719");

            Assert.AreEqual(true, areaCode);
        }

        [TestMethod]
        public void PhoneValidatorReturnsTrueForDifferentVariations()
        {
            var includesPeriods = PhoneValidator.ValidatePhoneNumber("970.231.4719");

            Assert.AreEqual(true, includesPeriods);

            var includesSpaces = PhoneValidator.ValidatePhoneNumber("970 231 4719");
            Assert.AreEqual(true, includesSpaces);

            var includesDashes = PhoneValidator.ValidatePhoneNumber("970-231-4719");
            Assert.AreEqual(true, includesDashes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
            PhoneValidator.ValidatePhoneNumber(null);
            /*ArgumentNullException thrownException = null;
            try
            {
                PhoneValidator.ValidatePhoneNumber(null);
            }
            catch (ArgumentNullException ex)
            {
                thrownException = ex;
            }

            Assert.IsNotNull(thrownException);*/
        }
    }
}
