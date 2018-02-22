using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week6;

namespace Week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void PhoneValidatorCheck()
        {
            PhoneValidator.ValidatePhoneNumber("abc");
        }

        [TestMethod]
        public void CanValidatePhoneNumbers()
        {
            // Asserts that valid phone number formats pass.
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(281)388-0388"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("3087774825"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(979) 778-0978"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(281)934-2447"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("281-342-2452"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(303)9569525"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("303.956.9525"));

            // Asserts that invalid phone number formats fail.
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("303-123-1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("030-342-2452"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("130-956-9525"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("334-714-149"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("800-342-2452"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("1-800-342-2452"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("303-CallNow"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Phone number can't be null or empty.")]
        public void DoesThrowExceptionIfNullOrEmpty()
        {
            // I am testing the Expected Exception.
            PhoneValidator.ValidatePhoneNumber("");
            PhoneValidator.ValidatePhoneNumber(null);

            // Testing if there is no Expected Exception.
            ArgumentNullException thrownException = null;
            try
            {
                PhoneValidator.ValidatePhoneNumber(null);
            }
            catch (ArgumentNullException ex)
            {
                thrownException = ex;
            }
            Assert.IsNotNull(thrownException);
        }


    }
}
