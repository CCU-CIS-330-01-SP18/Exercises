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
    [Serializable]

    [DataContract]
    public class BinarySerializer : ISerializer
    {
        static void BinarySerialization<T>(IndividualList<T> list) where T : Individual
        {
            var formatter = new BinaryFormatter();
            
            using (FileStream stream = File.Create("_b-individuals.txt"))
            {
                formatter.Serialize(stream, list);
            }

            /*IndividualList<T> deserializedList = null;
            using (FileStream reader = File.OpenRead("_b-individuals.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as IndividualList<T>;
            }*/
        }

        static object BinaryDeserialization<T>(IndividualList<T> list) where T : Individual
        {
            var formatter = new BinaryFormatter();

            IndividualList<T> deserializedList = null;
            using (FileStream reader = File.OpenRead("_b-individuals.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as IndividualList<T>;
            }

            return deserializedList;
        }

        public void Serialize(IndividualList<Individual> individualList)
        {
            BinarySerializer.BinarySerialization(individualList);
        }

        public object Deserialize(IndividualList<Individual> individualList)
        {
            return BinarySerializer.BinaryDeserialization(individualList);
        }
    }
}
