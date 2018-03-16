using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// A list of devices.
    /// </summary>
    /// <typeparam name="T">A device is the required type for this list.</typeparam>
    class DeviceList<T>: List<T> where T : Device
    {

    }
}
