using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INotDisposable;

namespace INotDisposableTests
{
    [TestClass]
    public class SomethingThatShouldNotBeDisposedTests
    {
        [TestMethod]
        public void CanAvoidDisposal()
        {
            var aThing = new SomethingThatShouldNotBeDisposed();

            aThing.RefrainFromDisposing();

            Assert.IsNotNull(aThing);
        }
    }
}
