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
        public void MemberDerivesFromContact()
        {
            Member member = new Member();
            Assert.IsInstanceOfType(member, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Member member = new Member()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", member.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Member member = new Member()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", member.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Member member = new Member()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", member.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteGender()
        {
            Member member = new Member()
            {
                Gender = Gender.Male
            };
            Assert.AreEqual(Gender.Male, member.Gender);
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
        public void VotesYesIfYesMan()
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
        public void CanRemoveOrgans()
        {
            Member member = new Member();
            Assert.IsTrue(member.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotRemoveAllOrgans()
        {
            Member member = new Member();
            member.RemoveOrgan(Organ.Kidney);
            Assert.IsFalse(member.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanTransplantOrgans()
        {
            Member member = new Member();
            member.RemoveOrgan(Organ.Kidney);
            Assert.IsTrue(member.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotTransplantMoreOrgans()
        {
            Member member = new Member();
            Assert.IsFalse(member.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanRemoveKidneys()
        {
            Member member = new Member();
            int startingCount = member.NumberOfRemainingKidneys;
            member.RemoveOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount - 1, member.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanRemoveLungs()
        {
            Member member = new Member();
            int startingCount = member.NumberOfRemainingLungs;
            member.RemoveOrgan(Organ.Lung);
            Assert.AreEqual(startingCount - 1, member.NumberOfRemainingLungs);
        }

        [TestMethod]
        public void CanTransplantKidneys()
        {
            Member member = new Member();
            member.RemoveOrgan(Organ.Kidney);
            int startingCount = member.NumberOfRemainingKidneys;
            member.TransplantOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount + 1, member.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanTransplantLungs()
        {
            Member member = new Member();
            member.RemoveOrgan(Organ.Lung);
            int startingCount = member.NumberOfRemainingLungs;
            member.TransplantOrgan(Organ.Lung);
            Assert.AreEqual(startingCount + 1, member.NumberOfRemainingLungs);
        }
    }
}
