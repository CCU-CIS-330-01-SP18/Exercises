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
        private static string logName = "logs\\msg_history.log";
        /// <summary>
        /// Log the <see cref="Queue{T}"/> to a file, in binary format.
        /// </summary>
        public static void Log(Queue<Message> message)
        {
            if (!Directory.Exists("logs"))
            {
                Directory.CreateDirectory("logs");
            }
            var binary = new BinaryFormatter();
            using (var stream = File.OpenWrite(logName))
            {
                binary.Serialize(stream, message);
            }
        }

        /// <summary>
        /// Retrieve <see cref="Message"/>s from the log.
        /// </summary>
        /// <returns>A <see cref="Queue{T}"/> of <see cref="Message"/>s.</returns>
        public static Queue<Message> RetrieveMessages()
        {
            if (!File.Exists(logName))
            {
                Log(new Queue<Message>());
            }
            var binary = new BinaryFormatter();
            var messages = new Queue<Message>();
            using (var stream = File.OpenRead(logName))
            {
                messages = (Queue<Message>)binary.Deserialize(stream);
            }
            return messages;
        }
    }
}