using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsonsFinalProject;


namespace ParsonsFinalProjectTests
{
    [TestClass]
    public class TextToValidateTests
    {
        [TestMethod]
        public void ValidateTextTest()
        {
            var textValidator = new TextToValidate();
            bool valid = textValidator.ValidateText("This isn't allowed  ¯\\_^-(ツ)-^_//¯");
            Assert.IsFalse(valid);
        }
    }
}
