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
            Association a = new Association();
            Assert.IsNotNull(a);

        }

        [TestMethod]
        public void IsDescandantOfOrganization()
        {
            Association a = new Association();
            Assert.IsInstanceOfType(a, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteMembers()
        {
            Association a = new Association();
            a.Members = new List<Member>();
            Member m = new Member();
            a.Members.Add(m);
            Assert.AreEqual(m, a.Members[0]);
        }

        [TestMethod]
        public void CanReadWriteAssociationFocus()
        {
            Association a = new Association();
            a.Focus = "Aiding Single Mothers";
            Assert.AreEqual("Aiding Single Mothers", a.Focus);
        }

        [TestMethod]
        public void CanUseInterface()
        {
            Association a = new Association();
            a.Members = new List<Member>();
            Member m1 = new Member();
            m1.DisplayName = "Bob";
            Member m2 = new Member();
            m2.DisplayName = "Joe";
            Member m3 = new Member();
            m3.DisplayName = "Sue";
            a.Members.Add(m1);
            a.Members.Add(m2);
            a.Members.Add(m3);

            a.ReadList();
        }
    }
}
