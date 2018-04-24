using JamesNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace JamesNetTests.Models
{
    [TestClass]
    public class SanitizerTests
    {
        [TestMethod]
        public void SanitizesMessages()
        {
            string injectedCode = "<script>alert('James eats matches!');</script>";
            string sanitizedCode = Sanitizer.Sanitize(injectedCode);
            Assert.IsFalse(Regex.IsMatch(sanitizedCode, @"\<script\>"));
        }

        [TestMethod]
        public void SanitizesCodeUsernames()
        {
            string injectedCode = "<script>alert('James eats matches!');</script>";
            string sanitizedCode = Sanitizer.SanitizeUsername(injectedCode);
            Assert.IsFalse(Regex.IsMatch(sanitizedCode, @"\<script\>"));
        }

        [TestMethod]
        public void SanitizesWhitespaceUsernames()
        {
            string whitespaceName = "";
            string sanitizedName = Sanitizer.SanitizeUsername(whitespaceName);
            Assert.IsFalse(String.IsNullOrWhiteSpace(sanitizedName));
        }
    }
}
