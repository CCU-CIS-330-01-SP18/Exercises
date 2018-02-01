using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Employee can be created, their class derives from Individual,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class EmployeeTest
    {
        /// <summary>
        /// A test that ensures that instances of Employee can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateEmployee()
        {
            var createdEmployee = new Employee();
            Assert.IsNotNull(createdEmployee);
        }

        /// <summary>
        /// A test that ensures that the Employee class derives from Individual.
        /// </summary>
        [TestMethod]
        public void EmployeeDerivesFromIndividual()
        {
            var createdEmployee = new Employee();
            Assert.IsInstanceOfType(createdEmployee, typeof(Individual));
        }

        /// <summary>
        /// A test that ensures the AnnualSalary property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteAnnualSalary()
        {
            var createdEmployee = new Employee();
            createdEmployee.AnnualSalary = 3;
            Assert.AreEqual(3, createdEmployee.AnnualSalary);
        }

        /// <summary>
        /// A test that ensures the JobName property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteJobName()
        {
            var createdEmployee = new Employee();
            createdEmployee.JobName = "Test";
            Assert.AreEqual("Test", createdEmployee.JobName);
        }
    }
}
