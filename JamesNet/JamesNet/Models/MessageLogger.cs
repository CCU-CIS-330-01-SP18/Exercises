using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// Logs messages to a file.
    /// </summary>
    public static class MessageLogger
    {
        /// <summary>
        /// Log the message to a file, in binary format.
        /// </summary>
        public static void Log(Message message)
        {
            // TODO: This still doesn't work!
            var binary = new BinaryFormatter();
            using (var stream = File.OpenWrite("msg.log"))
            {
                binary.Serialize(stream, message);
            }
        }

        /// <summary>
        /// Retrieve messages from the log.
        /// </summary>
        /// <param name="numberToRetrieve">The number of messages to retrieve, starting with the most recent.</param>
        /// <returns>A list of messages, ordered from most to least recent.</returns>
        public static List<Message> RetrieveMessages(int numberToRetrieve)
        {
            if (!File.Exists("msg.log"))
            {
                return new List<Message>();
            }
            var messages = new List<Message>();
            var binary = new BinaryFormatter();
            using (var stream = File.OpenRead("msg.log"))
            {
                for (int i = 0; i < numberToRetrieve; i++)
                {
                    messages.Add((Message)binary.Deserialize(stream));
                }
            }
            return messages;
        }
    }
}