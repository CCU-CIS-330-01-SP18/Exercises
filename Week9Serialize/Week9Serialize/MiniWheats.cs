using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Mini Wheats, a type of cereal.
    /// </summary>
    [Serializable]
    public class MiniWheats : Cereal
    {
        public MiniWheats() : base("Frosted Mini Wheats", false, CerealFlavor.Sugar, CerealSize.Large)
        {
        }
    }
}
