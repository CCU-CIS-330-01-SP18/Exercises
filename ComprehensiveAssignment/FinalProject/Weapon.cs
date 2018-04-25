using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    /// <summary>
    /// This is a serializable class which contains a few properties for weapons.
    /// </summary>
    // Required for Binary serialization.
    [Serializable]
    public class Weapon
    {
            public string Name { get; set; }
            public decimal Cost { get; set; }
    }
}
