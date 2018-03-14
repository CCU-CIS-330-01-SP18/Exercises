using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9_Serialization
{
    /// <summary>
    /// An interface that enforces (de)serialization in its member classes.
    /// </summary>
    public interface ISerializer
    {
        void Serialize(GameLibrary<VideoGame> list);

        GameLibrary<VideoGame> Deserialize();
    }
}
