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
            //Phone Numbers that are accepted
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)-977-1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847) 977-1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)-977 1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)977-1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)-9771281"));

            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847).977.1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847) 977.1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847).977 1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)977.1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847).9771281"));

            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847) 977 1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847) 9771281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)977 1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("(847)9771281"));

            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("977-1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("977.1281"));
            Assert.IsTrue(PhoneValidator.ValidatePhoneNumber("977 1281"));

            //Phone Numbers that are not accepted
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("((847)-977-1281"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("(847)-977&1281"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("(847)-9757-1281"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("(847)-977-12851"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("(847)-wor-1281"));
            Assert.IsFalse(PhoneValidator.ValidatePhoneNumber("(847)-9757-1ehe1"));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
            PhoneValidator.ValidatePhoneNumber("");
            PhoneValidator.ValidatePhoneNumber(null);
        }
    }
}
