using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Employee"/> class.
    /// </summary>
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void CanCreateEmployee()
        {
            Employee employee = new Employee();
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void EmployeeDerivesFromIndividual()
        {
            Employee employee = new Employee();
            Assert.IsInstanceOfType(employee, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteUnionMembership()
        {
            Employee employee = new Employee()
            {
                UnionMembership = "Worker's Coalition"
            };
            Assert.AreEqual("Worker's Coalition", employee.UnionMembership);
        }

        [TestMethod]
        public void CanReadWriteHappiness()
        {
            Employee employee = new Employee()
            {
                Happiness = 5
            };
            Assert.AreEqual(5, employee.Happiness);
        }

        [TestMethod]
        public void CanReadWriteExempt()
        {
            Employee employee = new Employee()
            {
                Exempt = true
            };
            Assert.AreEqual(true, employee.Exempt);
        }

        [TestMethod]
        public void CanPay()
        {
            Employee employee = new Employee()
            {
                Wallet = 20.00m
            };
            Assert.AreEqual(10.00m, employee.Pay(10.00m));
        }

        [TestMethod]
        public void CannotSpendMoreThanItHas()
        {
            Employee employee = new Employee()
            {
                Wallet = 20.00m
            };
            Assert.AreEqual(0.00m, employee.Pay(30.00m));
        }

        [TestMethod]
        public void CanReceivePayment()
        {
            Employee employee = new Employee();
            employee.ReceivePayment(10.00m);
            Assert.AreEqual(10.00m, employee.Wallet);
        }

        [TestMethod]
        public void HappinessIncreasesOnReceiptOfMoney()
        {
            Employee employee = new Employee()
            {
                Happiness = 0
            };
            employee.ReceivePayment(10.00m);
            Assert.AreEqual(1, employee.Happiness);
        }

        [TestMethod]
        public void HappinessDecreasesOnFailedPayment()
        {
            Employee employee = new Employee()
            {
                Happiness = 0,
                Wallet = 0.00m
            };
            employee.Pay(10.00m);
            Assert.AreEqual(-1, employee.Happiness);
        }
    }
}
