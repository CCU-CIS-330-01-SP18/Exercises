using JamesNet.Models;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;

namespace JamesNet.Hubs
{
    /// <summary>
    /// A class that enables SignalR chat functionality.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// Send the given message to all users.
        /// </summary>
        /// <param name="name">The name of the user that sent the message.</param>
        /// <param name="message">The raw message to send.</param>
        public void Send(string name, string message)
        {
            string sanitizedMessage = Sanitizer.Sanitize(message);
            Clients.All.receiveMessage(name, sanitizedMessage);
        }

        /// <summary>
        /// Checks to see if the given username is valid.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>Whether or not the name is valid.</returns>
        public string Validate(string name)
        {
            return Sanitizer.SanitizeUsername(name);
        }
    }
}