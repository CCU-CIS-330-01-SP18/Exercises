using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberCalculator;

namespace PrimeNumberCalculatorTests
{
    [TestClass]
    public class PrimeNumberCalculatorTests
    {
        [TestMethod]
        public void UsingThreads()
        {
            List<int> primesNotThreaded = new List<int>();
            List<int> primesThreaded = new List<int>();
            int elapsedNotThreaded;
            int elapsedThreaded;
            int initialValue = 0;
            int maxValue = 100000;

            Calculator calculator = new Calculator();

            //Run non threaded prime number calculation from initialValue to maxValue
            primesNotThreaded = calculator.CalculatePrimeThreads(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedNotThreaded = primesNotThreaded[primesNotThreaded.Count - 1];
            primesNotThreaded.RemoveAt(primesNotThreaded.Count - 1);

            //Run threaded prime number calculation from initialValue to maxValue
            primesThreaded = calculator.CalculatePrimeThreads(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedThreaded = primesThreaded[primesThreaded.Count - 1];
            primesThreaded.RemoveAt(primesThreaded.Count - 1);

            //Is the elapsed time shorter for threaded method than non threaded method?
            Assert.IsTrue(elapsedThreaded < elapsedNotThreaded);
            //Are there items in the 'Primes' lists?
            Assert.IsNotNull(primesNotThreaded);
            Assert.IsNotNull(primesThreaded);
            //Did both methods produce the same number of items?
            Assert.AreEqual(primesNotThreaded.Count, primesThreaded.Count);
        }

        [TestMethod]
        public void UsingTasks()
        {
            List<int> primesNotThreaded = new List<int>();
            List<int> primesThreaded = new List<int>();
            int elapsedNotThreaded;
            int elapsedThreaded;
            int initialValue = 0;
            int maxValue = 250000;

            Calculator calculator = new Calculator();

            //Run non threaded prime number calculation from initialValue to maxValue
            primesNotThreaded = calculator.CalculatePrime(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedNotThreaded = primesNotThreaded[primesNotThreaded.Count - 1];
            primesNotThreaded.RemoveAt(primesNotThreaded.Count - 1);

            //Run threaded prime number calculation from initialValue to maxValue
            primesThreaded = calculator.CalculatePrimeTasks(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedThreaded = primesThreaded[primesThreaded.Count - 1];
            primesThreaded.RemoveAt(primesThreaded.Count - 1);

            //Is the elapsed time shorter for threaded method than non threaded method?
            Assert.IsTrue(elapsedThreaded < elapsedNotThreaded);
            //Are there items in the 'Primes' lists?
            Assert.IsNotNull(primesNotThreaded);
            Assert.IsNotNull(primesThreaded);
            //Did both methods produce the same number of items?
            Assert.AreEqual(primesNotThreaded.Count, primesThreaded.Count);
        }

        [TestMethod]
        public void UsingThreadPool()
        {
            List<int> primesNotThreaded = new List<int>();
            List<int> primesThreaded = new List<int>();
            int elapsedNotThreaded;
            int elapsedThreaded;
            int initialValue = 0;
            int maxValue = 250000;

            Calculator calculator = new Calculator();

            //Run non threaded prime number calculation from initialValue to maxValue
            primesNotThreaded = calculator.CalculatePrime(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedNotThreaded = primesNotThreaded[primesNotThreaded.Count - 1];
            primesNotThreaded.RemoveAt(primesNotThreaded.Count - 1);

            //Run threaded prime number calculation from initialValue to maxValue
            primesThreaded = calculator.CalculatePrimeThreadPool(initialValue, maxValue);

            //Seperates elapsed time and removes its presence in the list
            elapsedThreaded = primesThreaded[primesThreaded.Count - 1];
            primesThreaded.RemoveAt(primesThreaded.Count - 1);

            //Is the elapsed time shorter for threaded method than non threaded method?
            Assert.IsTrue(elapsedThreaded < elapsedNotThreaded);
            //Are there items in the 'Primes' lists?
            Assert.IsNotNull(primesNotThreaded);
            Assert.IsNotNull(primesThreaded);
            //Did both methods produce the same number of items?
            Assert.AreEqual(primesNotThreaded.Count, primesThreaded.Count);
        }
    }
}