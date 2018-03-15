﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    interface ISerializer
    {
        /// <summary>
        /// Serializes this object to a byte array.
        /// </summary>
        /// <returns>A byte array representation of the object this method is called on.</returns>
        byte[] Serialize();

        /// <summary>
        /// Given a serialized byte array, deserializes an object.
        /// </summary>
        /// <param name="serialized">A serialized object, in byte array form.</param>
        /// <returns>The deserialized object.</returns>
        object Deserialize(byte[] serialized);
    }
}
