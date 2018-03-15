using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serializeation
{
    /// <summary>
    /// A class which can hold a collection of Weapons
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [KnownType(typeof(Sabre))]
    [KnownType(typeof(Halberd))]
    public class WeaponList<T> : List<T> where T : Weapon
    {
    }
}
