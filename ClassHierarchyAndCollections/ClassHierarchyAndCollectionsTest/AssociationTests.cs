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
        public void AssociationDerivesFromOrganization()
        {
            Association association = new Association();
            Assert.IsInstanceOfType(association, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteKeyTenets()
        {
            bool testResults;
            Association association = new Association();
            association.KeyTenets.Add("There is a violent solution to any problem.");
            association.KeyTenets.Add("Thievery is accepted. Sloppy thievery is punishable by extraction of one or more organs.");
            association.KeyTenets.Add("Thievery of others' organs is encouraged. It is simply sharing in what others have.");

            if ("There is a violent solution to any problem." == association.KeyTenets[0] &&
                    "Thievery is accepted. Sloppy thievery is punishable by extraction of one or more organs." == association.KeyTenets[1] &&
                    "Thievery of others' organs is encouraged. It is simply sharing in what others have." == association.KeyTenets[2])
            {
                testResults = true;
            }
            else
            {
                testResults = false;
            }
            Assert.IsTrue(testResults);
        }

        [TestMethod]
        public void CanReadWriteCult()
        {
            Association association = new Association()
            {
                IsACult = true
            };
            Assert.IsTrue(association.IsACult);
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

        [TestMethod]
        public void CanGetYeaVotes()
        {
            Association association = new Association();
            for (int i = 0; i < 5; i++)
            {
                association.Roster.Add(new Member()
                {
                    Personality = Personality.YesMan,
                    LiarAndScoundrel = false
                });
            }
            Assert.AreEqual(5, association.Vote()[0]);
        }

        [TestMethod]
        public void CanGetNayVotes()
        {
            Association association = new Association();
            for (int i = 0; i < 5; i++)
            {
                association.Roster.Add(new Member()
                {
                    Personality = Personality.GrouchyJerk,
                    LiarAndScoundrel = false
                });
            }
            Assert.AreEqual(5, association.Vote()[1]);
        }

        [TestMethod]
        public void CultMakesAllVotesYea()
        {
            Association association = new Association()
            {
                IsACult = true
            };
            for (int i = 0; i < 5; i++)
            {
                association.Roster.Add(new Member()
                {
                    Personality = Personality.GrouchyJerk,
                    LiarAndScoundrel = false
                });
            }
            Assert.AreEqual(5, association.Vote()[0]);
        }
    }
}
