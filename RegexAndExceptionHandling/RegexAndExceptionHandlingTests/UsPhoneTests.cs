using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexAndExceptionHandling;

namespace RegexAndExceptionHandlingTests
{
    [TestClass]
    public class UsPhoneTests
    {
        [TestMethod]
        public void TestValidNumbers()
        {
            var phone = new UsPhone();
            string[] phoneNumbers = new string[] { "1234567899", "123 456 7899", "123-4567899", "123-456-7899", "123 456.7899", "(123) 456 7899", "(123) 456-7890", "(123) 456.7899", "(123)456.7899", "(123).456-7899", "(123)-4567899" };

            foreach (string num in phoneNumbers)
            {
                Assert.IsTrue(phone.IsValidNumber(num));
            }
        }

        [TestMethod]
        public void TestInvalidNumbers()
        {
            var phone = new UsPhone();
            string[] phoneNumbers = new string[] { "123456789", "123456-7899", "123) 456 7890", "(123)- 456-7890", "(123-456 7890", "(123-456.7890", "123-45-67890", "12-345-67890", "123-4567-890", "(12)345 67890" };

            foreach (string num in phoneNumbers)
            {
                Assert.IsFalse(phone.IsValidNumber(num));
            }
        }

        [TestMethod]
        public void TestExceptionNumbers()
        {
            var phone = new UsPhone();
            string[] phoneNumbers = new string[] { null, "" };

            foreach (string num in phoneNumbers)
            {
                Assert.ThrowsException<ArgumentNullException>(() => phone.IsValidNumber(num));
            }
        }
    }
}
