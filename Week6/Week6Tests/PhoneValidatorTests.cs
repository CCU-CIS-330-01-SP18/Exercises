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
            var withLetters = PhoneValidator.ValidatePhoneNumber("abc");
            Assert.IsFalse(withLetters);

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
            var numberWithSpaces = PhoneValidator.ValidatePhoneNumber("970  231 4719");
            Assert.IsFalse(numberWithSpaces);

            var numberWithDashes = PhoneValidator.ValidatePhoneNumber("970--231-4719");
            Assert.IsFalse(numberWithDashes);

            var numberWithPeriods = PhoneValidator.ValidatePhoneNumber("970..231.4719");
            Assert.IsFalse(numberWithPeriods);
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

            var withSpaces = PhoneValidator.ValidatePhoneNumber("231 4719");
            Assert.IsTrue(withSpaces);

            var withPeriods = PhoneValidator.ValidatePhoneNumber("231.4719");
            Assert.IsTrue(withPeriods);

            var noSpaces = PhoneValidator.ValidatePhoneNumber("2314179");
            Assert.IsTrue(noSpaces);
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

            var mixedFormat = PhoneValidator.ValidatePhoneNumber("970.231-4719");
            Assert.IsTrue(mixedFormat);

            var noSpaces = PhoneValidator.ValidatePhoneNumber("9702314719");
            Assert.IsTrue(noSpaces);
        }

        [TestMethod]
        public void PhoneValidatorReturnsTrueForNumbersStartingWithParentheses()
        {
            var includesParentheses = PhoneValidator.ValidatePhoneNumber("(970)-231-4719");
            Assert.IsTrue(includesParentheses);

            var withSpaces = PhoneValidator.ValidatePhoneNumber("(970) 231 4719");
            Assert.IsTrue(withSpaces);

            var withPeriods = PhoneValidator.ValidatePhoneNumber("(970).231.4719");
            Assert.IsTrue(withPeriods);

            var mixedFormat = PhoneValidator.ValidatePhoneNumber("(970).231 4719");
            Assert.IsTrue(mixedFormat);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
            PhoneValidator.ValidatePhoneNumber(null);
        }
    }
}
