﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanMakeClient()
        {
            Client i = new Client();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetPhoneNumber()
        {
            Client i = new Client();
            i.PhoneNumber = "911";
            Assert.AreEqual("911", i.PhoneNumber);
        }

        [TestMethod]
        public void CanGetSetMaritalStatus()
        {
            Client i = new Client();
            i.MaritalStatus = "It's Complicated";
            Assert.AreEqual("It's Complicated", i.MaritalStatus);
        }

        [TestMethod]
        public void IsAContact()
        {
            Client i = new Client();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }
    }
}
