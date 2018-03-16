using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// A binary formatter.
    /// </summary>
    public class BinaryFormat : ISerializer
    {
        /// <summary>
        /// Serializes in binary format.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public string Serialize(object objectToSerialize)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, objectToSerialize);

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes an object that has been serialized in binary format.
        /// </summary>
        /// <param name="serializedString">The string to deserialize.</param>
        /// <returns></returns>
        public CerealList Deserialize(string serializedString)
        {
            byte[] serializedByteArray = Convert.FromBase64String(serializedString);

            using (var stream = new MemoryStream(serializedByteArray))
            {
                return (CerealList)new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}
