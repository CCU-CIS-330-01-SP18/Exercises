﻿using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Organization"/> class.
    /// </summary>
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanCreateOrganization()
        {
            Organization organization = new Organization();
            Assert.IsNotNull(organization);
        }

        [TestMethod]
        public void OrganizationDerivesFromContact()
        {
            Organization organization = new Organization();
            Assert.IsInstanceOfType(organization, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Organization organization = new Organization()
            {
                DisplayName = "Joja Corp."
            };
            Assert.AreEqual("Joja Corp.", organization.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Organization organization = new Organization()
            {
                EmailAddress = "contact@joja.com"
            };
            Assert.AreEqual("contact@joja.com", organization.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Organization organization = new Organization()
            {
                PhoneNumber = "18006661384"
            };
            Assert.AreEqual("18006661384", organization.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteMotto()
        {
            Organization organization = new Organization()
            {
                Motto = "Life's better with Joja."
            };
            Assert.AreEqual("Life's better with Joja.", organization.Motto);
        }

        [TestMethod]
        public void CanReadWriteFoundingDate()
        {
            var now = DateTime.Now;
            Organization organization = new Organization()
            {
                FoundingDate = now
            };
            Assert.AreEqual(now, organization.FoundingDate);
        }

        [TestMethod]
        public void CanAddMember()
        {
            Organization organization = new Organization();
            Individual individual = new Individual();
            organization.Roster.Add(individual);
            Assert.IsTrue(organization.Roster.Contains(individual));
        }

        [TestMethod]
        public void CanRemoveMember()
        {
            Organization organization = new Organization();
            Individual individual = new Individual();
            organization.Roster.Add(individual);
            organization.Roster.Remove(individual);
            Assert.IsFalse(organization.Roster.Contains(individual));
        }
    }
}
