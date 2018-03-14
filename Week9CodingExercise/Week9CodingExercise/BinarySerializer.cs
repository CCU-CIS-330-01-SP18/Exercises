using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Week9CodingExercise
{
    /// <summary>
    /// Provides methods for serializing and deserializing a given list of individuals into Binary format.
    /// </summary>
    [Serializable]

    [DataContract]

    public class BinarySerializer : ISerializer
    {
        /// <summary>
        /// Method that serializes a given list of Individuals and serializes them in Binary format.
        /// </summary>
        /// <typeparam name="T">Of Type Object Individual.</typeparam>
        /// <param name="list">An instance of an IndividualList that can be passed in to the method.</param>
        static void BinarySerialization<T>(IndividualList<T> list) where T : Individual
        {
            // Creates a new BinaryFormatter
            var formatter = new BinaryFormatter();
            
            // Creates a file stream along with the txt file and serializes it in Binary.
            using (FileStream stream = File.Create("b-individuals.txt"))
            {
                formatter.Serialize(stream, list);
            }
        }

        /// <summary>
        /// Deserializes a Binary txt file.
        /// </summary>
        /// <typeparam name="T">Of Type Individual Object.</typeparam>
        /// <param name="list">A passed in IndivualList.</param>
        /// <returns>An object which in this case is the deserialized list.</returns>
        static object BinaryDeserialization<T>(IndividualList<T> list) where T : Individual
        {
            var formatter = new BinaryFormatter();

            IndividualList<T> deserializedList = null;
            using (FileStream reader = File.OpenRead("b-individuals.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as IndividualList<T>;
            }

            return deserializedList;
        }

        /// <summary>
        /// Abstracted method that uses the BinarySerializer.BinarySerialization method based on the interface ISerializer.
        /// </summary>
        /// <param name="individualList">A list that is passed in to serialize.</param>
        public void Serialize(IndividualList<Individual> individualList)
        {
            BinarySerializer.BinarySerialization(individualList);
        }

        /// <summary>
        /// Abstracted method to deserialize an Individual List in Binary based on the interface ISerializer.
        /// </summary>
        /// <param name="individualList">A list of Individuals that is passed in to deserialize.</param>
        /// <returns></returns>
        public object Deserialize(IndividualList<Individual> individualList)
        {
            return BinarySerializer.BinaryDeserialization(individualList);
        }
    }
}
