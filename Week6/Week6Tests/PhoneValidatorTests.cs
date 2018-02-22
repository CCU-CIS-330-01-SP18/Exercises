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
        [ExpectedException(typeof(ArgumentNullException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
            // Need to have ExpectedException Line 17:
            PhoneValidator.ValidatePhoneNumber(null);

            /* If you do not have ExpectedException need to write the following code below...
            ArgumentNullException thrownException = null;
            try
            {
                PhoneValidator.ValidatePhoneNumber(null);
            }
            catch(ArgumentNullException ex)
            {
                thrownException = ex;
            }
            Assert.IsNotNull(thrownException);
            */
        }
    }
}