using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Class that serializes and deserializes using Binary Serialization.
    /// </summary>
    class BinarySerializer : ISerializer
    {

        /// <summary>
        /// Performs a binary serialization on a Roster of Action Characters.
        /// </summary>
        /// <param name="roster">The Roster of Action Characters.</param>
        public void Serialize(Roster<ActionCharacter> roster)
        {
            var binaryFormatter = new BinaryFormatter();

            using (FileStream stream = File.Create("roster_bin.txt"))
            {
                binaryFormatter.Serialize(stream, roster);
            }

        }

        /// <summary>
        /// Performs a binary deserialization.
        /// </summary>
        /// <returns>The roster list that has been deserialaized.</returns>
        public Roster<ActionCharacter> Deserialize()
        {
            var binaryFormatter = new BinaryFormatter();

            using(FileStream read = File.OpenRead("roster_bin.txt"))
            {
                return binaryFormatter.Deserialize(read) as Roster<ActionCharacter>;
            }
        }
    }
}
