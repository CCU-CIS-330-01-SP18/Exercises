using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// Validates objects using Regular Expressions.
    /// </summary>
    public static class RegexHandler
    {
        /// <summary>
        /// Performs some name validation: Names must begin with a capital letter, and only one.
        /// </summary>
        /// <param name="test">The string to compare.</param>
        /// <returns>A boolean, depending on whether the string passes validation.</returns>
        public static Boolean Name(string test)
        {

            return Regex.Match(test, @"^[A-Z]{1}[a-z]+$").Success;
        }

        /// <summary>
        /// Performs some username validation: Usernames can only contain letters and numbers, and must be at least 6 characters long.
        /// </summary>
        /// <param name="test">The string to compare.</param>
        /// <returns>A boolean, depending on whether the string passes validation.</returns>
        public static Boolean Username(string test)
        {

            return Regex.Match(test, @"^[a-zA-Z0-9]{6,}$").Success;
        }

        /// <summary>
        /// Performs some email address validation.
        /// </summary>
        /// <param name="test">The string to compare.</param>
        /// <returns>A boolean, depending on whether the string passes validation.</returns>
        public static Boolean Email(string test)
        {

            return Regex.Match(test, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$").Success;
        }
    }
}
