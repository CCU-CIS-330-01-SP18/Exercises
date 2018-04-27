using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// Sanitizes messages that may or may not contain HTML syntax.
    /// </summary>
    /// <remarks>Technically, JQuery can sanitize HTML code client-side. I'm doing it in C# to fulfill regex assignment requirements.</remarks>
    public class Sanitizer
    {
        /// <summary>
        /// Sanitize the given message to eliminate code injection, and trim it down to size if too long.
        /// </summary>
        /// <param name="message">The message to sanitize.</param>
        /// <returns>A sanitized message, possibly with a snarky comment.</returns>
        public static string Sanitize(string message)
        {
            var match = Regex.Match(message, @"\<\w*\>");
            if (match.Success)
            {
                message = message.Replace("<", "&lt;").Replace(">", "&gt;");
                var builder = new StringBuilder();
                builder.Insert(0, "(I tried to hack you with this!) " + message);
                message = builder.ToString();
            }
            if (message.Length > 255)
            {
                message = message.Remove(251, message.Length - 252);
                message += "...";
            }
            return message;
        }

        /// <summary>
        /// Sanitize the given username to eliminate code injection, and trim it down to size if too long.
        /// </summary>
        /// <param name="name">The username to sanitize.</param>
        /// <returns>The sanitized username.</returns>
        public static string SanitizeUsername(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return "I forgot to enter a username :(";
            }
            var match = Regex.Match(name, @"\<\w*\>");
            if (match.Success)
            {
                return "1337 5KR1PT K1DD13!!1!one!";
            }
            if (name.Length > 50)
            {
                return "Steve McLongName";
            }
            return name;
        }
    }
}