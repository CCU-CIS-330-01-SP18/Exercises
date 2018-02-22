using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneValidator;

namespace PhoneValidatorTests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        [TestMethod]
        public void PhoneValidatorValidatesPhoneNumbers()
        {
            string[] goodNumbers = new string[] { "3039633000", "303-963-3000", "303.963.3000", "303 963 3000",
                "(303)9633000", "(303)-963-3000", "(303).963.3000", "(303) 963 3000",
                "[303]9633000", "[303]-963-3000", "[303].963.3000", "[303] 963 3000",
                "+13039633000", "+1-303-963-3000", "+1.303.963.3000", "+1 303 963 3000",
                "+1(303)9633000", "+1-(303)-963-3000", "+1.(303).963.3000", "+1 (303) 963 3000",
                "+1[303]9633000", "+1-[303]-963-3000", "+1.[303].963.3000", "+1 [303] 963 3000",
                "13039633000", "1-303-963-3000", "1.303.963.3000", "1 303 963 3000",
                "1(303)9633000", "1-(303)-963-3000", "1.(303).963.3000", "1 (303) 963 3000",
                "1[303]9633000", "1-[303]-963-3000", "1.[303].963.3000", "1 [303] 963 3000",
                "911", "9-1-1", "511", "5-1-1", "211", "2-1-1" };
            foreach (string number in goodNumbers)
            {
                Assert.IsTrue(Validator.Validate(number), "Good phone number {0} did not validate.", number);
            }

            string[] badNumbers = new string[] { "303963300", "30396330001", "303.963..3000", "303--963-3000",
                "303/963/3000", "303  963  3000", "-13039633000", "01189998819991197253",
                "peike@students.ccu.edu", "+3039633444", "1-800-6SHARKS", "((303)-963-3000",
                "[[303]]-963-3000", "++13039633000", "1+3039633000", "123-456-7890",
                "111", "000", "999" };
            foreach (string number in badNumbers)
            {
                Assert.IsFalse(Validator.Validate(number), "Bad phone number {0} validated.", number);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void PhoneValidatorThrowsExceptionOnEmpty()
        {
            string phoneNumber = string.Empty;
            bool result = Validator.Validate(phoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void PhoneValidatorThrowsExceptionOnNull()
        {
            string phoneNumber = null;
            bool result = Validator.Validate(phoneNumber);
        }
    }
}
