using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates a NewtonJsonSerializer that provides methods to serializes and deserializes
    /// IndividualLists into JSON format.
    /// </summary>
    public class NewtonJsonSerializer : ISerializer
    {
        /// <summary>
        /// Serializes an IndividualList into JSON format.
        /// </summary>
        /// <typeparam name="T">Of Type Individual.</typeparam>
        /// <param name="list">IndividualList to be serialized.</param>
        static void NewtonsoftJsonSerialization<T>(IndividualList<T> list) where T : Individual
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("nsj-individuals.json"))
            {
                serializer.Serialize(writer, list);
            }     
        }

        /// <summary>
        /// Method to deserialize an IndividualList.
        /// </summary>
        /// <typeparam name="T">Of Type Individual.</typeparam>
        /// <param name="list">An Individual List.</param>
        /// <returns>The Deserialized List.</returns>
        static object NewtonsoftJsonDeserialization<T>(IndividualList<T> list) where T : Individual
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            IndividualList<T> deserializedList = null;
            using (StreamReader reader = File.OpenText("nsj-individuals.json"))
            {
                deserializedList = serializer.Deserialize(reader, typeof(IndividualList<T>)) as IndividualList<T>;
            }

            return deserializedList;
        }

        /// <summary>
        /// An abstracted method to run the NewtonJsonSerializer.NewtonJsonSerialization method.
        /// </summary>
        /// <param name="list">An IndividualList to Serialize.</param>
        public void Serialize(IndividualList<Individual> list)
        {
            NewtonJsonSerializer.NewtonsoftJsonSerialization(list);
        }

        public object Deserialize(IndividualList<Individual> list)
        {
            return NewtonJsonSerializer.NewtonsoftJsonDeserialization(list);
        }
    }
}
