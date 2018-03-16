using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// An interface that allows classes to serialize and desirialize data.
    /// </summary>
    interface ISerializer
    {
        void Serialize(DeviceList<Device> list);
        DeviceList<Device> Deserialize();
    }
}
