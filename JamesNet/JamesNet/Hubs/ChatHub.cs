using JamesNet.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="messageText">The raw message to send.</param>
        public void Send(string name, string messageText)
        {
            if (String.IsNullOrWhiteSpace(messageText))
            {
                return;
            }
            var message = new Message(name, messageText);
            Clients.All.receiveMessage(message.SenderName, message.MessageText);
        }

        /// <summary>
        /// Send a message encrypted with a key to all users.
        /// </summary>
        /// <param name="name">The name of the user that sent the message.</param>
        /// <param name="messageText">The raw message to encrypt and send.</param>
        /// <param name="encryptionKey">The plain-text version of the encryption key.</param>
        public void Send(string name, string messageText, string encryptionKey)
        {
            if (String.IsNullOrWhiteSpace(messageText))
            {
                return;
            }
            var message = new Message(name, messageText);
            byte[] encryptedMessage = Encryptor.Encrypt(message.MessageText, encryptionKey);
            Clients.All.receiveEncryptedMessage(message.SenderName, encryptedMessage);
        }

        /// <summary>
        /// Get the last 50 messages and send them down to the client that requested them, in send order.
        /// </summary>
        public void PopulateMessageHistory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initialize the client that just connected with a message from James, and the last 50 historical messages.
        /// </summary>
        public void ClientStartup()
        {
            var welcomeMessage = new JamesMessage("Welcome to JamesNet!");
            Clients.Caller.receiveMessage(welcomeMessage.SenderName, welcomeMessage.MessageText);

            // TODO: Historical messages
        }

        /// <summary>
        /// Decrypt the message and send it to the client that requested it.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message to decrypt and send.</param>
        /// <param name="encryptionKey">The encryption key to attempt decryption with.</param>
        public string DecryptMessage(byte[] encryptedMessage, string encryptionKey)
        {
            return Encryptor.Decrypt(encryptedMessage, encryptionKey);
        }

        /// <summary>
        /// Checks to see if the given username is valid.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>Whether or not the name is valid.</returns>
        [Obsolete("Usernames are now sanitized each time a message is sent.")]
        public string ValidateUsername(string name)
        {
            return Sanitizer.SanitizeUsername(name);
        }
    }
}