using System;

namespace JamesNet.Models
{
    /// <summary>
    /// Represents a single message.
    /// </summary>
    [Serializable]
    public class Message
    {
        public readonly DateTime timeStamp;
        protected string senderName;
        
        public string MessageText { get; set; }
        public string SenderName {
            get
            {
                return senderName;
            }
        }

        /// <summary>
        /// Instantiate a new Message object. The username and message will be sanitized.
        /// </summary>
        /// <param name="senderName">The sender's username.</param>
        /// <param name="messageText">The raw contents of the message.</param>
        public Message(string senderName, string messageText) : this(senderName, messageText, false) { }

        /// <summary>
        /// Instantiate a new Message object, with the option to suppress sanitization.
        /// </summary>
        /// <param name="senderName">The sender's username.</param>
        /// <param name="messageText">The raw contents of the message.</param>
        /// <param name="suppressSanitizer">Whether or not to suppress sanitization.</param>
        protected internal Message(string senderName, string messageText, bool suppressSanitizer)
        {
            if (suppressSanitizer)
            {
                this.senderName = senderName;
                MessageText = messageText;
            }
            else
            {
                this.senderName = Sanitizer.SanitizeUsername(senderName);
                MessageText = Sanitizer.SanitizeMessageText(messageText);
            }
            timeStamp = DateTime.Now;
        }
    }
}