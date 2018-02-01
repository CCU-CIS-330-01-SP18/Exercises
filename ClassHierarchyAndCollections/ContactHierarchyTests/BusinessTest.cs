using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Business can be created, their class derives from Organization,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class BusinessTest
    {
        /// <summary>
        /// A test that ensures that instances of Business can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateBusiness()
        {
            var createdBusiness = new Business();
            Assert.IsNotNull(createdBusiness);
        }

        /// <summary>
        /// A test that ensures that the Business class derives from Organization.
        /// </summary>
        [TestMethod]
        public void BusinessDerivesFromOrganization()
        {
            var createdBusiness = new Business();
            Assert.IsInstanceOfType(createdBusiness, typeof(Organization));
        }

        /// <summary>
        /// A test that ensures the AnnualNetIncome property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteAnnualNetIncome()
        {
            var createdBusiness = new Business();
            createdBusiness.AnnualNetIncome = 3;
            Assert.AreEqual(3, createdBusiness.AnnualNetIncome);
        }

        /// <summary>
        /// A test that ensures the OwnerName property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteOwnerName()
        {
            var createdBusiness = new Business();
            createdBusiness.OwnerName = "Test";
            Assert.AreEqual("Test", createdBusiness.OwnerName);
        }

        /// <summary>
        /// A test that ensures the Employees property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteEmployees()
        {
            var createdBusiness = new Business();
            List<Employee> testList = new List<Employee> { new Employee() };
            createdBusiness.Employees = testList;
            Assert.AreEqual(testList, createdBusiness.Employees);
        }
    }
}
