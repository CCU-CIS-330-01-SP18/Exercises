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
    /// Logs <see cref="Message"/>s to a file.
    /// </summary>
    public static class MessageLogger
    {
        /// <summary>
        /// Log the <see cref="Queue{T}"/> to a file, in binary format.
        /// </summary>
        public static void Log(Queue<Message> message)
        {
            // TODO: This still doesn't work!
            var binary = new BinaryFormatter();
            using (var stream = File.OpenWrite("msg_h.log"))
            {
                binary.Serialize(stream, message);
            }
        }

        /// <summary>
        /// Retrieve <see cref="Message"/>s from the log.
        /// </summary>
        /// <returns>A <see cref="Queue{T}"/> of <see cref="Message"/>s, ordered from most to least recent.</returns>
        public static Queue<Message> RetrieveMessages()
        {
            if (!File.Exists("msg_h.log"))
            {
                return new Queue<Message>();
            }
            var binary = new BinaryFormatter();
            var messages = new Queue<Message>();
            using (var stream = File.OpenRead("msg_h.log"))
            {
                messages = (Queue<Message>)binary.Deserialize(stream);
            }
            return messages;
        }
    }
}