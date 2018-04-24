using JamesNet.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
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
        /// <param name="message">The raw message to send.</param>
        public void Send(string name, string message)
        {
            string sanitizedMessage = Sanitizer.Sanitize(message);
            Clients.All.receiveMessage(name, sanitizedMessage);
        }

        /// <summary>
        /// Send a message encrypted with a key to all users.
        /// </summary>
        /// <param name="name">The name of the user that sent the message.</param>
        /// <param name="message">The raw message to encrypt and send.</param>
        /// <param name="encryptionKey">The plain-text version of the encryption key.</param>
        public void Send(string name, string message, string encryptionKey)
        {
            string sanitizedMessage = Sanitizer.Sanitize(message);
            byte[] encryptedMessage = Encryptor.Encrypt(sanitizedMessage, encryptionKey);
            Clients.All.receiveEncryptedMessage(name, encryptedMessage);
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
        public string ValidateUsername(string name)
        {
            return Sanitizer.SanitizeUsername(name);
        }
    }
}