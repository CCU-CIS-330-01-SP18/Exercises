using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Fruity Dino-Bites, a type of cereal.
    /// </summary>
    [Serializable]
    public class FruityBites : Cereal
    {
        public FruityBites() : base("Fruity Dino-Bites", true, CerealFlavor.Fruit, CerealSize.Small)
        {
        }
    }
}
