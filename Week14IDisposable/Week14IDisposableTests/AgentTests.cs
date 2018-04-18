using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposable;

namespace Week14IDisposableTests
{
    [TestClass]
    public class AgentTests
    {
        [TestMethod]
        public void CanDisposeAgent()
        {
            string name = "James Bond";
            int id = 7;
            var agent = new Agent(name, id);
            Assert.AreEqual(name, agent.AssetName);

            agent.Dispose();
            Assert.IsNull(agent.AssetName);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void ThrowsExceptionAfterDisposal()
        {
            var agent = new Agent("Agent Coulson", 30);
            var asset = new Asset("Nick Fury", 10);
            var report = agent.RequestReport(asset);

            Assert.IsTrue(report.Count > 0);

            agent.Dispose();
            report = agent.RequestReport(asset);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void ReportRequiresClearance()
        {
            var agent = new Agent("Agent Coulson", 30);
            var asset = new Asset("Nick Fury", 1);
            var report = agent.RequestReport(asset);
            Assert.Fail();
        }
    }
}
