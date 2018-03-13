using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    interface ISerializer
    {
        void Serialize();
        void Deserialize();
    }
}
