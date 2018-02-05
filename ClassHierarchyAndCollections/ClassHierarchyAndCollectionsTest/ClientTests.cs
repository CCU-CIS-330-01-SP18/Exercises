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
        public void ClientDerivesFromContact()
        {
            Client client = new Client();
            Assert.IsInstanceOfType(client, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Client client = new Client()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", client.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Client client = new Client()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", client.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Client client = new Client()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", client.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteGender()
        {
            Client client = new Client()
            {
                Gender = Gender.Male
            };
            Assert.AreEqual(Gender.Male, client.Gender);
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
        public void CanRemoveOrgans()
        {
            Client client = new Client();
            Assert.IsTrue(client.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotRemoveAllOrgans()
        {
            Client client = new Client();
            client.RemoveOrgan(Organ.Kidney);
            Assert.IsFalse(client.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanTransplantOrgans()
        {
            Client client = new Client();
            client.RemoveOrgan(Organ.Kidney);
            Assert.IsTrue(client.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotTransplantMoreOrgans()
        {
            Client client = new Client();
            Assert.IsFalse(client.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanRemoveKidneys()
        {
            Client client = new Client();
            int startingCount = client.NumberOfRemainingKidneys;
            client.RemoveOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount - 1, client.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanRemoveLungs()
        {
            Client client = new Client();
            int startingCount = client.NumberOfRemainingLungs;
            client.RemoveOrgan(Organ.Lung);
            Assert.AreEqual(startingCount - 1, client.NumberOfRemainingLungs);
        }

        [TestMethod]
        public void CanTransplantKidneys()
        {
            Client client = new Client();
            client.RemoveOrgan(Organ.Kidney);
            int startingCount = client.NumberOfRemainingKidneys;
            client.TransplantOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount + 1, client.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanTransplantLungs()
        {
            Client client = new Client();
            client.RemoveOrgan(Organ.Lung);
            int startingCount = client.NumberOfRemainingLungs;
            client.TransplantOrgan(Organ.Lung);
            Assert.AreEqual(startingCount + 1, client.NumberOfRemainingLungs);
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
                Happiness = 0
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
