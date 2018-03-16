using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    interface ISerializer
    {
        string Serialize(object objectToSerialize);
        CerealList Deserialize(string serializedString);
    }
}
