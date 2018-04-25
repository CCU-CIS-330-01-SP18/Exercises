using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// A class which can hold a collection of Weapons
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // Required for Binary serialization.
    [Serializable]
    public class WeaponList<T> : List<T> where T : Weapon
    {
    }
}
