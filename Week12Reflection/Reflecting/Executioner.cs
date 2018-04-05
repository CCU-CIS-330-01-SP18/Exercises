using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflecting
{
    /// <summary>
    /// Posesses the 2 properties and 1 method relevant to an executioner in the 14th century.
    /// </summary>
    public class Executioner
    {
        private string PrimaryWeapon { get; set; }
        private string Sidearm { get; set; }

        /// <summary>
        /// Cuts the head off the prisoner.
        /// </summary>
        private void Decapitate()
        {
        }

    }
}
