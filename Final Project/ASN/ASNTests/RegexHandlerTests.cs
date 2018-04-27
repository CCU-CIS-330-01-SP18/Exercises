using System;
using ASN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASNTests
{
    [TestClass]
    public class RegexHandlerTests
    {
        [TestMethod]
        public void RegexValidateName()
        {
            // Names and their associated True/False test were chosen at random!
            Assert.IsFalse(RegexHandler.Name("MAcy"));
            Assert.IsFalse(RegexHandler.Name("dean"));
            Assert.IsFalse(RegexHandler.Name("DYLAN"));
            Assert.IsFalse(RegexHandler.Name("Ryan1"));
            Assert.IsFalse(RegexHandler.Name("_Chad"));
            Assert.IsFalse(RegexHandler.Name("LeX"));
            Assert.IsFalse(RegexHandler.Name("Professor Anderson"));

            Assert.IsTrue(RegexHandler.Name("Jay"));
            Assert.IsTrue(RegexHandler.Name("Justin"));
            Assert.IsTrue(RegexHandler.Name("Haden"));
        }

        [TestMethod]
        public void RegexValidateUsername()
        {
            Assert.IsFalse(RegexHandler.Username("crazy.dude.27"));
            Assert.IsFalse(RegexHandler.Username("Ca$hPr1ze"));
            Assert.IsFalse(RegexHandler.Username("abc"));

            Assert.IsTrue(RegexHandler.Username("AquaMan"));
            Assert.IsTrue(RegexHandler.Username("redLeader8"));
            Assert.IsTrue(RegexHandler.Username("21Pilots"));
        }

        [TestMethod]
        public void RegexValidateEmail()
        {
            Assert.IsFalse(RegexHandler.Email("secret@agentman.a"));
            Assert.IsFalse(RegexHandler.Email("meowgmail.com"));
            Assert.IsFalse(RegexHandler.Email("@aol.com"));
            Assert.IsFalse(RegexHandler.Email("hwatne@"));
            Assert.IsFalse(RegexHandler.Email("my..nextdoorNeighbor@amazon.frenchfry"));

            Assert.IsTrue(RegexHandler.Email("mattanderson@ga.ccu.edu"));
            Assert.IsTrue(RegexHandler.Email("hwatne@students.ccu.edu"));
            Assert.IsTrue(RegexHandler.Email("chapel@ccu.edu"));
            Assert.IsTrue(RegexHandler.Email("test.address@test.com"));
        }
    }
}
