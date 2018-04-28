using JamesNet.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JamesNet.Hubs
{
    /// <summary>
    /// A class that enables SignalR chat functionality.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// A queue of the last 50 messages.
        /// </summary>
        private static Queue<Message> messageHistory = MessageLogger.RetrieveMessages();

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
            if (messageHistory == null)
            {
                messageHistory = new Queue<Message>();
            }

            var message = new Message(name, messageText);
            if (messageHistory.Count == 50)
            {
                messageHistory.Dequeue();
            }
            messageHistory.Enqueue(message);
            Clients.All.receiveMessage(message.SenderName, message.MessageText);
            MessageLogger.Log(messageHistory);
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
            byte[] encryptedMessage = Encryptor.Encrypt(message.MessageText, encryptionKey).Result;
            // Encrypted messages are not logged.
            Clients.All.receiveEncryptedMessage(message.SenderName, encryptedMessage);
        }

        /// <summary>
        /// Initialize the client that just connected with a message from James, and the last 50 historical messages.
        /// </summary>
        public void ClientStartup()
        {
            var oldMessages = messageHistory.Count > 0 ? messageHistory : MessageLogger.RetrieveMessages();
            var orderedMessages = oldMessages.AsQueryable().OrderBy((m) => m.timeStamp);
            foreach (Message message in orderedMessages) {
                Clients.Caller.receiveMessage(message.SenderName, message.MessageText);
            }

            var welcomeMessage = new JamesMessage("Welcome to JamesNet!");
            Clients.Caller.receiveMessage(welcomeMessage.SenderName, welcomeMessage.MessageText);
        }

        /// <summary>
        /// Decrypt the message and send it to the client that requested it.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message to decrypt and send.</param>
        /// <param name="encryptionKey">The encryption key to attempt decryption with.</param>
        public string DecryptMessage(byte[] encryptedMessage, string encryptionKey)
        {
            return Encryptor.Decrypt(encryptedMessage, encryptionKey).Result;
        }
    }
}