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
        public void EmployeeDerivesFromContact()
        {
            Employee employee = new Employee();
            Assert.IsInstanceOfType(employee, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Employee employee = new Employee()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", employee.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Employee employee = new Employee()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", employee.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Employee employee = new Employee()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", employee.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteGender()
        {
            Employee employee = new Employee()
            {
                Gender = Gender.Male
            };
            Assert.AreEqual(Gender.Male, employee.Gender);
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
        public void CanRemoveOrgans()
        {
            Employee employee = new Employee();
            Assert.IsTrue(employee.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotRemoveAllOrgans()
        {
            Employee employee = new Employee();
            employee.RemoveOrgan(Organ.Kidney);
            Assert.IsFalse(employee.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanTransplantOrgans()
        {
            Employee employee = new Employee();
            employee.RemoveOrgan(Organ.Kidney);
            Assert.IsTrue(employee.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotTransplantMoreOrgans()
        {
            Employee employee = new Employee();
            Assert.IsFalse(employee.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanRemoveKidneys()
        {
            Employee employee = new Employee();
            int startingCount = employee.NumberOfRemainingKidneys;
            employee.RemoveOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount - 1, employee.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanRemoveLungs()
        {
            Employee employee = new Employee();
            int startingCount = employee.NumberOfRemainingLungs;
            employee.RemoveOrgan(Organ.Lung);
            Assert.AreEqual(startingCount - 1, employee.NumberOfRemainingLungs);
        }

        [TestMethod]
        public void CanTransplantKidneys()
        {
            Employee employee = new Employee();
            employee.RemoveOrgan(Organ.Kidney);
            int startingCount = employee.NumberOfRemainingKidneys;
            employee.TransplantOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount + 1, employee.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanTransplantLungs()
        {
            Employee employee = new Employee();
            employee.RemoveOrgan(Organ.Lung);
            int startingCount = employee.NumberOfRemainingLungs;
            employee.TransplantOrgan(Organ.Lung);
            Assert.AreEqual(startingCount + 1, employee.NumberOfRemainingLungs);
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
