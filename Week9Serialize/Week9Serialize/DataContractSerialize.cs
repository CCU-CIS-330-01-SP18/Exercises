using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    public class DataContractSerialize : ISerializer
    {
        private DataContractSerializer Serializer = new DataContractSerializer(typeof(CerealList));

        /// <summary>
        /// Serializes in data contract format.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public string Serialize(object objectToSerialize)
        {
            using (var stream = new MemoryStream())
            {
                new DataContractSerializer(typeof(CerealList)).WriteObject(stream, objectToSerialize);

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes an object that has been serialized in data contract format.
        /// </summary>
        /// <param name="serializedString">The string to deserialize.</param>
        /// <returns></returns>
        public CerealList Deserialize(string serializedString)
        {
            byte[] serializedByteArray = Convert.FromBase64String(serializedString);

            using (var stream = new MemoryStream(serializedByteArray))
            {
                return (CerealList)Serializer.ReadObject(stream);
            }
        }
    }
}
