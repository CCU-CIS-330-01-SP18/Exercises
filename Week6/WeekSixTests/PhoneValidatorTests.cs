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
            // Something is wrong
            PhoneValidator.ValidatePhoneNumber("(281)388-0388");
            PhoneValidator.ValidatePhoneNumber("3087774825");
        }
   
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoesThrowExceptionIfNullOrEmpty()
        {
            PhoneValidator.ValidatePhoneNumber(null);

            ArgumentNullException thrownException = null;
            try
            {
                PhoneValidator.ValidatePhoneNumber(null);
            }
            catch (ArgumentNullException ex)
            {
                thrownException = ex;
            }
        }
    }
}
