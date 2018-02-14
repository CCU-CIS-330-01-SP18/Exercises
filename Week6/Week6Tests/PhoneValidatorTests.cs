using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week6;

namespace Week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void PhoneValidatorReturnsFalseForInvalidPhone()
        {
            PhoneValidator.ValidatePhoneNumber("abc");
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
