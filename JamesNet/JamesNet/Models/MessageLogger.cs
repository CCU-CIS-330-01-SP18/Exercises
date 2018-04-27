using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace JamesNet.Models
{
    /// <summary>
    /// Logs messages to a JSON file.
    /// </summary>
    public static class MessageLogger
    {
        private delegate List<Message> MessageRetrieval();

        /// <summary>
        /// Log the message to a JSON file.
        /// </summary>
        public async static void Log(Message message)
        {
            var json = new DataContractJsonSerializer(typeof(Message));
            using (var stream = File.OpenWrite("msg.log"))
            {
                await Task.Run(() => json.WriteObject(stream, message));
            }
        }

        /// <summary>
        /// Retrieve messages from the log.
        /// </summary>
        /// <param name="numberToRetrieve">The number of messages to retrieve, starting with the most recent.</param>
        /// <returns>A list of messages, ordered from most to least recent.</returns>
        public static List<Message> RetrieveMessages(int numberToRetrieve)
        {
            var messages = new List<Message>();
            var json = new DataContractJsonSerializer(typeof(Message));
            using (var stream = File.OpenRead("msg.log"))
            {
                for (int i = 0; i < numberToRetrieve; i++)
                {
                    messages.Add((Message)json.ReadObject(stream));
                }
            }
            throw new NotImplementedException();
        }
    }
}