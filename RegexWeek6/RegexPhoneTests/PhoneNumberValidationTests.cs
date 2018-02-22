using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexPhone;

namespace RegexPhoneTests
{
    [TestClass]
    public class PhoneNumberValidationTests
    {
        [TestMethod]
        public void Can_Create_Phone_Number()
        {
            var number = PhoneNumberValidation.ValidatePhoneNumber("abc");
            Assert.IsNotNull(number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_For_Null_Number()
        {
            // This test will pass because we are using an ExpectedException.
            var number = PhoneNumberValidation.ValidatePhoneNumber(null);
        }

        [TestMethod]
        public void Invalid_Phone_Numbers()
        {
            // Last group is supposed to have 4 digits.
            var number = PhoneNumberValidation.ValidatePhoneNumber("720-666-666");
            Assert.IsFalse(number);

            // Exactly 3 digits are permitted for the first group, 3 for the second, and 4 for the third.
            number = PhoneNumberValidation.ValidatePhoneNumber("72-666-6666");
            Assert.IsFalse(number);

            // Only 3 groups are permitted for a phone number.
            number = PhoneNumberValidation.ValidatePhoneNumber("720-666-6666-666");
            Assert.IsFalse(number);

            // Spaces can substitute dashes, but cannot precede or follow the number.
            number = PhoneNumberValidation.ValidatePhoneNumber(" 720 666 6666");
            Assert.IsFalse(number);

            // If the number does not contain an area code, then it should not have parenthesis.
            number = PhoneNumberValidation.ValidatePhoneNumber("(666) 6666");
            Assert.IsFalse(number);

        }

        [TestMethod]
        public void Valid_Phone_Numbers()
        {
            // Numbers with dashes are accepted.
            var number = PhoneNumberValidation.ValidatePhoneNumber("720-666-6666");
            Assert.IsTrue(number);

            // Numbers without dashes are accepted.
            number = PhoneNumberValidation.ValidatePhoneNumber("7206666666");
            Assert.IsTrue(number);

            // Numbers with spaces are accepted
            number = PhoneNumberValidation.ValidatePhoneNumber("720 666 6666");
            Assert.IsTrue(number);

            // Numbers without an area code are accepted.
            number = PhoneNumberValidation.ValidatePhoneNumber("666-6666");
            Assert.IsTrue(number);

            // Numbers with parenthesis around the area code are accepted.
            number = PhoneNumberValidation.ValidatePhoneNumber("(720)-666-6666");
            Assert.IsTrue(number);
        }
    }
}
