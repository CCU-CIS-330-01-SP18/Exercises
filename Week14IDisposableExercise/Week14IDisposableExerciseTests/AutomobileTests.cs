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
        public void AutomobileThrowsObjectDisposedException()
        {
            var a = new Truck("Sally");

            a.Dispose();

            a.BeReallyLoud();           
        }
    }
}
