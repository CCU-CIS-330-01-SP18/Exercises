using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Apollo11
{
    /// <summary>
    /// Performs the Serializing and Deserializing.
    /// </summary>
    class BinaryFormatSerializer
    {
        /// <summary>
        /// Sererializes the List.
        /// </summary>
        /// <param name="sererializedList">List passed in to Serialize.</param>
        /// <param name="path">File Name</param>
        /// <returns>The Serialized List.</returns>
        public PlanetList<Planet> Serialize(PlanetList<Planet> sererializedList, string path)
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.Create(path))
            {
                formatter.Serialize(stream, sererializedList);
            }

            return sererializedList;
        }

        /// <summary>
        /// Deserailizes the list.
        /// </summary>
        /// <param name="path">File Name</param>
        /// <returns>The Deserialized List</returns>
        public PlanetList<Planet> Deserialize(string path)
        {
            var formatter = new BinaryFormatter();

            PlanetList<Planet> deserializedList = null;

            using (var reader = File.OpenRead(path))
            {
                deserializedList = formatter.Deserialize(reader) as PlanetList<Planet>;

            }

            return deserializedList;
        }
    }
}
