using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpressionAndExceptionHandling.Tests
{
    [TestClass]
    public class PhoneNumberValidationTest
    {
        /// <summary>
        /// Tests various American phone number formats to ensure that the
        /// PhoneNumberValidation Class's regular expression is performing
        /// correctly.
        /// </summary>
        [TestMethod]
        public void ValidatesVariousPhoneNumberFormats()
        {
            // Valid Phone Number Formats
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1 785 669 7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("17856697029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("785 669 7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1-785-669-7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1 785-669-7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1 785.669.7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1.785.669.7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("(785) 669 7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("1 (785) 669 7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("669-7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("669.7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("669 7029"));
            Assert.IsTrue(PhoneNumberValidation.ValidatePhoneNumber("6697029"));

            // Invalid Phone Number Formats
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("cheese"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("785 669 70299"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("669     7029"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("785 6659 7029"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("76 669 7029"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("7029"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("7856697029X"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("78566970 29"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("785(669)7029"));
            Assert.IsFalse(PhoneNumberValidation.ValidatePhoneNumber("785 1 669 7029"));
        }
    }
}
