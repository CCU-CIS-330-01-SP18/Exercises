using JamesNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace JamesNetTests.Models
{
    [TestClass]
    public class SanitizerTests
    {
        [TestMethod]
        public void SanitizesCodeInjectionMessages()
        {
            string injectedCode = "<script>alert('James eats matches!');</script>";
            string sanitizedCode = Sanitizer.Sanitize(injectedCode);
            Assert.IsFalse(Regex.IsMatch(sanitizedCode, @"\<script\>"));
        }

        [TestMethod]
        public void SanitizesLongMessages()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < 500; i++)
            {
                builder.Append(i);
            }
            string longMessage = builder.ToString();
            string shortenedMessage = Sanitizer.Sanitize(longMessage);
            Assert.IsTrue(shortenedMessage.Length <= 255);
        }

        [TestMethod]
        public void SanitizesCodeUsernames()
        {
            string injectedCode = "<script>alert('James eats matches!');</script>";
            string sanitizedCode = Sanitizer.SanitizeUsername(injectedCode);
            Assert.IsFalse(Regex.IsMatch(sanitizedCode, @"\<script\>"));
        }

        [TestMethod]
        public void SanitizesLongUsernames()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                builder.Append(i);
            }
            string longUsername = builder.ToString();
            string shortenedUsername = Sanitizer.SanitizeUsername(longUsername);
            Assert.IsFalse(shortenedUsername.Length > 50);
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
