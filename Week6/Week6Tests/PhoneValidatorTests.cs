using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void PhoneValidatorReturnsFalseForInvalidPhoneNumber()
        {
            PhoneValidator.ValidatePhoneNumber("abc");
        }

        [TestMethod]
        public void PhoneValidatorThrowsForNullPhone()
        {
            ArgumentNullException throwException = null;

            try
            {
                PhoneValidator.ValidatePhoneNumber(null);
            }
            catch (ArguementOutOfRangeExeption ex)
            {
                throwException = ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsNullPhone()
        {
            PhoneValidator.ValidatePhoneNumber("abc");
        }
    }
}
