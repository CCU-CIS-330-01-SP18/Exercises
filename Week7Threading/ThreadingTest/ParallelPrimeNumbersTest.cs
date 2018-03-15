using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Threading;

namespace ThreadingTest
{
    [TestClass]
    public class ParallelPrimeNumbersTest
    {
        [TestMethod]
        public void Prime_Number_Works()
        {
            var prime1 = ParallelPrimeNumbers.IsPrime(7);
            var prime2 = ParallelPrimeNumbers.IsPrime(10);

            Assert.IsTrue(prime1);
            Assert.IsFalse(prime2);
        }

        [TestMethod]
        public void Array_Exists_And_Has_Values()
        {
            var primeArray1 = ParallelPrimeNumbers.Calculations(0, 5000);

            Assert.IsNotNull(primeArray1);
            Assert.IsTrue(primeArray1.Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Throw_Exception_For_Min_Greater_Than_Max()
        {
            var primeArray3 = ParallelPrimeNumbers.Calculations(10, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Throw_Exception_For_Invalid_Numbers()
        {
            var primeArray2 = ParallelPrimeNumbers.Calculations(0, 0);
        }
    }
}

