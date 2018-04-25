using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This is an interface which requires any classes which inherit from it to provide a Serialize and Deserialize method.
    /// </summary>
    interface ISerializer
    {
        /// <summary>
        /// Requires a method to use Serialize and returns a WeaponList<Weapon> type that way you can run tests on the methods that implement ISerializer.
        /// </summary>
        /// <param name="list">
        /// This is the collection which will be serialized.
        /// </param>
        /// <param name="path">
        /// This is the path of where to serialize to.
        /// </param>
        /// <returns></returns>
        WeaponList<Weapon> Serialize(WeaponList<Weapon> list, string path);

        /// <summary>
        /// Requires a method to use Deserialize and returns a WeaponList<Weapon> type that way you can run tests on the methods that implement ISerializer
        /// </summary>
        /// <param name="path">
        /// This is the path of where to serialize to.
        /// </param>
        /// <returns></returns>
        WeaponList<Weapon> Deserialize(string path);
    }
}