﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Interface that defines two methods, serialize and deserialize.
    /// </summary>
    public interface ISerializer
    {
        void Serialize(object a);

        void Deserialize(object a);
    }
}