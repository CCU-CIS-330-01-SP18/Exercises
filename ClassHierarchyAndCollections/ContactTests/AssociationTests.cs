using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
{
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
        public void IsDescandantOfOrganization()
        {
            Association association = new Association();
            Assert.IsInstanceOfType(association, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteMembers()
        {
            Association association = new Association();
            association.Members = new List<Member>();
            Member member = new Member();
            association.Members.Add(member);
            Assert.AreEqual(member, association.Members[0]);
        }

        [TestMethod]
        public void CanReadWriteAssociationFocus()
        {
            Association association = new Association();
            association.Focus = "Aiding Single Mothers";
            Assert.AreEqual("Aiding Single Mothers", association.Focus);
        }

        [TestMethod]
        public void CanUseInterface()
        {
            Association association = new Association();
            association.Members = new List<Member>();
            Member member1 = new Member();
            member1.DisplayName = "Bob";
            Member member2 = new Member();
            member2.DisplayName = "Joe";
            Member member3 = new Member();
            member3.DisplayName = "Sue";
            association.Members.Add(member1);
            association.Members.Add(member2);
            association.Members.Add(member3);

            association.ReadList();
        }
    }
}
