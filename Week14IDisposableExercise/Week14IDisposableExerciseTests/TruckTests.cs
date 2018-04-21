using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposableExercise;

namespace Week14IDisposableExerciseTests
{
    [TestClass]
    public class TruckTests
    {
        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void TruckThrowsObjectDisposedException()
        {
            var truck = new Truck("Mater");

            truck.Dispose();

            truck.DoAutomobileStuff();      
        }
    }
}
