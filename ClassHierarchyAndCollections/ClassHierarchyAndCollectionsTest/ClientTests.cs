using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Client"/> class.
    /// </summary>
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanCreateClient()
        {
            Client client = new Client();
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void ClientDerivesFromIndividual()
        {
            Client client = new Client();
            Assert.IsInstanceOfType(client, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteHappiness()
        {
            Client client = new Client()
            {
                Happiness = 5
            };
            Assert.AreEqual(5, client.Happiness);
        }

        [TestMethod]
        public void CanReadWritePossessions()
        {
            Client client = new Client();
            client.Possessions.Add("Joja Cola");
            Assert.AreEqual("Joja Cola", client.Possessions[0]);
        }

        [TestMethod]
        public void CanReadWriteGreedFactor()
        {
            Client client = new Client()
            {
                GreedFactor = 5
            };
            Assert.AreEqual(5, client.GreedFactor);
        }

        [TestMethod]
        public void CanPay()
        {
            Client client = new Client()
            {
                Wallet = 20.00m
            };
            Assert.AreEqual(10.00m, client.Pay(10.00m));
        }

        [TestMethod]
        public void CannotSpendMoreThanItHas()
        {
            Client client = new Client()
            {
                Wallet = 20.00m
            };
            Assert.AreEqual(0.00m, client.Pay(30.00m));
        }

        [TestMethod]
        public void CanReceivePayment()
        {
            Client client = new Client();
            client.ReceivePayment(10.00m);
            Assert.AreEqual(10.00m, client.Wallet);
        }

        [TestMethod]
        public void HappinessIncreasesOnReceiptOfMoney()
        {
            Client client = new Client()
            {
                Happiness = 0,
                GreedFactor = 1
            };
            client.ReceivePayment(10.00m);
            Assert.AreEqual(1, client.Happiness);
        }

        [TestMethod]
        public void HappinessDecreasesOnFailedPayment()
        {
            Client client = new Client()
            {
                Happiness = 0,
                GreedFactor = 1,
                Wallet = 0.00m
            };
            client.Pay(10.00m);
            Assert.AreEqual(-1, client.Happiness);
        }

        [TestMethod]
        public void CanCollectPossessions()
        {
            Client client = new Client()
            {
                Wallet = 20.00m
            };
            client.Purchase(5.00m, "Joja Cola");
            Assert.AreEqual("Joja Cola", client.Possessions[0]);
        }

        [TestMethod]
        public void CanPurchasePossessions()
        {
            Client client = new Client()
            {
                Wallet = 20.00m
            };
            client.Purchase(5.00m, "Joja Cola");
            Assert.AreEqual(15.00m, client.Wallet);
        }
    }
}
