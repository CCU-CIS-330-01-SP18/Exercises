using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Association"/> class.
    /// </summary>
    [TestClass]
    public class AssociationTests
    {
        [TestMethod]
        public void CanCreateAssociation()
        {
            Association association = new Association();
            Assert.IsNotNull(association);
        }

        [TestMethod]
        public void AssociationDerivesFromContact()
        {
            Association association = new Association();
            Assert.IsInstanceOfType(association, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Association association = new Association()
            {
                DisplayName = "Organ Donors Anonymous"
            };
            Assert.AreEqual("Organ Donors Anonymous", association.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Association association = new Association()
            {
                EmailAddress = "contact@oda.com"
            };
            Assert.AreEqual("contact@oda.com", association.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Association association = new Association()
            {
                PhoneNumber = "18006661385"
            };
            Assert.AreEqual("18006661385", association.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteMotto()
        {
            Association association = new Association()
            {
                Motto = "Give a part of yourself for the greater good."
            };
            Assert.AreEqual("Give a part of yourself for the greater good.", association.Motto);
        }

        [TestMethod]
        public void CanReadWriteFoundingDate()
        {
            var now = DateTime.Now;
            Association association = new Association()
            {
                FoundingDate = now
            };
            Assert.AreEqual(now, association.FoundingDate);
        }

        [TestMethod]
        public void CanRemoveMember()
        {
            Association association = new Association();
            Member member = new Member();
            association.Roster.Add(member);
            association.Roster.Remove(member);
            Assert.IsFalse(association.Roster.Contains(member));
        }

        [TestMethod]
        public void CanAddMember()
        {
            Association association = new Association();
            Member member = new Member();
            association.Roster.Add(member);
            Assert.IsTrue(association.Roster.Contains(member));
        }

        [TestMethod]
        public void CanCallAVote()
        {
            Association association = new Association();
            for (int i = 0; i < 5; i++)
            {
                association.Roster.Add(new Member());
            }
            Assert.IsInstanceOfType(association.Vote(), typeof(int[]));
        }
    }
}
