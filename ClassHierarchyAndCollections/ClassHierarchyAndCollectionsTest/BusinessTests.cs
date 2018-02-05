using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Business"/> class.
    /// </summary>
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void CanCreateBusiness()
        {
            Business business = new Business();
            Assert.IsNotNull(business);
        }

        [TestMethod]
        public void BusinessDerivesFromContact()
        {
            Business business = new Business();
            Assert.IsInstanceOfType(business, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Business business = new Business()
            {
                DisplayName = "Joja Corp."
            };
            Assert.AreEqual("Joja Corp.", business.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Business business = new Business()
            {
                EmailAddress = "contact@joja.com"
            };
            Assert.AreEqual("contact@joja.com", business.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Business business = new Business()
            {
                PhoneNumber = "18006661384"
            };
            Assert.AreEqual("18006661384", business.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteMotto()
        {
            Business business = new Business()
            {
                Motto = "Life's better with Joja."
            };
            Assert.AreEqual("Life's better with Joja.", business.Motto);
        }

        [TestMethod]
        public void CanReadWriteFoundingDate()
        {
            var now = DateTime.Now;
            Business business = new Business()
            {
                FoundingDate = now
            };
            Assert.AreEqual(now, business.FoundingDate);
        }

        [TestMethod]
        public void CanReadWriteBusinessType()
        {
            Business business = new Business()
            {
                BusinessType = BusinessType.Corporation
            };
            Assert.AreEqual(BusinessType.Corporation, business.BusinessType);
        }

        [TestMethod]
        public void CanReadWriteCash()
        {
            Business business = new Business()
            {
                Cash = 20000.00m
            };
            Assert.AreEqual(20000.00m, business.Cash);
        }

        [TestMethod]
        public void CanReadWriteProductList()
        {
            Business business = new Business();
            business.Products.Add("Joja Cola", 5.99m);
            Assert.AreEqual(5.99m, business.Products["Joja Cola"]);
        }

        [TestMethod]
        public void CanAddMember()
        {
            Business business = new Business();
            Individual individual = new Individual();
            business.Roster.Add(individual);
            Assert.IsTrue(business.Roster.Contains(individual));
        }

        [TestMethod]
        public void CanRemoveMember()
        {
            Business business = new Business();
            Employee employee = new Employee();
            business.Roster.Add(employee);
            business.Roster.Remove(employee);
            Assert.IsFalse(business.Roster.Contains(employee));
        }

        [TestMethod]
        public void CanSellProduct()
        {
            Business business = new Business();
            Client client = new Client()
            {
                Wallet = 20.00m
            };
            business.Products.Add("Joja Cola", 5.99m);
            Assert.IsTrue(business.SellProduct("Joja Cola", client));
        }

        [TestMethod]
        public void CanNotSellProductToBankruptClient()
        {
            Business business = new Business();
            Client client = new Client()
            {
                Wallet = 0.00m
            };
            business.Products.Add("Joja Cola", 5.99m);
            Assert.IsFalse(business.SellProduct("Joja Cola", client));
        }

        [TestMethod]
        public void CanPay()
        {
            Business business = new Business()
            {
                Cash = 20.00m
            };
            Assert.AreEqual(10.00m, business.Pay(10.00m));
        }

        [TestMethod]
        public void CannotSpendMoreThanItHas()
        {
            Business business = new Business()
            {
                Cash = 20.00m
            };
            Assert.AreEqual(0.00m, business.Pay(30.00m));
        }

        [TestMethod]
        public void CanReceivePayment()
        {
            Business business = new Business();
            business.ReceivePayment(10.00m);
            Assert.AreEqual(10.00m, business.Cash);
        }
    }
}
