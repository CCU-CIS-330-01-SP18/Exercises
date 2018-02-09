using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Member"/> class.
    /// </summary>
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void CanCreateMember()
        {
            Member member = new Member();
            Assert.IsNotNull(member);
        }

        [TestMethod]
        public void MemberDerivesFromIndividual()
        {
            Member member = new Member();
            Assert.IsInstanceOfType(member, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteLiar()
        {
            Member member = new Member()
            {
                LiarAndScoundrel = true
            };
            Assert.AreEqual(true, member.LiarAndScoundrel);
        }

        [TestMethod]
        public void CanReadWritePersonality()
        {
            Member member = new Member()
            {
                Personality = Personality.OverlyDeliberative
            };
            Assert.AreEqual(Personality.OverlyDeliberative, member.Personality);
        }

        [TestMethod]
        public void VotesYeaIfYesMan()
        {
            Member member = new Member()
            {
                Personality = Personality.YesMan,
                LiarAndScoundrel = false
            };
            Assert.AreEqual(VoteType.Yea, member.Vote());
        }

        [TestMethod]
        public void VotesNayIfGrouchyJerk()
        {
            Member member = new Member()
            {
                Personality = Personality.GrouchyJerk,
                LiarAndScoundrel = false
            };
            Assert.AreEqual(VoteType.Nay, member.Vote());
        }

        [TestMethod]
        public void VotesIfSwingVoter()
        {
            Member member = new Member()
            {
                Personality = Personality.SwingVoter
            };
            Assert.IsNotNull(member.Vote());
        }

        [TestMethod]
        public void VotesIfOverlyDeliberative()
        {
            Member member = new Member()
            {
                Personality = Personality.OverlyDeliberative
            };
            Assert.IsNotNull(member.Vote());
        }

        [TestMethod]
        public void LiarYesMenLie()
        {
            Member member = new Member()
            {
                Personality = Personality.YesMan,
                LiarAndScoundrel = true
            };
            Assert.AreEqual(VoteType.Nay, member.Vote());
        }

        [TestMethod]
        public void LiarGrouchyJerksLie()
        {
            Member member = new Member()
            {
                Personality = Personality.GrouchyJerk,
                LiarAndScoundrel = true
            };
            Assert.AreEqual(VoteType.Yea, member.Vote());
        }
    }
}
