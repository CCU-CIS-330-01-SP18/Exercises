using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace ValidationTests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void CanValidateProperPhoneNumbers()
        {
            // These tests should pass.
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(303) 963-3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("+1 (303) 963-3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("+1 (303) 963.3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("1 (303) 963 3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("303.963.3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("1.303.963.3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("303 963 3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("+1 303.963.3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("3039633444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("963-3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("963.3444"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("963 3444"));

            // These tests should be filtered out.
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("1-800 CALL-NOW"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("1-800 GO-AWAY"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("303.963.12345"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("-1-303.963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("+ 303.963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("+1 963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("+ 963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("1 963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("11 303.963.1234"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("963.12345"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("((303)-963-3444"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("303))-963-3444"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("303    963 3444"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The phone number cannot be null or empty!")]
        public void DoesThrowExceptionIfNullOrEmpty()
        {
            // Call a method with invalid arguments. The call should fail on the following line.
            PhoneValidator.ValidatePhoneNumber("");
            PhoneValidator.ValidatePhoneNumber(null);

            // Automatically fail this test if no exception was thrown.
            Assert.Fail();
        }
    }
}
