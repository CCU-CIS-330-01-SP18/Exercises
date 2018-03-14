using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Week9_Serialization
{
    class BinarySerializer : ISerializer
    {
        public void Serialize(GameLibrary<VideoGame> library)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream stream = File.Create("bin_Library.txt"))
            {
                bf.Serialize(stream, library);
            }
        }

        public GameLibrary<VideoGame> Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using(FileStream read = File.OpenRead("bin_Library.txt"))
            {
                return bf.Deserialize(read) as GameLibrary<VideoGame>;
            }
        }
    }
}
