using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramFlow;
using System.Linq;
using System.Diagnostics;

namespace ProgramFlowTests
{
    /// <summary>
    /// Defines tests for the <see cref="Flow"/> class.
    /// </summary>
    /// <remarks>
    /// DO NOT MODIFY THIS CLASS. All code modifications should be done in the <see cref="Flow"/>
    /// class to allow these tests to run successfully.
    /// </remarks>
    [TestClass]
    public class FlowTests
    {
        [TestMethod]
        public void InvertBoolean_False_Returns_True()
        {
            Assert.IsTrue(Flow.InvertBoolean(false));
        }

        [TestMethod]
        public void InvertBoolean_True_Returns_False()
        {
            Assert.IsFalse(Flow.InvertBoolean(true));
        }

        [TestMethod]
        public void DriveSafelyIfElse_Green_Returns_ProceedWithCaution()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Green);

            Assert.AreEqual(DriverAction.ProceedWithCaution, action);
        }

        [TestMethod]
        public void DriveSafelyIfElse_Yellow_Returns_StopIfSafe()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Yellow);

            Assert.AreEqual(DriverAction.StopIfSafe, action);
        }

        [TestMethod]
        public void DriveSafelyIfElse_Red_Returns_Stop()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Red);

            Assert.AreEqual(DriverAction.Stop, action);
        }

        [TestMethod]
        public void DriveSafelyIfElse_Other_Returns_Unknown()
        {
            DriverAction action = Flow.DriveSafelyIfElse((LightColor)42);

            Assert.AreEqual(DriverAction.Unknown, action);
        }

        [TestMethod]
        public void DriveSafelySwitch_Green_Returns_ProceedWithCaution()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Green);

            Assert.AreEqual(DriverAction.ProceedWithCaution, action);
        }

        [TestMethod]
        public void DriveSafelySwitch_Yellow_Returns_StopIfSafe()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Yellow);

            Assert.AreEqual(DriverAction.StopIfSafe, action);
        }

        [TestMethod]
        public void DriveSafelySwitch_Red_Returns_Stop()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Red);

            Assert.AreEqual(DriverAction.Stop, action);
        }

        [TestMethod]
        public void DriveSafelySwitch_Other_Returns_Unknown()
        {
            DriverAction action = Flow.DriveSafelySwitch((LightColor)42);

            Assert.AreEqual(DriverAction.Unknown, action);
        }

        [TestMethod]
        public void ForEachSum_Returns_Correct_Total()
        {
            Random r = new Random();

            int[] values = new int[] { r.Next(100), r.Next(100), r.Next(100), r.Next(100), r.Next(100) };

            long total = Flow.ForEachSum(values);

            Debug.WriteLine(total);
            Assert.AreEqual(values.Sum(), total);
        }

        [TestMethod]
        public void ForSum_Returns_Correct_Total()
        {
            Random r = new Random();

            int[] values = new int[] { r.Next(100), r.Next(100), r.Next(100), r.Next(100), r.Next(100) };

            long total = Flow.ForSum(values);

            Debug.WriteLine(total);
            Assert.AreEqual(values.Sum(), total);
        }
    }
}
