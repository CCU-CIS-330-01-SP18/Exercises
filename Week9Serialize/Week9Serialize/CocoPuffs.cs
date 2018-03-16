using System;
using System.Collections.Generic;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Coco Puffs, a type of cereal.
    /// </summary>
    [Serializable]
    public class CocoPuffs : Cereal
    {
        public CocoPuffs() : base("Coco Puffs", false, CerealFlavor.Chocolate, CerealSize.Medium)
        {         
        }
    }
}
