using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Client class.
    /// </summary>
    [TestClass]
    public class ClientTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateClient()
        {
            Client c = new Client();
            Assert.IsNotNull(c);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Client c = new Client();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            Client c = new Client();
            Assert.IsInstanceOfType(c, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void ClientCanReadWriteIdentificationNumber()
        {
            Client c = new Client();
            c.IdentificationNumber = 10;
            Assert.AreEqual(10, c.IdentificationNumber);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void ClientCanReadWriteEmergencyContact()
        {
            Client c = new Client();
            c.EmergencyContact = "Justin Horak";
            Assert.AreEqual("Justin Horak", c.EmergencyContact);
        }
    }
}
