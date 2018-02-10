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
        /// <summary>
        /// Tests whether the Invert Boolean class in Flow.cs returns true if passed a false value.
        /// </summary>
        [TestMethod]
        public void InvertBoolean_False_Returns_True()
        {
            Assert.IsTrue(Flow.InvertBoolean(false));
        }

        /// <summary>
        /// Tests whether the Invert Boolean class in Flow.cs returns false if passed a true value.
        /// </summary>
        [TestMethod]
        public void InvertBoolean_True_Returns_False()
        {
            Assert.IsFalse(Flow.InvertBoolean(true));
        }

        /// <summary>
        /// Tests whether the if else branching in flow.cs matches ProceedWithCaution when the color is Green.
        /// </summary>
        [TestMethod]
        public void DriveSafelyIfElse_Green_Returns_ProceedWithCaution()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Green);

            Assert.AreEqual(DriverAction.ProceedWithCaution, action);
        }

        /// <summary>
        /// Tests whether the if else branching in flow.cs matches StopIfSafe when the color is Yellow.
        /// </summary>
        [TestMethod]
        public void DriveSafelyIfElse_Yellow_Returns_StopIfSafe()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Yellow);

            Assert.AreEqual(DriverAction.StopIfSafe, action);
        }

        /// <summary>
        /// Tests whether the if else branching in flow.cs matches Stop when the color is Red.
        /// </summary>
        [TestMethod]
        public void DriveSafelyIfElse_Red_Returns_Stop()
        {
            DriverAction action = Flow.DriveSafelyIfElse(LightColor.Red);

            Assert.AreEqual(DriverAction.Stop, action);
        }

        /// <summary>
        /// Tests whether the if else branching in flow.cs matches Unkown when a color not part of the LightColor enumeration has been passed in as a paramater.
        /// </summary>
        [TestMethod]
        public void DriveSafelyIfElse_Other_Returns_Unknown()
        {
            DriverAction action = Flow.DriveSafelyIfElse((LightColor)42);

            Assert.AreEqual(DriverAction.Unknown, action);
        }

        /// <summary>
        /// Tests whether the switch statement in DriveSafelySwitch returns ProceedWithCaution when color is green.
        /// </summary>
        [TestMethod]
        public void DriveSafelySwitch_Green_Returns_ProceedWithCaution()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Green);

            Assert.AreEqual(DriverAction.ProceedWithCaution, action);
        }

        /// <summary>
        /// Tests whether the switch statement in DriveSafelySwitch returns StopIfSafe when color is yellow.
        /// </summary>
        [TestMethod]
        public void DriveSafelySwitch_Yellow_Returns_StopIfSafe()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Yellow);

            Assert.AreEqual(DriverAction.StopIfSafe, action);
        }

        /// <summary>
        /// Tests whether the switch statement in DriveSafelySwitch returns Stop when color is red.
        /// </summary>
        [TestMethod]
        public void DriveSafelySwitch_Red_Returns_Stop()
        {
            DriverAction action = Flow.DriveSafelySwitch(LightColor.Red);

            Assert.AreEqual(DriverAction.Stop, action);
        }

        /// <summary>
        /// Tests whether the switch statement in DriveSafelySwitch returns Unknown when an incorrect color is passed in from LightColor.cs enumeration.
        /// </summary>
        [TestMethod]
        public void DriveSafelySwitch_Other_Returns_Unknown()
        {
            DriverAction action = Flow.DriveSafelySwitch((LightColor)42);

            Assert.AreEqual(DriverAction.Unknown, action);
        }

        /// <summary>
        /// Tests that the sum of the values passed in is equal to the for loop calculation in Flow.cs.
        /// </summary>
        [TestMethod]
        public void ForEachSum_Returns_Correct_Total()
        {
            Random r = new Random();

            int[] values = new int[] { r.Next(100), r.Next(100), r.Next(100), r.Next(100), r.Next(100) };

            long total = Flow.ForEachSum(values);

            Debug.WriteLine(total);
            Assert.AreEqual(values.Sum(), total);
        }

        /// <summary>
        /// Tests that the sum of the values passed in is equal to the foreach loop calculation in Flow.cs.
        /// </summary>
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
