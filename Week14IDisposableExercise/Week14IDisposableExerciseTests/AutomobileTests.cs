using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposableExercise;

namespace Week14IDisposableExerciseTests
{
    [TestClass]
    
    public class AutomobileTests
    {
        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void ThrowsException()
        {
            Automobile a = new Truck();

            Truck truck = new Truck();

            a.Dispose();

            truck.BeReallyLoud();
        }
    }
}
