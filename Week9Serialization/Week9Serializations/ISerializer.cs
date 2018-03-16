using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serializations
{
    /// <summary>
    /// An interface that allows classes to serialize and desirialize data.
    /// </summary>
    public interface ISerializer
    {
        void Serialize(DeviceList<Device> list);
        DeviceList<Device> Deserialize();
    }
}
