using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// A message from James himself. The sanitizer ignores James's messages, so he can inject JavaScript.
    /// </summary>
    internal sealed class JamesMessage : Message
    {
        /// <summary>
        /// Instantiate a new JamesMessage object. The message will not be sanitized.
        /// </summary>
        /// <param name="messageText">The raw contents of the message.</param>
        public JamesMessage(string messageText) : base("James", messageText, false) { }
    }
}