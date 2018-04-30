using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo11
{
    /// <summary>
    /// The list of Planets.
    /// </summary>
    /// <typeparam name="T">Planet</typeparam>
    [Serializable]
    public class PlanetList<T> : List<T> where T: Planet
    {
    }
}
