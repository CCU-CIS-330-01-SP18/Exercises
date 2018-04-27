using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASN
{
    public static class RegexHandler
    {
        public static Boolean Name(string test)
        {

            return Regex.Match(test, @"^[A-Z]{1}[a-z]+$").Success;
        }

        public static Boolean Username(string test)
        {

            return Regex.Match(test, @"^[a-zA-Z0-9]{6,}$").Success;
        }

        public static Boolean Email(string test)
        {

            return Regex.Match(test, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$").Success;
        }
    }
}
