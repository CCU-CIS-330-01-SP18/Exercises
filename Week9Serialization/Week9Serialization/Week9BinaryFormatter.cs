using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the BinaryFormatter method.
    /// </summary>
    class Week9BinaryFormatter : ISerializer
    {
        string fileName = "bf_serialized.txt";

        /// <summary>
        /// Takes 
        /// </summary>
        /// <param name="serialized"></param>
        /// <returns></returns>
        public object Deserialize(byte[] serialized)
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(Team<T> team) where T : Cephalokid
        {
            var binaryFormatter = new BinaryFormatter();

            if (!File.Exists(fileName))
            {
                using (var file = File.Create(fileName))
                {
                    binaryFormatter.Serialize(file, team);
                }

                return fileName;
            }
        }
    }
}
