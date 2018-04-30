using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Apollo11
{
    /// <summary>
    /// Handles all of the Serialization and Deserialization.
    /// </summary>
    class SerializeAndDeserialize
    {
        /// <summary>
        /// Looks to see if there is a txt file, and then Serializes or Deserializes accordingly.
        /// </summary>
        /// <returns>List of Planets.</returns>
        public static PlanetList<Planet> GeneratePlanetSerializeAndDeserialize()
        {
            if (File.Exists("_PlanetList.txt"))
            {
                // If the file exists, deserialize the planets.
                var list = SerializeAndDeserialize.DeserializePlanetList("_PlanetList.txt");

                return list;
            }
            else
            {
                // Create the planet list.
                var list = GeneratePlanets.GenerateThePlanets();
               
                // Serialize the Planets.
                SerializeAndDeserialize.SerializePlanetList(list, "_PlanetList.txt");

                return list;
            }
        }

        /// <summary>
        /// Serializes the Planets.
        /// </summary>
        /// <param name="list">List of Planets</param>
        /// <param name="path">File Name</param>
        /// <returns></returns>
        public static PlanetList<Planet> SerializePlanetList(PlanetList<Planet> list, string path)
        {
            // Serialize the Planets.
            var format = new BinaryFormatSerializer();
            var serializedList = format.Serialize(list, path);

            return serializedList;
        }

        /// <summary>
        /// Deserializes the Planets.
        /// </summary>
        /// <param name="path">File Name</param>
        /// <returns></returns>
        public static PlanetList<Planet> DeserializePlanetList(string path)
        {
            // Desrialize the Planets.
            var format = new BinaryFormatSerializer();
            var deserializedList = format.Deserialize(path);

            return deserializedList;
        }
    }
}
