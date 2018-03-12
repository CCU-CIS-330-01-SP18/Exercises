using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Week9CodingExercise
{
    public class NewtonJsonSerializer : ISerializer
    {
        static void NewtonsoftJsonSerialization<T>(IndividualList<T> list) where T : Individual
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("nsj-individuals.json"))
            {
                serializer.Serialize(writer, list);
            }     
        }

        static object NewtonsoftJsonDeserialization<T>(IndividualList<T> list) where T : Individual
        {
            JsonSerializer serializer = new JsonSerializer
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
