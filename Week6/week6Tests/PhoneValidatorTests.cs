using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week6;
namespace week6Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PhoneValidatorThrowsForNullPhone()
        {
                PhoneValidator.ValidatePhoneNumber(null);
        }
    }
}
